using Music.Dao;
using Music.Models;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Menu
{
    public class MostraFunzioni
    {
        public static void MostraMenu()
        {
            int scelta;
            do
            {
                Console.WriteLine("Benvenuto in Music");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Fai una scelta");
                Console.WriteLine("0. Esci");
                Console.WriteLine("1. Cerca per nome dell'artista");
                Console.WriteLine("2. Cerca per nazionalità dell'artista");
                Console.WriteLine("3. Cerca per periodo di attività dell'artista");
                Console.WriteLine("4. Salva un nuovo artista");
                Console.WriteLine("5. Aggiorna i dati di un artista");
                Console.WriteLine("6. Cancella i dati di un artista");
                Console.WriteLine("7. Ottieni il report delle tracce di un artista");


                scelta = Convert.ToInt32(Console.ReadLine());

                switch (scelta)
                {
                    case 0:
                        Console.WriteLine("Programma terminato");
                        break;
                    case 1:
                        CercaNomeArtista();
                        break;
                    case 2:
                        CercaNazione();
                        break;
                    case 3:
                        CercaPeriodo();
                        break;
                    case 4:
                        SalvaArtista();
                        break;
                    case 5:
                        AggiornaArtista();
                        break;
                    case 6:
                        CancellaArtista();
                        break;
                    case 7:
                        ReportArtista();
                        break;
                    default:
                        Console.WriteLine("Scelta errata");
                        break;
                }
                Console.WriteLine("Premi invio per proseguire");
                Console.ReadLine();
            } while (scelta != 0);

            Console.WriteLine("Arrivederci");
        }

        public static void CercaNomeArtista()
        {
            Console.WriteLine("Inserisci il nome dell'artista (anche parziale)");
            string nome = Console.ReadLine();

            IArtistaService artista = new ArtistaService();
            artista.CercaNomeArtista(nome);
            
        }

        public static void SalvaArtista() 
        {
            Console.WriteLine("Inserisci ID dell'artista: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci il nome dell'artista: ");
            string nomeArtista = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione dell'artista: ");
            string nazione = Console.ReadLine();
            Console.WriteLine("Inserisci anno di debutto dell'artista: ");
            int annoInizio = Convert.ToInt32(Console.ReadLine());

            IArtistaService artista = new ArtistaService();
            artista.Registra(id, nomeArtista, nazione, annoInizio);
        }

        public static void CercaNazione()
        {
            Console.WriteLine("Inserisci la nazione dell'artista");
            string nazione = Console.ReadLine();

            IArtistaService artista = new ArtistaService();
            artista.CercaNazioneArtista(nazione);

        }

        public static void CercaPeriodo()
        {
            Console.WriteLine("Inserisci la data di inizio");
            int annoInizio = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci la data di inizio");
            int annoFine = Convert.ToInt32(Console.ReadLine());

            IArtistaService artista = new ArtistaService();
            artista.CercaPeriodoArtista(annoInizio, annoFine);

        }

        public static void AggiornaArtista() 
        {
            Console.WriteLine("Inserisci ID artista da modificare: ");
            int idArtista = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Modifica nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Modifica Nazione: ");
            string nazione = Console.ReadLine();
            Console.WriteLine("Modifica anno inizio: ");
            int annoInizio = Convert.ToInt32(Console.ReadLine());

            IArtistaService artista = new ArtistaService();
            artista.AggiornaArtista(idArtista, nome, nazione, annoInizio);
        }

        public static void CancellaArtista() 
        {
            Console.WriteLine("Inserisci ID artista da cancellare: ");
            int idArtista = Convert.ToInt32(Console.ReadLine());

            IArtistaService artista = new ArtistaService();
            artista.CancellaArtista(idArtista);
        }

        public static void ReportArtista()
        {
            Console.WriteLine("Inserisci ID artista per ottenere un report: ");
            int idArtista = Convert.ToInt32(Console.ReadLine());

            IArtistaService artista = new ArtistaService();
            artista.OttieniReport(idArtista);
        }
    }
}
