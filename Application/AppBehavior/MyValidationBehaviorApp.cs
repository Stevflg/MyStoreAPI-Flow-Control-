using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.AppBehavior
{
    public class MyValidationBehaviorApp<TRequest, TResponse> :
         IPipelineBehavior<TRequest, TResponse>
             where TRequest : IRequest<TResponse>
             where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validators;
        public MyValidationBehaviorApp(IValidator<TRequest>? validators=null){
            _validators = validators;
        }

        async Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validators is null)
            {
                return await next();
            }
            var validationResult = await _validators.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next();
            }
            var errors = validationResult.Errors.
                    ConvertAll(validationFailure =>
                        Error.Validation(validationFailure.PropertyName,validationFailure.ErrorMessage));
            return (dynamic)errors;
        }
    }
}