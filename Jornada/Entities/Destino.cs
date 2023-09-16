namespace Jornada.Models
{
    public class Destino : Entity
    {
        protected Destino()
        {
            
        }

        public Destino(string nome, string meta, string textoDescritivo, decimal preco)
        {
            Fotos = new List<Foto>();
            Nome = nome;
            Meta = meta;
            TextoDescritivo = textoDescritivo;
            Preco = preco;
        }

        public List<Foto> Fotos { get; private set; } = new List<Foto>();
        public string Nome { get; private set; }
        public string Meta { get; private set; }
        public string TextoDescritivo { get; private set; }
        public decimal Preco { get; private set; }

        public void Alterar(List<Foto> fotos, string nome, string meta, string textoDescritivo, decimal preco)
        {
            AdicionarFoto(fotos);
            Nome = nome;
            Meta = meta;
            TextoDescritivo = textoDescritivo;
            Preco = preco;
        }

        public void AdicionarFoto(List<Foto> fotos)
        {
            foreach (var foto in fotos)
            {
                Fotos.Add(foto);
            }
        }
    }
}
