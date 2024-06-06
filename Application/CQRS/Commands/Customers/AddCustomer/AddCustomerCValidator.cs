using FluentValidation;

namespace Application.CQRS.Commands.Customers.AddCustomer
{
    public class AddCustomerCValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCValidator()
        {
            RuleFor(a => a.Name).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
            RuleFor(a => a.Identification).NotEmpty();
            RuleFor(a => a.Address).NotEmpty();
            RuleFor(a => a.DateBirth).NotEmpty();
            RuleFor(a => a.Email).NotEmpty().EmailAddress();
        }
    }
}
