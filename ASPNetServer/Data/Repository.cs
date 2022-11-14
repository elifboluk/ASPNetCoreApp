using Microsoft.EntityFrameworkCore;

namespace ASPNetServer.Data

{   
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
