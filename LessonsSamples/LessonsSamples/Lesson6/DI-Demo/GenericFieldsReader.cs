using System;
using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    class GenericFieldsReader<T> : IEntityFieldsReader<T>
    {
        public IEnumerable<string> GetFields()
        {
            throw new NotImplementedException();
        }

        public void SetFieldValue(string name, string value)
        {
            throw new NotImplementedException();
        }

        public T GetEntity()
        {
            throw new NotImplementedException();
        }
    }
}