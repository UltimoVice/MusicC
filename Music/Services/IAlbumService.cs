using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public interface IAlbumService
    {
        public void RegistraAlbum(int albumId, string titolo, DateOnly dataUscita, string genere, int artistaId);
        public void CercaAlbumId(int albumId);
        public void CercaAlbumArtistaId(int artistaId);
        public void CercaAlbumTitolo(string titolo);
        public void CercaAlbumDate(DateOnly dataInizio, DateOnly dataFine);
        public void CercaAlbumGenere(string genere);
        public void OttieniDurataTot(int albumId);
        public void AggiornaAlbumId(int albumId, string titolo, DateOnly dataUscita, string genere, int artistaId);
        public void EliminaAlbumId(int albumId);

    }
}
