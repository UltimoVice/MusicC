using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class Album
    {
        public int AlbumId {  get; set; }
        public string Titolo { get; set; }
        public DateOnly DataUscita { get; set; }
        public string Genere { get; set; }
        public int ArtistaId { get; set; }


        public Album() { }

        public override int GetHashCode()
        {
            return HashCode.Combine(AlbumId);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Album))
                return false;

            Album album = (Album)obj;
            return AlbumId == album.AlbumId;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("ID album: ");
            builder.Append(AlbumId);
            builder.Append(", Titolo: ");
            builder.Append(Titolo);
            builder.Append(", Data uscita: ");
            builder.Append(DataUscita);
            builder.Append(", Genere: ");
            builder.Append(Genere);
            builder.Append(", Artista ID: ");
            builder.Append(ArtistaId);        

            return builder.ToString();
        }
    }
}
