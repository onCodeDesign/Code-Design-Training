using System;
using System.Collections.Generic;

namespace LessonsSamples.Lesson6.DI_AndDisposable
{
    internal class Order
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
        public string Header { get; set; }
        public Status Status { get; set; }
    }

    internal class OrderLine
    {
        public decimal Ammount { get; set; }
        public Status Status { get; set; }
        public int OrderId { get; set; }
    }

    internal enum Status
    {
        PreCalculated,
        Reviewed
    }
}