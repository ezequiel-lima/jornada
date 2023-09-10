using Jornada.Commands.Interfaces;

namespace Jornada.Commands.Destinos
{
    public class CreateDestinoCommand : ICommand
    {
        public CreateDestinoCommand(string foto, string nome, decimal preco)
        {
            Foto = foto;
            Nome = nome;
            Preco = preco;
        }

        public string Foto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
