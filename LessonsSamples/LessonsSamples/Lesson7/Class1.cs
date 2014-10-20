using System;

namespace ClassLibrary1.Lesson7
{
   

    public class PerDiemMealExpenses : MealExpenses
    {
        public int GetTotal()
        {
            // return the per diem default
            throw new NotImplementedException();
        }
    }

    class MealExpensesNotFound : Exception
    {
    }

    public class MealExpenses
    {
        public int GetTotal()
        {
            throw new NotImplementedException();
        }
    }

    public class DeviceShutdownException : Exception
    {
    }

    public static class Logger
    {
        public static void Log(string p0)
        {
            throw new System.NotImplementedException();
        }

        public static void Log(DeviceShutdownException p0)
        {
            throw new NotImplementedException();
        }
    }

    class Record
    {
        public int GetStatus()
        {
            throw new System.NotImplementedException();
        }
    }

    public class DeviceHandle
    {
        public static DeviceHandle INVALID;
    }
}