using System;
using System.Collections.Generic;
using System.Linq;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.EF
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly OrderContext ctx;

        public EFOrderRepository() : this(new OrderContext())
        {

        }

        public EFOrderRepository(OrderContext ctx)
        {
            this.ctx = ctx;
        }

        public bool Add(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            if(item.OrderId <= 0)
                return false;

            try
            {
                var ordine = ctx.Orders.Find(item.OrderId);

                if (ordine != null)
                    ctx.Orders.Remove(ordine);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Order> FetchAll()
        {
            try
            {
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }
        }

        public Order GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Orders.Find(id);
        }

        public bool Update(Order item)
        {
            if (item == null)
                return false;

            try
            {
                ctx.Orders.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
