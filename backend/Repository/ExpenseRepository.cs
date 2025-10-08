
using Repository.Entities;

namespace Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetAll()
            => _context.Expenses;

        public Expense? GetById(Guid id)
            => _context.Expenses.SingleOrDefault(x => x.Id == id);

        public async Task<Guid> Create(Expense expenseToCreate)
        {
            _context.Expenses.Add(expenseToCreate);
            await _context.SaveChangesAsync();

            return expenseToCreate.Id;
        }
    }
}
