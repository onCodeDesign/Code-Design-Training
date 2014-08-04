namespace ConsoleApplication1.ChainOfResponsibility
{
    class FileManager2
    {
        private readonly IRequestHandler handler;

        public FileManager2 ()
        {
            handler = new CreateNew
            {
                Successor = new FileExistsAndOverwriteNotRequested
                {
                    Successor = new OverwriteWithNewFormat
                    {
                        Successor = new OverwriteWithSameFormat
                        {
                            Successor = new CannotOverwrite()
                        }
                    }
                }
            };
        }

        public int CreateFile(Request createFileRequest)
        {
            return handler.Handle(createFileRequest);
        }
    }
}