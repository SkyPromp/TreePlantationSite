using FluentValidation;
using MediatR;

namespace AP.BTP.Application.Behaviours
{
    /// <summary>
    /// A MediatR pipeline behavior that performs FluentValidation validation on incoming requests
    /// before they reach the corresponding request handler.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request being handled. Must implement <see cref="IRequest{TResponse}"/>.</typeparam>
    /// <typeparam name="TResponse">The type of the response returned by the request handler.</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationBehaviour{TRequest, TResponse}"/> class.
        /// </summary>
        /// <param name="validators">The collection of validators to apply to the request.</param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Handles the request by running all registered validators. 
        /// If validation fails, a <see cref="ValidationException"/> is thrown before the request reaches the handler.
        /// Otherwise, the request is passed to the next behavior or handler in the pipeline.
        /// </summary>
        /// <param name="request">The request to validate and handle.</param>
        /// <param name="next">The next delegate in the pipeline to invoke if validation passes.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The response from the next handler in the pipeline.</returns>
        /// <exception cref="ValidationException">Thrown if one or more validation rules fail.</exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                ValidationContext<TRequest> context = new ValidationContext<TRequest>(request);
                FluentValidation.Results.ValidationResult[] validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                List<FluentValidation.Results.ValidationFailure> failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0) throw new ValidationException(failures);
            }

            return await next(cancellationToken);
        }
    }
}
