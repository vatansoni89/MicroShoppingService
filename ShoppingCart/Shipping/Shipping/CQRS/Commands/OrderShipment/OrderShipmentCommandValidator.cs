using FluentValidation;

namespace Shipping.CQRS.Commands.OrderShipment
{
    public class OrderShipmentCommandValidator : AbstractValidator<OrderShipmentCommand>
    {
        public OrderShipmentCommandValidator()
        {
            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("{OrderId} is required.")
                .NotNull();
        }
    }
}
