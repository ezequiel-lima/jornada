namespace Jornada.Models
{
    public class Declaracao : Entity
    {
        protected Declaracao()
        {
            
        }

        public Declaracao(string foto, string depoimento, string nomeDoAutor)
        {
            Foto = foto;
            Depoimento = depoimento;
            NomeDoAutor = nomeDoAutor;
        }

        public string Foto { get; private set; }
        public string Depoimento { get; private set; }
        public string NomeDoAutor { get; private set; }
    }
}
