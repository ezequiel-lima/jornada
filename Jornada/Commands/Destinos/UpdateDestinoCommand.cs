using Jornada.Commands.Interfaces;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Destinos
{
    public class UpdateDestinoCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Foto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
