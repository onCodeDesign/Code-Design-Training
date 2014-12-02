using System;

namespace ConsoleDemo.ChainOfResponsibility
{
    interface IRequestHandler
    {
        int Handle(Request request);

        IRequestHandler Successor { get; set; }
    }

    abstract class RequestHandler : IRequestHandler
    {
        public int Handle(Request request)
        {
            if (CanHandle(request))
                return HandleInternal(request);
            
            if (Successor !=null)
            {
                return Successor.Handle(request);
            }
            
            throw new InvalidOperationException("This handler cannot handle this request");
        }

        protected abstract bool CanHandle(Request request);
        protected abstract int HandleInternal(Request request);

        public IRequestHandler Successor { get; set; }


        protected bool FileExists(string fileName)
        {
            // ... real implementation here ...
            return false;
        }
    }
}