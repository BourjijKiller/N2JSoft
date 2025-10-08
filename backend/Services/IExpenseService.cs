using DTO;

namespace Services
{
    public interface IExpenseService
    {
        public IEnumerable<ExpenseDTO> GetAll();

        public ExpenseDTO GetById(Guid id);

        public Task<Guid> Create(AddExpenseDTO expenseToCreate);
    }
}
