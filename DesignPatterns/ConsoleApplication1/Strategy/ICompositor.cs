namespace ConsoleApplication1.Strategy
{
    public interface ICompositor
    {
        int Compose(Configuration configuration, int count, int lineWidth, int breaks);
    }

    class SimpleCompositor : ICompositor
    {
        public int Compose(Configuration configuration, int count, int lineWidth, int breaks)
        {
            throw new System.NotImplementedException();
        }
    }

    class TeXCompositor : ICompositor
    {
        public int Compose(Configuration configuration, int count, int lineWidth, int breaks)
        {
            throw new System.NotImplementedException();
        }
    }

    class ArrayCompositor : ICompositor
    {
        public int Compose(Configuration configuration, int count, int lineWidth, int breaks)
        {
            throw new System.NotImplementedException();
        }
    }
}