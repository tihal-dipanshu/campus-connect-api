using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CampusConnect.DataAccess.Repositories
{

    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly CampusConnectContext _context;

        public EventCategoryRepository(CampusConnectContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventCategory>> GetAllCategories()
        {
            return await _context.EventCategories.ToListAsync();
        }
        
        public async Task<EventCategory> AddCategory(EventCategory category)
        {
            _context.EventCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<EventCategory> UpdateCategory(EventCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> RemoveCategory(int categoryId)
        {
            var category = await _context.EventCategories.FindAsync(categoryId);
            if (category == null)
                return false;

            _context.EventCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<EventCategory> GetCategoryById(int categoryId)
        {
            return await _context.EventCategories.FindAsync(categoryId);
        }
    }
}