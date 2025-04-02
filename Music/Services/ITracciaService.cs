using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music.Models;

namespace Music.Services
{
    public interface ITracciaService
    {
        public void RegistraTraccia(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId);
        public void CercaTracciaIdAlbum(int albumId);
        public void CercaTracciaTitolo(string titolo);
        public void AggiornaTraccia(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId);
        public void EliminaTraccia(int tracciaId);
    }
}
