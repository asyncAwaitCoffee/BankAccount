using WebBank2App.Models;

namespace WebBank2App.Repositories
{
    public class MemoryCardsRepository : ICardsRepository
    {
        private List<CardModel> _cards = [
                new("0000 0000 0000 0000", 1, 1, 1, "Visa", new DateOnly(2030, 1, 1)),
                new("1111 1111 1111 1111", 2, 1, 1, "Arca", new DateOnly(2031, 11, 1)),
                new("2222 2222 2222 2222", 3, 2, 1, "Maestro", new DateOnly(2029, 5, 1)),
                new("3333 3333 3333 3333", 4, 3, 1, "UnionPay", new DateOnly(2035, 4, 1)),
                new("4444 4444 4444 4444", 5, 3, 1, "JCB", new DateOnly(2038, 7, 1)),
            ];

        public CardModel? FindCardById(int cardId)
        {
            return _cards.Find(c => c.Id == cardId);
        }

        public CardModel? FindCardByCode(string cardCode)
        {
            return _cards.Find(c => c.Code == cardCode);
        }

        public IEnumerable<CardModel> FindCardsByUserId(int userId)
        {
            return _cards.FindAll(c => c.UserId == userId);
        }
    }
}
