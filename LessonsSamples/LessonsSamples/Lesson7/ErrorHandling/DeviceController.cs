using System;
using ClassLibrary1.Lesson7;

namespace LessonsSamples.Lesson7.ErrorHandling
{
    public class DeviceController
    {
        private object DEV1;
        private Record record;
        private int DEVICE_SUSPENDED;

        public void SendShutDown()
        {
            DeviceHandle handle = GetHandle(DEV1);
            // Check the state of the device
            if (handle != DeviceHandle.INVALID)
            {
                // Save the device status to the record field
                RetrieveDeviceRecord(handle);
                // If not suspended, shut down
                if (record.GetStatus() != DEVICE_SUSPENDED)
                {
                    PauseDevice(handle);
                    ClearDeviceWorkQueue(handle);
                    CloseDevice(handle);
                }
                else
                {
                    Logger.Log("Device suspended.  Unable to shut down");
                }
            }
            else
            {
                Logger.Log("Invalid handle for: " + DEV1);
            }
        }

        private void CloseDevice(DeviceHandle handle)
        {
            throw new NotImplementedException();
        }

        private void ClearDeviceWorkQueue(DeviceHandle handle)
        {
            throw new NotImplementedException();
        }

        private void PauseDevice(DeviceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void SendShutDown_()
        {
            try
            {
                TryToShutDown();
            }
            catch (DeviceShutdownException e)
            {
                Logger.Log(e);
            }
        }

        private void TryToShutDown()
        {
            DeviceHandle handle = GetHandle(DEV1);
            RetrieveDeviceRecord(handle);

            PauseDevice(handle);
            ClearDeviceWorkQueue(handle);
            CloseDevice(handle);
        }

        private void RetrieveDeviceRecord(DeviceHandle handle)
        {
            throw new NotImplementedException();
        }

        private DeviceHandle GetHandle(object dev1)
        {
            throw new NotImplementedException();
        }
    }
}