namespace ConsoleApplication1.ChainOfResponsibility
{
    internal class FileExistsAndOverwriteNotRequested : RequestHandler
    {
        protected override bool CanHandle(Request request)
        {
            return
                FileExists(request.FileName) &&
                request.OperationCode != "11";
        }

        protected override int HandleInternal(Request request)
        {
            return ErrorCodes.FileExists;
        }
    }

    internal class OverwriteWithSameFormat : RequestHandler
    {
        protected override bool CanHandle(Request request)
        {
            return
                FileExists(request.FileName) &&
                request.OperationCode == "11" &&
                Resources.GetFileMetadata(request.EntityType) != null;
        }

        protected override int HandleInternal(Request request)
        {
            // ... real implementation here ...

            return ErrorCodes.Success;
        }
    }

    internal class OverwriteWithNewFormat : RequestHandler
    {
        protected override bool CanHandle(Request request)
        {
            return
                FileExists(request.FileName) &&
                request.OperationCode == "11" &&
                Resources.GetFileMetadata(request.EntityType) == null &&
                !ExistsFilesOfSameType(request.EntityType, request.FileName);
        }

        protected override int HandleInternal(Request request)
        {
            FileMetadata metadata = BuildMetadata(request.Metadata);
            OverwriteFileWithNewFormat(request, metadata);

            Resources.CacheMetadata(metadata, request.EntityType);

            return ErrorCodes.Success;
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
    }

    internal class CannotOverwrite : RequestHandler
    {
        protected override bool CanHandle(Request request)
        {
            return true;
        }

        protected override int HandleInternal(Request request)
        {
            return ErrorCodes.CannotOverwrite;
        }
    }

    internal class CreateNew : RequestHandler
    {
        public CreateNew()
        {
        }

        public CreateNew(IRequestHandler successor) : base(successor)
        {
        }

        protected override bool CanHandle(Request request)
        {
            return
                !FileExists(request.FileName);
        }

        protected override int HandleInternal(Request request)
        {
            FileMetadata cachedMetadata = Resources.GetFileMetadata(request.EntityType);
            if (cachedMetadata != null)
            {
                FileMetadata requestMetadata = BuildMetadata(request.Metadata);
                if (cachedMetadata != requestMetadata)
                    return ErrorCodes.DifferentMetadata;

                CreateNewFile(request, cachedMetadata);
            }
            else
            {
                var metadata = BuildMetadata(request.Metadata);
                CreateNewFile(request, metadata);

                Resources.CacheMetadata(metadata, request.EntityType);
            }

            return ErrorCodes.Success;
        }

        private void CreateNewFile(Request request, FileMetadata cachedMetadata)
        {
            // ... real implementation here ...
        }

        private FileMetadata BuildMetadata(byte[] metadata)
        {
            // ... real implementation here ...
            return new FileMetadata();
        }
    }
}