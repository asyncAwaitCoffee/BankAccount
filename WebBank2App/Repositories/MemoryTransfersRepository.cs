using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryTransfersRepository : ITransfersRepository
    {
        private List<TransferModel> _transfers = [
                new(1, 2, 100, new DateTime(2024, 1, 11, 23, 12, 0)),
                new(2, 3, 20, new DateTime(2024, 3, 2, 12, 59, 25)),
                new(3, 4, 350, new DateTime(2024, 12, 23, 9, 19, 11)),
                new(4, 5, 85, new DateTime(2024, 8, 16, 22, 21, 28)),
                new(5, 1, 800, new DateTime(2024, 7, 9, 19, 56, 56)),
                new(4, 2, 140, new DateTime(2024, 5, 12, 15, 17, 42)),
                new(3, 1, 15, new DateTime(2024, 2, 10, 13, 33, 2)),
            ];

        public IEnumerable<TransferModel> FindTransfersByAccountIdFrom(int accountIdFrom)
        {
            return _transfers.FindAll(t => t.AccountIdFrom == accountIdFrom);
        }
        public IEnumerable<TransferModel> FindTransfersByAccountIdTo(int accountIdTo)
        {
            return _transfers.FindAll(t => t.AccountIdTo == accountIdTo);
        }
        public TransferModel? FindTransferById(int transferId)
        {
            return _transfers.FirstOrDefault(t => t.Id == transferId);
        }
        public void AddTransfer(TransferModel transfer)
        {
            _transfers.Add(transfer);
        }

    }
}
