using System;

namespace ClassLibrary1.Lesson7
{
    public class DeviceController
    {
        private object DEV1;
        private Record record;
        private int DEVICE_SUSPENDED;

        public void SendShutDown()
        {
            DeviceHandle handle = GetHandle(DEV1);
            // Check the state of the device
            if (handle != DeviceHandle.INVALID)
            {
                // Save the device status to the record field
                RetrieveDeviceRecord(handle);
                // If not suspended, shut down
                if (record.GetStatus() != DEVICE_SUSPENDED)
                {
                    PauseDevice(handle);
                    ClearDeviceWorkQueue(handle);
                    CloseDevice(handle);
                }
                else
                {
                    Logger.Log("Device suspended.  Unable to shut down");
                }
            }
            else
            {
                Logger.Log("Invalid handle for: " + DEV1);
            }
        }

        public void SendShutDown_()
        {
            try
            {
                TryToShutDown();
            }
            catch (DeviceShutdownException e)
            {
                Logger.Log(e);
            }
        }

        private void TryToShutDown()
        {
            DeviceHandle handle = GetHandle(DEV1);
            RetrieveDeviceRecord(handle);

            PauseDevice(handle);
            ClearDeviceWorkQueue(handle);
            CloseDevice(handle);
        }

        private void RetrieveDeviceRecord(DeviceHandle handle)
        {
            throw new System.NotImplementedException();
        }

        private DeviceHandle GetHandle(object dev1)
        {
            throw new System.NotImplementedException();
        }

        private void Ex()
        {
            try
            {
                MealExpenses expenses = expenseReport.GetMeals(employee);
                m_total += expenses.getTotal();
            }
            catch (MealExpensesNotFound e)
            {
                m_total += getMealPerDiem();
            }

        }

    }

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