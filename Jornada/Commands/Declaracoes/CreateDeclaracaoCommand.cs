using Jornada.Commands.Interfaces;

namespace Jornada.Commands.Declaracoes
{
    public class CreateDeclaracaoCommand : ICommand
    {
        public string Foto { get; set; }
        public string Depoimento { get; set; }
        public string NomeDoAutor { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
