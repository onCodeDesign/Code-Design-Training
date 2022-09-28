using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonsSamples.Lesson5.ISP.Door
{
    public interface IDoor
    {
        void Open();
        void Close();
        bool IsOpened();
    }
}
