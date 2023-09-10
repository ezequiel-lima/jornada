using Jornada.Commands.Interfaces;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Destinos
{
    public class DeleteDestinoCommand : ICommand
    {     
        [JsonIgnore]
        public Guid Id { get; set; }

        public DeleteDestinoCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
