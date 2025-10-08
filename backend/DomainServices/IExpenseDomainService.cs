using DTO;

namespace DomainServices
{
    public interface IExpenseDomainService
    {
        IEnumerable<ExpenseDTO> GetAll();

        ExpenseDTO GetById(Guid id);

        Task<Guid> Create(AddExpenseDTO expenseToCreate);
    }
}
