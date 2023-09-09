using Jornada.Commands.Interfaces;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Declaracoes
{
    public class DeleteDeclaracaoCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public DeleteDeclaracaoCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
