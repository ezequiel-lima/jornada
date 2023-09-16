namespace Jornada.Models
{
    public class Foto : Entity
    {
        public Foto(string url)
        {
            Url = url;
        }

        protected Foto()
        {
            
        }

        public string Url { get; private set; }
    }
}
