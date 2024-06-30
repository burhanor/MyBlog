using FluentValidation;

namespace MyBlog.Application.Features.Post.Command.UpdatePost
{
	public class UpdatePostCommandValidator : AbstractValidator<UpdatePostCommandRequest>
	{
        public UpdatePostCommandValidator()
        {
            
        }
    }
}
