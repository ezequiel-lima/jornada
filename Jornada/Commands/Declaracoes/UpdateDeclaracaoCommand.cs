using Jornada.Commands.Interfaces;
using Jornada.Models;
using System.Text.Json.Serialization;

namespace Jornada.Commands.Declaracoes
{
    public class UpdateDeclaracaoCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public List<Foto> Fotos { get; set; }
        public string Depoimento { get; set; }
        public string NomeDoAutor { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
