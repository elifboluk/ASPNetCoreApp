using Microsoft.EntityFrameworkCore;

namespace ASPNetServer.Data

{
    public static class OrderRepository
    {
        public async static Task<List<Order>> GetOrdersAsync()
        {
            using (var db = new AppDBContext()){
                return await db.Orders.ToListAsync();
            }
        }

        public async static Task<Order> GetOrdersByIdAsync( int orderId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Orders.FirstOrDefaultAsync(Order => Order.OrderId == orderId);
            }
        }


        public async static Task<bool> CreateOrdersAsync(Order orderToCreate)
        {
            using (var db=new AppDBContext())
            {
                try
                {
                    await db.Orders.AddAsync(orderToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> UpdateOrdersAsync(Order orderToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Orders.Update(orderToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> DeleteOrdersAsync( int orderId )
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Order orderToDelete = await GetOrdersByIdAsync(orderId);
                    db.Remove(orderToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }





    }
    public static class ProductRepository
    {
        public async static Task<List<Product>> GetProductsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Products.ToListAsync();
            }
        }

        public async static Task<Product> GetProductsByIdAsync(int productId)
        {
            using (var db = new AppDBContext())
            {
                return await db.Products.FirstOrDefaultAsync(Product => Product.ProductId == productId);
            }
        }

        public async static Task<bool> CreateProductsAsync(Product productToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Products.AddAsync(productToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> UpdateProductsAsync(Product productToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.Products.Update(productToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> DeleteProductsAsync(int productId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    Product productToDelete = await GetProductsByIdAsync(productId);
                    db.Remove(productToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
    public static class OrderDetailRepository
    {
        public async static Task<List<OrderDetail>> GetOrderDetailsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.OrderDetails.ToListAsync();
            }
        }

        public async static Task<OrderDetail> GetOrderDetailsByIdAsync(int orderDetailId)
        {
            using (var db = new AppDBContext())
            {
                return await db.OrderDetails.FirstOrDefaultAsync(OrderDetail => OrderDetail.OrderDetailId == orderDetailId);
            }
        }

        public async static Task<bool> CreateOrderDetailsAsync(OrderDetail orderDetailToCreate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.OrderDetails.AddAsync(orderDetailToCreate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> UpdateOrderDetailsAsync(OrderDetail orderDetailToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    db.OrderDetails.Update(orderDetailToUpdate);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public async static Task<bool> DeleteOrderDetailsAsync(int orderDetailId)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    OrderDetail orderDetailToDelete = await GetOrderDetailsByIdAsync(orderDetailId);
                    db.Remove(orderDetailToDelete);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

    }






}
