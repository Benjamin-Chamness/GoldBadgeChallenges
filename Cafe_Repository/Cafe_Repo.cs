using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Repository
{
    public class Cafe_Repo
    {
        private List<Cafe_Menu> _orderList = new List<Cafe_Menu>();
        public void AddOrderToList(Cafe_Menu order)
        {
            _orderList.Add(order);
        }

        public List<Cafe_Menu> GetOrderList()
        {
            return _orderList;
        }

        public bool DeleteOrder(Cafe_Menu order)
        {
            int initialCount = _orderList.Count;
            _orderList.Remove(order);
            if(initialCount > _orderList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Cafe_Menu GetOrderID(int orderId)
        {
            foreach (Cafe_Menu itemOrdered in _orderList)
            {
                if(itemOrdered.MealNumber == orderId)
                {
                    return itemOrdered;
                }
            }
            return null;
        }
    }
}

        
