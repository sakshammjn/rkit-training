using Microsoft.AspNetCore.Mvc;
using webAPI.Data;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/accounts/{accountId}/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        //returns all teh cards in the sam accpount id 
        [HttpGet]
        public ActionResult<ICollection<Card>> GetCards(int accountId)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                return BadRequest();
            }

            return Ok(account.Cards);
        }

        //returns the exact card detail based on the accountid and then the cardid
        [HttpGet("{cardId}", Name ="GetCard")]
        public ActionResult<Card> GetCard (int accountId, int cardId)
        {
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                return BadRequest();
            }

            var card = account.Cards.FirstOrDefault(x => x.Id == cardId);

            if (card is null)
            {
                return BadRequest();
            }

            return Ok(card);
        }

        [HttpPost]
        public ActionResult<Card> CreateCard(int accountId, [FromBody] CreateCard createCard)
        {
            //does the accountid even exist
            var account = AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == accountId);

            if (account == null)
            {
                return BadRequest();
            }

            //check if number exists
            var card = account.Cards.FirstOrDefault(x => x.Number == createCard.Number);

            if (card is not null)
            {
                return BadRequest();
            }

            //create a card

            int id = account.Cards.OrderByDescending(x => x.Id).First().Id;

            Card _card = new Card
            {
                ExpiryDate = createCard.ExpiryDate,
                Number = createCard.Number,
                HolderName = createCard.HolderName,
                Id = ++id
            };
            // add it to the given account's card list
            account.Cards.Add(_card);

            // return response
            return CreatedAtRoute("GetCard", new {accountId, cardId = _card.Id}, _card);
        }

    }
}
