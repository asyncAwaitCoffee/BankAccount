namespace WebBank2App.Models
{
    public record class TransferModel(int AccountIdFrom, int AccountIdTo, decimal Amount, DateTime DateTime)
    {
        private static int _idCounter = 0;
        public int Id { get; init; } = ++_idCounter;
    }
}
