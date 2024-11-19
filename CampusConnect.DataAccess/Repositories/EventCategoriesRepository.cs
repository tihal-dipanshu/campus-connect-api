using CampusConnect.DataAccess.DataModels;
using CampusConnect.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampusConnect.DataAccess.Repositories
{
    public class EventCategoriesRepository : Repository<EventCategory>, IEventCategoriesRepository
    {
        public EventCategoriesRepository(CampusConnectContext dbContext) : base(dbContext)
        {
        }

        public async Task<EventCategory> GetCategoryById(int categoryId)
        {
            return await Context.EventCategories.FindAsync(categoryId);
        }

        public async Task<EventCategory> GetCategoryByName(string categoryName)
        {
            return await Context.EventCategories.FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }

        public async Task<IEnumerable<EventCategory>> GetAllCategories()
        {
            return await Context.EventCategories.ToListAsync();
        }

        public async Task<bool> IsCategoryNameTaken(string categoryName)
        {
            return await Context.EventCategories.AnyAsync(c => c.CategoryName == categoryName);
        }

        public async Task<EventCategory> CreateCategory(EventCategory category)
        {
            Context.EventCategories.Add(category);
            await Context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateCategory(EventCategory category)
        {
            var existingCategory = await Context.EventCategories.FindAsync(category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;
                // Add any other properties that need updating
                Context.EventCategories.Update(existingCategory);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await Context.EventCategories.FindAsync(categoryId);
            if (category != null)
            {
                Context.EventCategories.Remove(category);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventCategory>> SearchCategories(string searchTerm)
        {
            return await Context.EventCategories
                .Where(c => c.CategoryName.Contains(searchTerm))
                .ToListAsync();
        }
    }
}
