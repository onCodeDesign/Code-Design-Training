namespace Contracts.Sales
{
    public class SalesOrder
    {
        public int OrderId { get; set; }
        public OrderResultState State { get; set; }
        public string Message { get; set; }
    }

    public enum OrderResultState
    {
        /// <summary>
        /// Technical unknown error
        /// </summary>
        Error,

        /// <summary>
        /// Order placement was successful
        /// </summary>
        Placed,

        /// <summary>
        /// Order wasn't placed because of business rules
        /// </summary>
        Failure,

        /// <summary>
        /// The order request was invalid.
        /// The order was not placed
        /// </summary>
        Invalid
    }
}