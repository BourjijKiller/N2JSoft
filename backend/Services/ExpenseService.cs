
using DomainServices;

using DTO;

using Services;

namespace WebApi.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseDomainService _expenseDomainService;

        public ExpenseService(IExpenseDomainService expenseDomainService)
        {
            _expenseDomainService = expenseDomainService;
        }

        public IEnumerable<ExpenseDTO> GetAll()
            => _expenseDomainService.GetAll();

        public ExpenseDTO GetById(Guid id)
            => _expenseDomainService.GetById(id);

        public async Task<Guid> Create(AddExpenseDTO expenseToCreate)
            => await _expenseDomainService.Create(expenseToCreate);
    }
}
