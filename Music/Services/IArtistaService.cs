using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public interface IArtistaService
    {
        public void Registra(int artistaId, string nome, string nazione, int annoInizio) { }

        public void CercaNomeArtista(string nome);

        public void CercaNazioneArtista(string nazione);

        public void CercaPeriodoArtista(int annoInizio, int annofine);

        public void AggiornaArtista(int artistaId, string Nome, string Nazione, int AnnoInizio);

        public void CancellaArtista(int artistaId);

        public void OttieniReport(int artistaId);
    }
}
