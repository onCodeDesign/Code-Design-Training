namespace ConsoleDemo.ChainOfResponsibility
{
    public class FileManager
    {
        public int CreateFile(Request createFileRequest)
        {
            if (FileExists(createFileRequest.FileName)) //PersonEntity_23432.xml
            {
                bool overwrite = createFileRequest.OperationCode == "11";
                if (overwrite)
                {
                    FileMetadata cachedMetadata = Resources.GetFileMetadata(createFileRequest.EntityType);
                    if (cachedMetadata != null)
                    {
                        OverwriteFileWithSameFormat(createFileRequest, cachedMetadata);
                    }
                    else if (!ExistsFilesOfSameType(createFileRequest.EntityType, createFileRequest.FileName))
                    {
                        var metadata = BuildMetadata(createFileRequest.Metadata);
                        OverwriteFileWithNewFormat(createFileRequest, metadata);

                        Resources.CacheMetadata(metadata, createFileRequest.EntityType);
                    }
                    else
                        return ResultCodes.CannotOverwrite;
                }
                else
                    return ResultCodes.FileExists;
            }
            else
            {
                FileMetadata cachedMetadata = Resources.GetFileMetadata(createFileRequest.EntityType);
                if (cachedMetadata != null)
                {
                    FileMetadata requestMetadata = BuildMetadata(createFileRequest.Metadata);
                    if (cachedMetadata != requestMetadata)
                        return ResultCodes.DifferentMetadata;

                    CreateNewFile(createFileRequest, cachedMetadata);
                }
                else
                {
                    var metadata = BuildMetadata(createFileRequest.Metadata);
                    CreateNewFile(createFileRequest, metadata);

                    Resources.CacheMetadata(metadata, createFileRequest.EntityType);
                }
            }

            return ResultCodes.Success;
        }


        private void CreateNewFile(Request createFileRequest, FileMetadata cachedMetadata)
        {
            // ... real implementation here ...
        }


        private bool ExistsFilesOfSameType(int entityType, string fileName)
        {
            // checks if there are other files for same entity type
            return false;
        }

        private FileMetadata BuildMetadata(byte[] metadata)
        {
            // ... real implementation here ...
            return new FileMetadata();
        }

        private void OverwriteFileWithNewFormat(Request createFileRequest, FileMetadata metadata)
        {
            // ... real implementation here ...
        }

        private void OverwriteFileWithSameFormat(Request createFileRequest, FileMetadata cachedMetadata)
        {
            // ... real implementation here ...
        }

        private bool FileExists(string fileName)
        {
            // ... real implementation here ...
            return false;
        }
    }

    public static class ResultCodes
    {
        public static readonly int Success = 0;
        public static readonly int FileExists = 2;
        public static readonly int CannotOverwrite = 3;
        public static readonly int DifferentMetadata = 4;
    }

    public static class Resources
    {
        public static FileMetadata GetFileMetadata(int entityType)
        {
            // ... real implementation here ...
            return new FileMetadata();
        }

        public static void CacheMetadata(object metadata, int entityType)
        {
            // ... real implementation here ...
        }
    }

    public class FileMetadata
    {
    }

    public class Request
    {
        public string OperationCode { get; set; }
        public int EntityType { get; set; }
        public byte[] Metadata { get; set; }
        public string FileName { get; set; }
    }
}