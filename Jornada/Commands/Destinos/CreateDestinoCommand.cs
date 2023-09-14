using Jornada.Commands.Interfaces;
using Jornada.Models;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Destinos
{
    public class CreateDestinoCommand : ICommand
    {
        [JsonIgnore]
        public List<Foto> Fotos { get; set; } = new List<Foto>();
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
