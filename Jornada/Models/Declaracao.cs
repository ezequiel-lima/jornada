namespace Jornada.Models
{
    public class Declaracao
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

        public Guid Id { get; private set; }
        public string Foto { get; private set; }
        public string Depoimento { get; private set; }
        public string NomeDoAutor { get; private set; }
    }
}
