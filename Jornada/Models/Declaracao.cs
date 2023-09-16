namespace Jornada.Models
{
    public class Declaracao : Entity
    {
        protected Declaracao()
        {

        }

        public Declaracao(List<Foto> fotos, string depoimento, string nomeDoAutor)
        {
            Fotos.Add(fotos[0]);
            Depoimento = depoimento;
            NomeDoAutor = nomeDoAutor;
        }

        public List<Foto> Fotos { get; private set; } = new List<Foto>();
        public string Depoimento { get; private set; }
        public string NomeDoAutor { get; private set; }

        public void Alterar(List<Foto> fotos, string depoimento, string nomeDoAutor)
        {
            AdicionarFoto(fotos);
            Depoimento = depoimento;
            NomeDoAutor = nomeDoAutor;
        }

        public void AdicionarFoto(List<Foto> fotos)
        {
            Fotos.Clear();
            Fotos.Add(fotos[0]);
        }
    }
}
