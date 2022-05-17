using System;

namespace DataAccess.Repositories
{

    public class ProductsRepository
    {
        private readonly AppdbContext _db;

        public class ProductsRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _db.Orders.Include(x => x.OrderItems).ToListAsync();
        }
        public async Task<Order> GetOrder(Guid id)
        {
            return await _db.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Order> Create(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task Update(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
        }

    }
}