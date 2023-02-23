using FluentValidation;

namespace Shipping.CQRS.Commands.OrderShipment
{
    public class CreateShipmentCommandValidator : AbstractValidator<CreateShipmentCommand>
    {
        public CreateShipmentCommandValidator()
        {
            RuleFor(p => p.OrderId)
                .NotEmpty().WithMessage("OrderId is required.")
                .NotNull();
            RuleFor(p => p.ShippedDateUtc)
                .NotEmpty().WithMessage("ShippedDateUtc is required.")
                .NotNull();
            RuleFor(p => p.TrackingNumber)
                .NotEmpty().When(x => string.IsNullOrEmpty(x.TrackingUrl)).WithMessage("TrackingNumber or TrackingUrl is required.")
                .NotNull().When(x => string.IsNullOrEmpty(x.TrackingUrl)).WithMessage("TrackingNumber or TrackingUrl is required.");
            RuleFor(p => p.TrackingUrl)
               .NotEmpty().When(x => string.IsNullOrEmpty(x.TrackingNumber)).WithMessage("{TrackingNumber} or {TrackingUrl} is required.")
               .NotNull().When(x => string.IsNullOrEmpty(x.TrackingNumber)).WithMessage("{TrackingNumber} or {TrackingUrl} is required.");
        }
    }
}
