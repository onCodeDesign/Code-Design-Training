using System.Collections.Generic;

namespace LessonsSamples.Lesson6
{
    interface IEntityFieldsReader<T>
    {
        IEnumerable<string> GetFields();
        void SetFieldValue(string field, string value);
        T GetEntity();
    }
}