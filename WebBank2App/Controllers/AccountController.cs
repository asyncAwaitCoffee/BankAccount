using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBank2App.DTO;
using WebBank2App.Filters;
using WebBank2App.Models;
using WebBank2App.Repositories;

namespace WebBank2App.Controllers
{
    [Authorize]
	public class AccountController : Controller
	{
        [UserId]
		public IActionResult Cards([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] IUsersRepository usersRepository,
                             [FromServices] ICardsRepository cardsRepository,
                             int userId)
		{
            int? clientId = usersRepository.GetClientId(userId);
            if (clientId == null)
            {
                return BadRequest();
            }
			ViewBag.Client = clientsRepository.FindClientById(userId);
			var cards = cardsRepository.FindCardsByUserId(userId);
            if (!cards.Any())
            {
                return RedirectToAction("Cards", "Product");
            }
            ViewBag.Cards = cards;
            ViewBag.Accounts = cards.Select(c => accountsRepository.FindAccountById(c.AccountId));

            return View();
		}
		[UserId]
		public IActionResult Card([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] ICardsRepository cardsRepository,
                             [FromServices] ITransfersRepository transfersRepository,
							 int userId,
							 int cardId)
        {
            CardModel? card;
            if (cardId < 0)
            {
                card = cardsRepository.FindCardsByUserId(userId).FirstOrDefault();
            } else
            {
                card = cardsRepository.FindCardById(cardId);
            }
            if (card == null)
            {
                return Json(new {ok = false});
            }
            // TODO - handle card without corresponding account?
            var account = accountsRepository.FindAccountById(card.AccountId);
            var transfersHistoryFrom = transfersRepository.FindTransfersByAccountIdFrom(account.Id);
            var transfersHistoryTo = transfersRepository.FindTransfersByAccountIdTo(account.Id);
            var client = clientsRepository.FindClientById(card.UserId);

            return Json(new { ok = true, card, account, client, transfersHistoryFrom, transfersHistoryTo });
        }
		[UserId]
		public IActionResult Transfers([FromServices] IAccountsRepository accountsRepository,
                             [FromServices] IClientsRepository clientsRepository,
                             [FromServices] ICardsRepository cardsRepository,
							 int userId)
        {
            ViewBag.Client = clientsRepository.FindClientById(userId);
            var cards = cardsRepository.FindCardsByUserId(userId);
            ViewBag.Cards = cards;
            ViewBag.Accounts = cards.Select(c => accountsRepository.FindAccountById(c.AccountId));
            return View();
        }

        [HttpPost]
        public IActionResult Transfer([FromServices] IAccountsRepository accountsRepository,
                                      [FromServices] ICardsRepository cardsRepository,
                                      [FromServices] ITransfersRepository transfersRepository,
                                      [FromForm] TransferDTO transfer)
        {
            (int accountIdFrom, decimal amount, int accountIdTo, string cardCodeTo) = transfer;
            
            if (amount <= 0)
            {
                return Json(new { ok = false, message = "Amount must be greater than 0!" });
            }
            if (accountIdTo < 0)
            {
                var card = cardsRepository.FindCardByCode(cardCodeTo);
                if (card != null)
                {
                    accountIdTo = card.AccountId;
                }
                else return Json(new { ok = false, message = "No card was found!" });
            }
            if (accountIdFrom == accountIdTo)
            {
                return Json(new { ok = false, message = "Target and source card must be different!" });
            }

            accountsRepository.TransferBetweenAccountsByAccountId(accountIdFrom, accountIdTo, amount);
            transfersRepository.AddTransfer(new TransferModel(accountIdFrom, accountIdTo, amount, DateTime.Now));

            return Json(new { ok = true });
        }
    }
}
