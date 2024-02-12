// Locals
#include "querymanager.h"
#include "Functional/getContentListResponseParser.h"
#include "Functional/AuthenticateResponseParser.h"
#include "Functional/AddCustomerResponseParser.h"
#include "Functional/GetClientInfoResponseParser.h"
#include "Functional/GetContentUrlResponseParser.h"
#include "Functional/GetRegistrationListResponseParser.h"
#include "Functional/GetSoftwareVersionResponseParser.h"
#include "Functional/GetSoftwareVersion2ResponseParser.h"
#include "Functional/CheckLatestMapResponseParser.h"
#include "Functional/CheckMapVersionResponseParser.h"
#include "Functional/GetFtpUploadUrlResponseParser.h"
#include "Functional/GetVoucherInfoResponseParser.h"
#include "Functional/RedeemVoucherResponseParser.h"
#include "Functional/RegisterAdditionalContentResponseParser.h"
#include "Functional/RegisterDeviceResponseParser.h"
#include "Functional/ResolveSiteResponseParser.h"
#include "Interfaces/ISettingsManager.h"
#include "Interfaces/IDeviceManager.h"
#include "Interfaces/IAccountManager.h"
// Qt
#include <QNetworkAccessManager>
#include <QNetworkReply>
#include <QByteArray>
#include <QDomDocument>

namespace FreshServices
{
   // Initialize the server commands
   const QString QueryManager::m_addCustomer = "addCustomer";
   const QString QueryManager::m_authenticate = "authenticate";
   const QString QueryManager::m_checkLatestMap = "checkLatestMap";
   const QString QueryManager::m_checkMapVersion = "checkMapVersion";
   const QString QueryManager::m_getClientInfo = "getClientInfo";
   const QString QueryManager::m_getContentList = "getContentList";
   const QString QueryManager::m_getContentURL = "getContentURL";
   const QString QueryManager::m_getFtpUploadURL = "getFtpUploadURL";
   const QString QueryManager::m_getRegistrationList = "getRegistrationList";
   const QString QueryManager::m_getSoftwareVersion = "getSoftwareVersion";
   const QString QueryManager::m_getSoftwareVersion2 = "getSoftwareVersion2";
   const QString QueryManager::m_getVoucherInfo = "getVoucherInfo";
   const QString QueryManager::m_redeemVoucher = "redeemVoucher";
   const QString QueryManager::m_registerAdditionalContent = "registerAdditionalContent";
   const QString QueryManager::m_registerDevice = "registerDevice";
   const QString QueryManager::m_updateLatestMap = "updateLatestMap";
   const QString QueryManager::m_updateRegistration = "updateRegistration";
   const QString QueryManager::m_upgradeProduct = "upgradeProduct";
   const QString QueryManager::m_resolveSite = "resolveSite";

   QueryManager::QueryManager():
      m_currentCommand(INVALID_COMMAND),
      m_settingsMgrPtr(),
      m_deviceMgrPtr(),
      m_networkReply(NULL)
   {
      m_networkManager = new QNetworkAccessManager(this);
      m_shopAddress = "";
   }

   QueryManager::~QueryManager()
   {
      delete m_networkManager;
      m_shopAddress = "";
   }

   bool QueryManager::Init(ISettingsManagerPtr settingsPtr, IDeviceManagerPtr devicePtr, IAccountManagerPtr accountPtr)
   {
      // Settings pointer must not be NULL, the device pointer will be checked at get content list request
      if ( settingsPtr.get() != NULL && accountPtr.get() != NULL )
      {
         m_settingsMgrPtr = settingsPtr;
         m_deviceMgrPtr = devicePtr;
         m_accountManager = accountPtr;
         return true;
      }
      else
      {
         return false;
      }
   }

   bool QueryManager::SendQuery( FreshServerCommands commandName )
   {
      QMap<QString, QString> tmpMap;
      return SendQuery( commandName, tmpMap );
   }

