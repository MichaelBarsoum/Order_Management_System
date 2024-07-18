using Order_Management_System.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Repository.OrderState
{
    public interface IOrderState
    {
        void HandleState(Order order);
    }
}
