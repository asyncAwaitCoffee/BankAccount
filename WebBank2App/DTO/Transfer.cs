
namespace WebBank2App.DTO
{
    public record class Transfer(int AccountIdFrom, decimal Amount, int AccountIdTo = -1, string CardCodeTo = "");
}
