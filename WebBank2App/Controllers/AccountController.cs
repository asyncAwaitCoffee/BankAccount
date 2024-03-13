using Microsoft.AspNetCore.Mvc;
using WebBank2App.DTO;
using WebBank2App.Models;
using WebBank2App.Repositories;

namespace WebBank2App.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Cards([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] ICardsRepository cardsRepository)
		{
			int userId = 1;
			ViewBag.Client = clientsRepository.FindClientById(userId);
			var cards = cardsRepository.FindCardsByUserId(userId);
			ViewBag.Cards = cards;
            ViewBag.Accounts = cards.Select(c => accountsRepository.FindAccountById(c.AccountId));

            return View();
		}
        public IActionResult Card([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] ICardsRepository cardsRepository,
                             [FromServices] ITransfersRepository transfersRepository,
                             int cardId)
        {
            int userId = 1;
            CardModel card;
            if (cardId < 0)
            {
                card = cardsRepository.FindCardsByUserId(userId).FirstOrDefault();
            } else
            {
                card = cardsRepository.FindCardById(cardId);
            }
            var account = accountsRepository.FindAccountById(card.AccountId);
            var transfersHistoryFrom = transfersRepository.FindTransfersByAccountIdFrom(account.Id);
            var transfersHistoryTo = transfersRepository.FindTransfersByAccountIdTo(account.Id);
            var client = clientsRepository.FindClientById(card.UserId);

            return Json(new { card, account, client, transfersHistoryFrom, transfersHistoryTo });
        }

        public IActionResult Transfers([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] ICardsRepository cardsRepository)
        {
            int userId = 1;
            ViewBag.Client = clientsRepository.FindClientById(userId);
            var cards = cardsRepository.FindCardsByUserId(userId);
            ViewBag.Cards = cards;
            ViewBag.Accounts = cards.Select(c => accountsRepository.FindAccountById(c.AccountId));
            return View();
        }

        [HttpPost]
        public IActionResult Transfer([FromServices] IAccountsRepository accountsRepository,
                                      [FromServices] ICardsRepository cardsRepository,
                                      [FromForm] Transfer transfer)
        {
            (int accountIdFrom, decimal amount, int accountIdTo, string cardCodeTo) = transfer;
            if (accountIdTo < 0)
            {
                var card = cardsRepository.FindCardByCode(cardCodeTo);
                if (card != null)
                {
                    accountIdTo = card.AccountId;
                }
                else return BadRequest("No card was found!");
            }

            accountsRepository.TransferBetweenAccountsByAccountId(accountIdFrom, accountIdTo, amount);

            return Json(new { result = accountsRepository.FindAccountById(accountIdTo) });
        }
    }
}
