using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public interface ICardsRepository
    {
        CardModel? FindCardById(int cardId);
        CardModel? FindCardByCode(string cardCode);
        IEnumerable<CardModel> FindCardsByUserId(int userId);
    }
}