using System.Threading.Tasks;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class DeleteAppeal
    {
        private readonly ApplicationDbContext _ctx;

        public DeleteAppeal(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var appeal = await _ctx.Appeals.FirstOrDefaultAsync(x => x.Id == id);
            
            if (appeal == null)
                return false;

            _ctx.Appeals.Remove(appeal);
            _ctx.SaveChanges();
            return true;
        }
    }
}
