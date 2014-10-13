using System;
using System.Data.SqlClient;

namespace AbstractFactory
{
    interface IWindow
    { }

    interface IScrollBar
    {
    }

    interface IWidgetFactory
    {
        object CreateWidget<T>();
    }

    class MotifWidgetFactory : IWidgetFactory
    {
        public object CreateWidget<T>()
        {
            //return new Motif
            throw new NotImplementedException();
        }
    }
}