   bool QueryManager::SendQuery(FreshServerCommands commandName, QMap<QString, QString>& querryMap)
   {
      if ( ( m_deviceMgrPtr.get() == NULL ) && ( commandName == CHECK_LATEST_MAP || commandName == CHECK_MAP_VERSION || 
         commandName == GET_CLIENT_INFO || commandName == GET_CONTENT_LIST || commandName == GET_CONTENT_URL ||
         commandName == GET_FTP_UPLOAD_URL || commandName == GET_REGISTRATION_LIST || commandName == GET_SOFTWARE_VERSION ||
         commandName == GET_SOFTWARE_VERSION2 || commandName == GET_VOUCHER_INFO || commandName == REDEEM_VOUCHER || 
         commandName == REGISTER_DEVICE || commandName == UPDATE_LATEST_MAP || commandName == UPDATE_REGISTRATION ||
         commandName == UPGRADE_PRODUCT ) ) 
      {
         // Missing informations about device
         return false;
      }
      if ( !m_accountManager->IsLoggedIn() && commandName != AUTHENTICATE && commandName != RESOLVE_SITE )
      {
         // The user is not log in
         return false;
      }
      // Get user and password from account manager, if the command is not authenticate
      QString user;
      QString password;
      bool ret = m_accountManager->GetUser( user );
      bool ret1 = m_accountManager->GetPassword( password );
      if ( ( !ret || !ret1 ) && ( commandName != AUTHENTICATE ) && ( commandName != RESOLVE_SITE ) )
      {
         // Failed to initialize the user or password
         return false;
      }
      // The server address from settings
      ServerSettings serverSettings;
      ret = m_settingsMgrPtr->GetServerSettings( serverSettings );
      if ( !ret )
      {
         // Exit here, the server address was not get properly
         return false;
      }
      // Get the client type and client version from device manager
      GETINFORESPONSEFORDRIVE_T tmpGetInfoResp;
      if ( commandName == CHECK_LATEST_MAP || commandName == CHECK_MAP_VERSION || commandName == GET_CLIENT_INFO ||
         commandName == GET_CONTENT_LIST || commandName == GET_REGISTRATION_LIST || commandName == REGISTER_DEVICE )
      {
         ret = m_deviceMgrPtr->GetDeviceInfo( tmpGetInfoResp );
      }
      // TODO: complete this list
      if ( ret == false && ( commandName == CHECK_LATEST_MAP || commandName == CHECK_MAP_VERSION || commandName == GET_CLIENT_INFO ||
           commandName == GET_CONTENT_LIST || commandName == GET_REGISTRATION_LIST || commandName == REGISTER_DEVICE ) )
      {
         return false;
      }
      // Complete client type, client version, hardware id and device uid for Navigon software and device
      QString clientTypeNavSoft = tmpGetInfoResp.software.brand + "_" + tmpGetInfoResp.software.platform;
      QString clientVersionNavSoft = tmpGetInfoResp.software.version;
      QString deviceUID_ = tmpGetInfoResp.software.deviceUID;
      QString hardwareID_ = tmpGetInfoResp.software.hardwareID;
      // TODO: this was only comment for some tests, uncomment when ready
      // QString querryString = serverSettings.m_FreshServerAddress + "?cmd=";
      QString querryString = "http://st-mysite-upd-5.mobility-platform.de/upd/api/client?cmd=";
      // TODO: get this from the proper place
      QString querryStringShop = "http://www.mysite.com/ws/resolveSite";
      switch( commandName )
      {
      case ADD_CUSTOMER: 
         querryString += m_addCustomer + "&email=" + user + "&password=" + password;
         break;
         // Here the mail and password must be provided as parameters since we check if the user is registered
         // At the other commands, if the user is log in, will take the informations from the account manager
      case AUTHENTICATE:
         querryString += m_authenticate;
         break;
      case CHECK_LATEST_MAP:
         querryString += m_checkLatestMap + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/ + "&clientType=" + clientTypeNavSoft + "&clientVersion=" + clientVersionNavSoft + 
            "&mapInfo=" /*+ map info*/;
         break;
      case CHECK_MAP_VERSION:
         querryString += m_checkMapVersion + "&clientType=" + clientTypeNavSoft + "&clientVersion=" + clientVersionNavSoft + 
            "&mapInfo=" /*+ map info*/;
         break;
      case GET_CLIENT_INFO:
         querryString += m_getClientInfo + "&clientType=" + clientTypeNavSoft + "&clientVersion=" + clientVersionNavSoft;
         break;
         // TODO: check if registration id will be take from device manager, or it will be pass as a parameter
         // TODO: get locale from settings
      case GET_CONTENT_LIST:
         querryString += m_getContentList + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/ + "&clientType=" + clientTypeNavSoft + "&clientVersion=" + clientVersionNavSoft +
            "&locale=" /*+ locale*/;
         break;
      case GET_CONTENT_URL:
         querryString += m_getContentList + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/;
         break;
      case GET_FTP_UPLOAD_URL:
         querryString += m_getFtpUploadURL + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/;         
         break;
      case GET_REGISTRATION_LIST:
         querryString += m_getRegistrationList + "&email=" + user + "&password=" + password + "&clientType=" + clientTypeNavSoft + 
            "&clientVersion=" + clientVersionNavSoft;
         break;
      case GET_SOFTWARE_VERSION:
         // TODO: from where we get this informations?
         querryString += m_getSoftwareVersion + "&clientType=" /*+ client type*/ + "&clientVersion=" /*+ client version*/ +
            "&locale=" /*+ locale*/;
         break;
      case GET_SOFTWARE_VERSION2:
         // TODO: from where we get this informations?
         querryString += m_getSoftwareVersion2 + "&email=" + user + "&password=" + password + 
            "&clientType=" /*+ client type*/ + "&clientVersion=" /*+ client version*/ + "&locale=" /*+ locale*/;
         break;
      case GET_VOUCHER_INFO:
         querryString += m_getVoucherInfo + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/ + "&locale=" /*+ locale*/;
         break;
      case REDEEM_VOUCHER:
         querryString += m_redeemVoucher + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/ + "&locale=" /*+ locale*/;         
         break;
      case REGISTER_ADDITIONAL_CONTENT:
         querryString += m_registerAdditionalContent + "&email=" + user + "&password=" + password;         
         break;
      case REGISTER_DEVICE:
         // TODO: check witch optional parameters will ad
         querryString += m_registerDevice + "&email=" + user + "&password=" + password + 
            "&clientType=" + clientTypeNavSoft + "&clientVersion=" + clientVersionNavSoft + "&mapInfo=" /*+ map info*/ + 
            "&deviceUID=" + deviceUID_ + "&hardwareID=" + hardwareID_ + "&gspTimestamp=" /*+ deviceUID*/;
         break;
      case UPDATE_LATEST_MAP:
         querryString += m_updateLatestMap + "&registrationID=" /*+ registrationID*/;
         break;
      case UPDATE_REGISTRATION:
         // TODO: check witch optional parameters will ad
         querryString += m_updateRegistration + "&email=" + user + "&password=" + password + "&registrationID=" /*+ registrationID*/;
         break;
      case UPGRADE_PRODUCT:
         querryString += m_upgradeProduct + "&email=" + user + "&password=" + password + 
            "&registrationID=" /*+ registrationID*/ + "&hardwareID=" + hardwareID_;
         break;
      case RESOLVE_SITE:
         querryString = querryStringShop;
         break;
      default:
         // The command is not known, return false
         return false;
      }
      if ( querryMap.size() > 0 )
      {
         for ( QMap<QString, QString>::iterator mapIt = querryMap.begin(); mapIt != querryMap.end(); mapIt++ )
         {
            querryString += "&" + mapIt.key() + "=" + mapIt.value();
         }
      }
      m_currentCommand = commandName;
      QNetworkRequest request;
      request.setUrl( QUrl( querryString ) );
      request.setRawHeader( "User-Agent", "Fresh 2.5" );
      m_networkReply = m_networkManager->get( request );
      connect(m_networkReply, SIGNAL(readyRead()), this, SLOT(readyRead()));
      connect(m_networkReply, SIGNAL(finished()), this, SLOT(commandFinished()));
      return true;
   }

