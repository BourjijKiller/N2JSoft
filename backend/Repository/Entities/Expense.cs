namespace Repository.Entities
{
    public record Expense
    {
        public Guid Id { get; set; }

        public required string Description { get; set; }

        public required decimal Amount { get; set; }

        public required string Categorie { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime? DateModification { get; set; }
    }
}
