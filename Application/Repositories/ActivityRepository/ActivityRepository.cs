using Application.Context;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.ActivityRepository
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IDataContext _context;
        public ActivityRepository(IDataContext context)
        {
            _context = context;
        }
        public void Add(Activity item)
        {
            _context.Activities.Add(item);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Activity>> GetAll()
        {
            return await _context.Activities.ToListAsync();
        }

        public Task<Activity> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task Update(Activity item)
        {
            throw new NotImplementedException();
        }
    }
}