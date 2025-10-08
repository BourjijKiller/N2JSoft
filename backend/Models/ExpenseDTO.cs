namespace DTO
{
    /// <summary>
    /// On utilise un type record ici, car cela présente des avantages par rapport à une classe
    /// Égalité par valeur, Immutabilité par défaut, pas de redéfinition (Equals(), ToString())
    /// </summary>
    public record ExpenseDTO
    {
        public required Guid Id { get; init; }

        public required string Description { get; init; }

        public required decimal Amount { get; init; }

        public required string Categorie { get; init; }

        public required DateTime DateCreation { get; init; }

        public DateTime? DateModification { get; init; }
    }

    public record AddExpenseDTO
    {
        public required string Description { get; init; }

        public required decimal Amount { get; init; }

        public required string Categorie { get; init; }
    }
}
