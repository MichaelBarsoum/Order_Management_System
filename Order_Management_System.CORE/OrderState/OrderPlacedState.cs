using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository.OrderState
{
    public class OrderPlacedState :IOrderState
    {
        private readonly Order _order;

        public OrderPlacedState(Order order)
        {
            _order = order;
        }
        public void HandleState(Order order)
        {
            order.State = new OrderPlacedState(_order);
        }
    }


}
