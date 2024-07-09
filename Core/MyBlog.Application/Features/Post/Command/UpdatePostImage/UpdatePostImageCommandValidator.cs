using FluentValidation;

namespace MyBlog.Application.Features.Post.Command.UpdatePostImage
{
	public class UpdatePostImageCommandValidator : AbstractValidator<UpdatePostImageCommandRequest>
	{
        public UpdatePostImageCommandValidator()
        {
            
        }
    }
}
