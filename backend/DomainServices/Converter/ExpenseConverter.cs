using DTO;

using Repository.Entities;

namespace DomainServices.Converter
{
    public static class ExpenseConverter
    {
        public static ExpenseDTO Convert(this Expense entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new ExpenseDTO
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Categorie = entity.Categorie,
                Description = entity.Description,
                DateCreation = entity.DateCreation,
                DateModification = entity.DateModification
            };
        }

        public static Expense Convert(this AddExpenseDTO dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Expense
            {
                Amount = dto.Amount,
                Categorie = dto.Categorie,
                Description = dto.Description
            };
        }

        public static IEnumerable<ExpenseDTO> Convert(this IEnumerable<Expense> entities)
            => entities.Select(x => x.Convert());
    }
}
