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
            if (_context?.Operator == null)
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
        //public async Task<List<Issue>?> GetIssue()
        //{
        //    if (_context?.Issue == null)
        //        return null;

        //    return await _context.Issue.ToListAsync();
        //}
        public async Task<List<Issue>?> GetIssue()
        {
            if (_context?.Issue == null)
                return null;

            return await _context.Issue
                .Include(issue => issue.Operator)
                .Include(issue => issue.Label)
                .ToListAsync();
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

        //Methodes underhere are Methodes for Label Model
        public async Task<List<Label>?> GetLabel()
        {
            if (_context?.Label == null)
                return null;

            return await _context.Label.ToListAsync();
        }

        public async Task<Label?> GetSpecificLabel(int? id)
        {
            if (_context?.Label == null)
                return null;

            var @label = await _context.Label.FirstOrDefaultAsync(m => m.Id == id);

            return @label;
        }

        public async Task<Label?> CreateLabel(Label @label)
        {
            if (_context?.Label == null)
                return null;

            await _context.AddAsync(@label);
            await _context.SaveChangesAsync();
            return @label;
        }

        public async Task<Label?> EditLabel(Label @label)
        {
            if (_context?.Label == null)
                return null;

            _context.Update(@label);
            await _context.SaveChangesAsync();

            return @label;
        }

        public async Task<bool> DeleteLabel(Label @label)
        {
            if (_context?.Label == null)
                return false;

            _context.Label.Remove(@label);
            await _context.SaveChangesAsync();

            return true;
        }
        //End of Label Methodes
    }
}