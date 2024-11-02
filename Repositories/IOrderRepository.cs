using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IOrderRepository
    {
        OrderDAO GetOrderById(int id);
        IEnumerable<OrderDAO> GetAllOrders();
        void AddOrder(OrderDAO order);
        void UpdateOrder(OrderDAO order);
        void DeleteOrder(int id);
    }
}
