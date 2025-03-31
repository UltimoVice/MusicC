using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Models
{
    public class Traccia
    {
        public int TracciaId { get; set; }
        public int NumeroTraccia { get; set; }
        public string Titolo {  get; set; }
        public int Durata { get; set; }
        public int AlbumId { get; set; }

        public Traccia() { }

        public override int GetHashCode()
        {
            return HashCode.Combine(TracciaId);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Traccia))
                return false;

            Traccia traccia = (Traccia)obj;
            return TracciaId == traccia.TracciaId;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("ID traccia: ");
            builder.Append(TracciaId);
            builder.Append(", Numero Traccia: ");
            builder.Append(NumeroTraccia);
            builder.Append(", Titolo: ");
            builder.Append(Titolo);
            builder.Append(", Durata: ");
            builder.Append(Durata);
            builder.Append(", Album ID: ");
            builder.Append(AlbumId);

            return builder.ToString();
        }
    }
}
