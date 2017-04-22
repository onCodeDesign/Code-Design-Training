using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Contracts.Sales.Services;

namespace ConsoleHost.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        public IHttpActionResult PlaceSellLimitOrder(string securityCode, decimal sellingPrice, DateTime validUntil)
        {
            ordersService.PlaceSellLimitOrder(securityCode, sellingPrice, validUntil);
            return Ok();
        }

        public IHttpActionResult PlaceBuyLimitOrder(string securityCode, decimal buyingPrice, DateTime validUntil)
        {
            ordersService.PlaceBuyLimitOrder(securityCode, buyingPrice, validUntil);
            return Ok();
        }

        public IEnumerable<LimitOrder> GetLimitOrders()
        {
            return ordersService.GetLimitOrders();
        }
    }
}