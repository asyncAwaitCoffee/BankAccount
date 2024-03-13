using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public interface ITransfersRepository
    {
        IEnumerable<TransferModel> FindTransfersByAccountIdFrom(int accountIdFrom);
        IEnumerable<TransferModel> FindTransfersByAccountIdTo(int accountIdTo);
        TransferModel? FindTratnsferById(int transferId);
    }
}