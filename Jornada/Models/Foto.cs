namespace Jornada.Models
{
    public class Foto : Entity
    {
        public Foto(string url)
        {
            Url = url;
        }

        public Foto()
        {
            
        }

        public string Url { get; set; }
    }
}
