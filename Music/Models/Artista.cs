using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class Artista
    {
        public int ArtistaId { get; set; }
        public string Nome {  get; set; }
        public string Nazione { get; set; }
        public int AnnoInizio { get; set; }

        public Artista() { }

        public override int GetHashCode()
        {
            return HashCode.Combine(ArtistaId);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Artista))
                return false;

            Artista artista = (Artista)obj;
            return ArtistaId == artista.ArtistaId;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("ID artista: ");
            builder.Append(ArtistaId);
            builder.Append(", Nome: ");
            builder.Append(Nome);
            builder.Append(", Nazione: ");
            builder.Append(Nazione);
            builder.Append(", Anno inizio: ");
            builder.Append(AnnoInizio);
            
            return builder.ToString();
        }
    }
}
