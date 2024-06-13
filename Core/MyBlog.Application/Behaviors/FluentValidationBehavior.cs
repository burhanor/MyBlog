using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace MyBlog.Application.Behaviors
{
	public class FluentValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validator) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> validator = validator;

		public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			ValidationContext<TRequest> context = new (request);
			IList<ValidationFailure> failures = validator
				.Select(v => v.Validate(context))
				.SelectMany(result => result.Errors)
				.GroupBy(m => m.ErrorMessage)
				.Select(m => m.First())
				.Where(f => f != null)
				.ToList();

			if (failures.Count != 0)
			{
				throw new ValidationException(failures);
			}

			return next();
		}
	}
}
