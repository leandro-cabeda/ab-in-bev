using Rebus.Handlers;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using MediatR;

namespace Ambev.DeveloperEvaluation.IoC.Consumers
{
    /// <summary>
    /// Consumidor para lidar com CreateUserCommand
    /// </summary>
    public class CreateUserConsumer : IHandleMessages<CreateUserCommand>
    {
        private readonly IMediator _mediator;

        public CreateUserConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(CreateUserCommand message)
        {
            await _mediator.Send(message);
        }
    }
}