   void QueryManager::readyRead()
   {
      m_fullReply += m_networkReply->readAll();
   }

   void QueryManager::commandFinished()
   {
      QDomDocument serverResponseXml;
      if ( !serverResponseXml.setContent( m_fullReply, false, NULL, NULL, NULL ) )
      {
         // Invalid server response
         // Send the finish signal
         disconnect(m_networkReply, SIGNAL(readyRead()), this, SLOT(readyRead()));
         disconnect(m_networkReply, SIGNAL(finished()), this, SLOT(commandFinished()));
         emit ServerReplyFinish_signal();
         return;
      }
      int ret = -1;
      // Parse the response depends on the current command request
      if ( m_currentCommand == ADD_CUSTOMER )
      {
         AddCustomerResponseParser addCustomerResp;
         ret = addCustomerResp.Init( serverResponseXml );
         if ( ret == 0 )
         {
            addCustomerResp.GetAddCustomerResponse( m_addCustomerResp );
         }
      }
      else if ( m_currentCommand == AUTHENTICATE )
      {
         AutenticateResponseParser authenticateParser;
         ret = authenticateParser.Init( serverResponseXml );
         if ( ret == 0 )
         {
            authenticateParser.GetAuthenticateResponse( m_authenticateResp );
         }
      }
      else if ( m_currentCommand == CHECK_LATEST_MAP )
      {
         CheckLatestMapResponseParser checkLatestMapresponse;
         ret = checkLatestMapresponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            checkLatestMapresponse.GetCheckLatestMapResponse( m_checkLatestMapResp );
         }
      }
      else if ( m_currentCommand == CHECK_MAP_VERSION )
      {
         CheckMapVersionResponseParser checkMapVersionResp;
         ret = checkMapVersionResp.Init( serverResponseXml );
         if ( ret == 0 )
         {
            checkMapVersionResp.GetCheckLatestMapVersionResponse( m_checkMapVersionResp );
         }
      }
      else if ( m_currentCommand == GET_CLIENT_INFO )
      {
         GetClientInfoResponseParser getClientInfoResponse;
         ret = getClientInfoResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getClientInfoResponse.GetGetClientInfoResponse( m_getClientInfoResp );
         }
      }
      else if ( m_currentCommand == GET_CONTENT_LIST )
      {
         getContentListResponseParser contentListParser;
         ret = contentListParser.Init( serverResponseXml );
         if ( ret == 0 )
         {
            // Init the server response member with the content list response
            contentListParser.GetContentListResponse( m_getContentListResp );
         }
      }
      else if ( m_currentCommand == GET_CONTENT_URL )
      {
         GetContentUrlResponseParser getContentUrlResponse;
         ret = getContentUrlResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getContentUrlResponse.GetGetContentUrlResponse( m_getContentUrlResp );
         }
      }
      else if ( m_currentCommand == GET_FTP_UPLOAD_URL )
      {
         GetFtpUploadUrlResponseParser getFtpUploaderUrlResponse;
         ret = getFtpUploaderUrlResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getFtpUploaderUrlResponse.GetGetFtpUploadUrlResponse( m_getFtpUploadUrlResp );
         }
      }
      else if ( m_currentCommand == GET_REGISTRATION_LIST )
      {
         GetRegistrationListResponseParser getRegistrationListResponse;
         ret = getRegistrationListResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getRegistrationListResponse.GetGetRegistrationListResponse( m_getRegistrationListResp );
         }
      }
      else if ( m_currentCommand == GET_SOFTWARE_VERSION )
      {
         GetSoftwareVersionResponseParser getSoftwareVersionResponse;
         ret = getSoftwareVersionResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getSoftwareVersionResponse.GetGetSoftwareVersionResponse( m_getSoftwareVersionResp );
         }
      }
      else if ( m_currentCommand == GET_SOFTWARE_VERSION2 )
      {
         GetSoftwareVersion2ResponseParser getSoftwareVersion2Response;
         ret = getSoftwareVersion2Response.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getSoftwareVersion2Response.GetGetSoftwareVersion2Response( m_getSoftwareVersion2Resp );
         }
      }
      else if ( m_currentCommand == GET_VOUCHER_INFO )
      {
         GetVoucherInfoResponseParser getVoucherInfoResp;
         ret = getVoucherInfoResp.Init( serverResponseXml );
         if ( ret == 0 )
         {
            getVoucherInfoResp.GetGetVoucherInfoResponse( m_getVoucherInfoResp );
         }
      }
      else if ( m_currentCommand == REDEEM_VOUCHER )
      {
         RedeemVoucherResponseParser redeemVoucherResponse;
         ret = redeemVoucherResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            redeemVoucherResponse.GetRedeemVoucherResponse( m_redeemVoucherResp );
         }
      }
      else if ( m_currentCommand == REGISTER_ADDITIONAL_CONTENT )
      {
         RegisterAdditionalContentResponseParser registerAdditionalContentResponse;
         ret = registerAdditionalContentResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            registerAdditionalContentResponse.GetRegisterAdditionalContentResponse( m_registerAdditionalContentResp );
         }
      }
      else if ( m_currentCommand == REGISTER_DEVICE )
      {
         RegisterDeviceResponseParser registerDeviceResponse;
         ret = registerDeviceResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            registerDeviceResponse.GetRegisterDeviceResponse( m_registerDeviceResp );
         }
      }
      else if ( m_currentCommand == UPDATE_LATEST_MAP )
      {
         // Same structure of the response like addCustomer command, so use that class to parse this response
         // We are only interested in finding the response code
         AddCustomerResponseParser addCustomerResp;
         ret = addCustomerResp.Init( serverResponseXml );
         if ( ret == 0 )
         {
            addCustomerResp.GetAddCustomerResponse( m_updateLatestMapResp );
         }

      }
      else if ( m_currentCommand == UPDATE_REGISTRATION )
      {
         // Same structure of the response like register device
         // Use register device response parser class
         RegisterDeviceResponseParser registerDeviceResponse;
         ret = registerDeviceResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            registerDeviceResponse.GetRegisterDeviceResponse( m_updateRegistrationResp );
         }
      }
      else if ( m_currentCommand == UPGRADE_PRODUCT )
      {
         // Same structure of the response like register device
         // Use register device response parser class
         RegisterDeviceResponseParser registerDeviceResponse;
         ret = registerDeviceResponse.Init( serverResponseXml );
         if ( ret == 0 )
         {
            registerDeviceResponse.GetRegisterDeviceResponse( m_upgradeProductResp );
         }
      }
      else if ( m_currentCommand == RESOLVE_SITE )
      {
         // Parse the resolve site response
         ResolveSiteResponseParser resolveSiteParser;
         ret = resolveSiteParser.Init( serverResponseXml );
         if ( ret == 0 )
         {
            resolveSiteParser.GetResolveSiteResponse( m_resolveSiteResp );
         }
      }
      disconnect(m_networkReply, SIGNAL(readyRead()), this, SLOT(readyRead()));
      disconnect(m_networkReply, SIGNAL(finished()), this, SLOT(commandFinished()));
      // Here we can emit also the signal having the response struct as a parameter
      emit ServerReplyFinish_signal();
      // emit ServerReplyFinish_signal(m_serverResponse.code.toInt());
      // Prepare those variables for next server request
      // If we delete this here will crash !!!
      // delete m_networkReply;
      // m_networkReply = NULL;
      m_fullReply.clear();
   }

   void QueryManager::GetReply_ADD_CUSTOMER( AddCustomerResp_T& servResp )
   {
      servResp = m_addCustomerResp;
   }

   void QueryManager::GetReply_AUTHENTICATE( AuthenticateResp_T& servResp )
   {
      servResp = m_authenticateResp;
   }

   void QueryManager::GetReply_CHECK_LATEST_MAP( CheckLatestMapResponse_T& servResp )
   {
      servResp = m_checkLatestMapResp;
   }

   void QueryManager::GetReply_CHECK_MAP_VERSION( CheckMapVersionResp_T& servResp )
   {
      servResp = m_checkMapVersionResp;
   }

   void QueryManager::GetReply_GET_CLIENT_INFO( GetClientInfoResponse_T& servResp )
   {
      servResp = m_getClientInfoResp;
   }

   void QueryManager::GetReply_GET_CONTENT_LIST( ContenList_T& servResp )
   {
      servResp = m_getContentListResp;
   }

   void QueryManager::GetReply_GET_CONTENT_URL( GetContentUrlResponse_T& servResp )
   {
      servResp = m_getContentUrlResp;
   }

   void QueryManager::GetReply_GET_FTP_UPLOAD_URL( GetFtpUploadUrlResp_T& servResp )
   {
      servResp = m_getFtpUploadUrlResp;
   }

   void QueryManager::GetReply_GET_REGISTRATION_LIST( GetRegistrationList_T& servResp )
   {
      servResp = m_getRegistrationListResp;
   }

   void QueryManager::GetReply_GET_SOFTWARE_VERSION( GetSoftwareVersion_T& servResp )
   {
      servResp = m_getSoftwareVersionResp;
   }

   void QueryManager::GetReply_GET_SOFTWARE_VERSION2( GetSoftwareVersion2_T& servResp )
   {
      servResp = m_getSoftwareVersion2Resp;
   }

   void QueryManager::GetReply_GET_VOUCHER_INFO( GetVoucherInfoResp_T& servResp )
   {
      servResp = m_getVoucherInfoResp;
   }

   void QueryManager::GetReply_REDEEM_VOUCHER( RedeemVoucherResp_T& servResp )
   {
      servResp = m_redeemVoucherResp;
   }

   void QueryManager::GetReply_REGISTER_ADDITIONAL_CONTENT( RegisterAdditionalContentResp_T& servResp )
   {
      servResp = m_registerAdditionalContentResp;
   }

   void QueryManager::GetReply_REGISTER_DEVICE( RegisterDeviceResponse_T& servResp )
   {
      servResp = m_registerDeviceResp;
   }

   void QueryManager::GetReply_UPDATE_LATEST_MAP( AddCustomerResp_T& servResp )
   {
      servResp = m_updateLatestMapResp;
   }

   void QueryManager::GetReply_UPDATE_REGISTRATION( RegisterDeviceResponse_T& servResp )
   {
      servResp = m_updateRegistrationResp;
   }

   void QueryManager::GetReply_UPGRADE_PRODUCT( RegisterDeviceResponse_T& servResp )
   {
      servResp = m_upgradeProductResp;
   }

   void QueryManager::GetReply_RESOLVE_SITE( ResolveSiteResp_T& servResp )
   {
      servResp = m_resolveSiteResp;
   }
}; // namespace FreshServices
