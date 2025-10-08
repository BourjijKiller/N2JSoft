using Repository.Entities;

namespace Repository
{
    public interface IExpenseRepository
    {
        public IEnumerable<Expense> GetAll();

        public Expense? GetById(Guid id);

        public Task<Guid> Create(Expense expenseToCreate);
    }
}
