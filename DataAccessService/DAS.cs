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

        //Methodes underhere are Methodes for Issue Model
        public async Task<List<Issue>?> GetIssue()
        {
            if (_context?.Issue == null)
                return null;

            return await _context.Issue.ToListAsync();
        }

        public async Task<Issue?> GetSpecificIssue(int? id)
        {
            if (_context?.Issue == null)
                return null;

            var @issue = await _context.Issue.FirstOrDefaultAsync(m => m.Id == id);

            return @issue;
        }

        public async Task<Issue?> CreateIssue(Issue @issue)
        {
            if (_context?.Issue == null)
                return null;

            await _context.AddAsync(@issue);
            await _context.SaveChangesAsync();
            return @issue;
        }

        public async Task<Issue?> EditIssue(Issue @issue)
        {
            if (_context?.Issue == null)
                return null;

            _context.Update(@issue);
            await _context.SaveChangesAsync();

            return @issue;
        }

        public async Task<bool> DeleteIssue(Issue @issue)
        {
            if (_context?.Issue == null)
                return false;

            _context.Issue.Remove(@issue);
            await _context.SaveChangesAsync();

            return true;
        }
        //End of Issue Methodes

        //Methodes underhere are Methodes for Category Model
        public async Task<List<Category>?> GetCategory()
        {
            if (_context?.Category == null)
                return null;

            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetSpecificCategory(int? id)
        {
            if (_context?.Category == null)
                return null;

            var @category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);

            return @category;
        }

        public async Task<Category?> CreateCategory(Category @category)
        {
            if (_context?.Category == null)
                return null;

            await _context.AddAsync(@category);
            await _context.SaveChangesAsync();
            return @category;
        }

        public async Task<Category?> EditCategory(Category @category)
        {
            if (_context?.Category == null)
                return null;

            _context.Update(@category);
            await _context.SaveChangesAsync();

            return @category;
        }

        public async Task<bool> DeleteCategory(Category @category)
        {
            if (_context?.Category == null)
                return false;

            _context.Category.Remove(@category);
            await _context.SaveChangesAsync();

            return true;
        }
        //End of Category Methodes

        //Methodes underhere are Methodes for ScanObject Model
        public async Task<List<ScanObject>?> GetScanObject()
        {
            if (_context?.ScanObject == null)
                return null;

            return await _context.ScanObject.ToListAsync();
        }

        public async Task<ScanObject?> GetSpecificScanObject(int? id)
        {
            if (_context?.ScanObject == null)
                return null;

            var @scanobject = await _context.ScanObject.FirstOrDefaultAsync(m => m.Id == id);

            return @scanobject;
        }

        public async Task<ScanObject?> CreateScanObject(ScanObject @scanobject)
        {
            if (_context?.ScanObject == null)
                return null;

            await _context.AddAsync(@scanobject);
            await _context.SaveChangesAsync();
            return @scanobject;
        }

        public async Task<ScanObject?> EditScanObject(ScanObject @scanobject)
        {
            if (_context?.ScanObject == null)
                return null;

            _context.Update(@scanobject);
            await _context.SaveChangesAsync();

            return @scanobject;
        }

        public async Task<bool> DeleteScanObject(ScanObject @scanobject)
        {
            if (_context?.ScanObject == null)
                return false;

            _context.ScanObject.Remove(@scanobject);
            await _context.SaveChangesAsync();

            return true;
        }
        //End of ScanObject Methodes
    }
}