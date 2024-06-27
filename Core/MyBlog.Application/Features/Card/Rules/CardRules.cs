using MyBlog.Application.Commons.Rules;
using MyBlog.Application.Exceptions.CardExceptions;

namespace MyBlog.Application.Features.Card.Rules
{
	public class CardRules:CommonRules
	{
		public async ValueTask CardNotFound(Domain.Entities.Card? card)
		{
			if (card == null || card.Id == 0)
			{
				throw new CardNotFoundException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask CardAlreadyExists(Domain.Entities.Card? card)
		{
			if (card != null && card.Id != 0)
			{
				throw new CardAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}

		public async ValueTask CardAlreadyExists(bool isExist)
		{
			if (isExist)
			{
				throw new CardAlreadyExistException();
			}
			await ValueTask.CompletedTask;
		}
	}
}
