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


        // Methodes underhere are Methodes for the Operator model.
        public async Task<List<Operator>?> GetOperators()
        {
            if(_context?.Operator == null) 
                return null;

            return await _context.Operator.ToListAsync();
        }

        public async Task<Operator?> GetSpecificOperator(int? id)
        {
            if (_context?.Operator == null)
                return null;

            var @operator = await _context.Operator.FirstOrDefaultAsync(m => m.Id == id);

            return @operator;
        }

        public async Task<Operator?> CreateOperator(Operator @operator)
        {
            if (_context?.Operator == null)
                return null;

            await _context.AddAsync(@operator);
            await _context.SaveChangesAsync();
            return @operator;
        }

        public async Task<Operator?> EditOperator(Operator @operator)
        {
            if (_context?.Operator == null)
                return null;

            _context.Update(@operator);
            await _context.SaveChangesAsync();

            return @operator;
        }

        public async Task<bool> DeleteOperator(Operator @operator)
        {
            if (_context?.Operator == null)
                return false;

            _context.Operator.Remove(@operator);
            await _context.SaveChangesAsync();

            return true;
        }
        // End of Operator Methodes

        //Methodes underhere are Methodes for .. Model

        //End of .. Methodes
    }
}