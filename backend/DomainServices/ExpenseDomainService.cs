using DomainServices.Converter;
using DomainServices.Exceptions;
using DomainServices.Validator;

using DTO;

using Repository;

namespace DomainServices
{
    public class ExpenseDomainService : IExpenseDomainService
    {
        private readonly IExpenseRepository _expensesRepository;
        private readonly ExpenseValidator _expenseValidator;

        public ExpenseDomainService(IExpenseRepository expensesRepository, ExpenseValidator expenseValidator)
        {
            _expensesRepository = expensesRepository;
            _expenseValidator = expenseValidator;
        }

        public IEnumerable<ExpenseDTO> GetAll()
            => _expensesRepository.GetAll().Convert();

        public ExpenseDTO GetById(Guid id)
            => _expensesRepository.GetById(id)?.Convert() ?? throw new Exception($"Expense with identifier {id} was not found.");

        public async Task<Guid> Create(AddExpenseDTO expenseToCreate)
        {
            var entity = expenseToCreate.Convert();
            // Validators
            var validationResults = _expenseValidator.Validate(entity);

            if (!validationResults.IsValid)
            {
                throw new BusinessException(validationResults.Errors.Select(x => x.ErrorMessage));
            }

            return await _expensesRepository.Create(expenseToCreate.Convert());
        }
    }
}
