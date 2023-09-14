using Jornada.Commands.Interfaces;
using Jornada.Models;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Destinos
{
    public class UpdateDestinoCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public List<Foto> Fotos { get; set; }
        public string Nome { get; set; }
        public string Meta { get; set; }
        public string TextoDescritivo { get; set; }
        public decimal Preco { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
