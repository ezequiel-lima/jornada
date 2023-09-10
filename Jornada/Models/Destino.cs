namespace Jornada.Models
{
    public class Destino : Entity
    {
        protected Destino()
        {
            
        }

        public Destino(string foto, string nome, decimal preco)
        {
            Alterar(foto, nome, preco);
        }

        public string Foto { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

        public void Alterar(string foto, string nome, decimal preco)
        {
            Foto = foto;
            Nome = nome;
            Preco = preco;
        }
    }
}
