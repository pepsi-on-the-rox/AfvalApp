using Models;
using DataContext;
using Microsoft.EntityFrameworkCore;

namespace DataAccessService
{
    public class DAS
    {
        // Dit word de laag waarin alle SQL commands komen.
        // (Ofc dan met Entityframework.)
        // Dus hier word de create aangemaakt en niet in de controller.
        // Betekend dus dat de controller naar deze class verwijst.
        private readonly ChillApplicationContext _context;

        public DAS(ChillApplicationContext context)
        {
                this._context = context;
        }

        public async Task<List<Operator>?> GetOperators()
        {
            if(_context?.Operator == null) 
                return null;

            return await _context.Operator.ToListAsync();
        }
    }
}