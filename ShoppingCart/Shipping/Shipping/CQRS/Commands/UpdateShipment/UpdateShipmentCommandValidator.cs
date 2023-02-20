using FluentValidation;

namespace Shipping.CQRS.Commands.UpdateShipment
{
    public class UpdateShipmentCommandValidator : AbstractValidator<UpdateShipmentCommand>
    {
        public UpdateShipmentCommandValidator()
        {
            RuleFor(p => p.OrderId)
               .NotEmpty().WithMessage("{OrderId} is required.")
               .NotNull();
        }
    }
}
