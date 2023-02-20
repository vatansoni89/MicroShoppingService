using Order.Commands.Interfaces;
using Order.Models;

namespace Order.Commands.Handlers
{
    public class OrderCommand : IOrderCommand
    {
        AppDbContext _db;
        public OrderCommand(AppDbContext db)
        {
            _db = db;
        }
        public async Task<OrderCommandModel> AddOrderAsync(OrderCommandModel model)
        {
            var order = new Order.Models.Order
            {
                CustomerId= model.CustomerId,
                ProductName = model.ProductName,
                Description = model.Description,
                IsOrderConfirmed = model.IsOrderConfirmed,
                Price = model.Price
            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            model.OrderId= order.OrderId;
            return model;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = _db.Orders.Find(id);
            if (order!=null)
            {
                _db.Remove(order);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateOrderAsync(OrderCommandModel model)
        {
            try
            {
                var order = new Order.Models.Order
                {
                    OrderId = model.OrderId,
                    ProductName = model.ProductName,
                    Description = model.Description,
                    IsOrderConfirmed = model.IsOrderConfirmed,
                    Price = model.Price
                };

                _db.Orders.Update(order);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ConfirmOrderAsync(OrderCommandModel model)
        {
            try
            {
                var order = new Order.Models.Order
                {
                    OrderId = model.OrderId,
                    ProductName = model.ProductName,
                    Description = model.Description,
                    IsOrderConfirmed = model.IsOrderConfirmed,
                    Price = model.Price
                };

                var existingOrder = _db.Orders
                    .FirstOrDefault(x=> x.CustomerId == model.CustomerId &&
                x.OrderId == model.OrderId);
                existingOrder.IsOrderConfirmed= model.IsOrderConfirmed;

                _db.Orders.Update(existingOrder);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
