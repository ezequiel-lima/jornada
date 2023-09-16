using Jornada.Commands.Interfaces;
using Jornada.Models;

namespace Jornada.Commands.Declaracoes
{
    public class CreateDeclaracaoCommand : ICommand
    {
        public List<Foto> Fotos { get; set; }
        public string Depoimento { get; set; }
        public string NomeDoAutor { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
