using Jornada.Commands.Interfaces;

namespace Jornada.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
