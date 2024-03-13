
namespace WebBank2App.DTO
{
    public record class TransferDTO(int AccountIdFrom, decimal Amount, int AccountIdTo = -1, string CardCodeTo = "");
}
