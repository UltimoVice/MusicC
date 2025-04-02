using Music.Dao;
using Music.Models;
using Music.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Music.Menu
{
    public class MostraFunzioni
    {
        public static void MostraMenu()
        {
            int sceltaMenu;

            do
            {
                Console.Clear();
                Console.WriteLine("Benvenuto in Music");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Fai una scelta");
                Console.WriteLine("A quale menù vuoi accedere?");
                Console.WriteLine("1. Artista");
                Console.WriteLine("2. Album");
                Console.WriteLine("3. Traccia");
                Console.WriteLine("0. Esci");
                Console.Write("Scegli un'opzione: ");

                if (!int.TryParse(Console.ReadLine(), out sceltaMenu))
                {
                    Console.WriteLine("Inserisci un numero valido!");
                    continue;
                }

                if (sceltaMenu == 0)
                {
                    Console.WriteLine("Programma terminato");
                    break;
                }

                MostraSottoMenu(sceltaMenu);

            } while (sceltaMenu != 0);

            Console.WriteLine("Arrivederci");
        }

        public static void MostraSottoMenu(int categoria)
        {
            int scelta;
            do
            {
                Console.Clear();

                switch (categoria)
                {
                    case 1:
                        Console.WriteLine("Menu Artista:");
                        Console.WriteLine("1. Cerca per nome dell'artista");
                        Console.WriteLine("2. Cerca per nazionalità dell'artista");
                        Console.WriteLine("3. Cerca per periodo di attività dell'artista");
                        Console.WriteLine("4. Salva un nuovo artista");
                        Console.WriteLine("5. Aggiorna i dati di un artista");
                        Console.WriteLine("6. Cancella i dati di un artista");
                        Console.WriteLine("7. Ottieni il report delle tracce di un artista");
                        break;
                    case 2:
                        Console.WriteLine("Menu Album:");
                        Console.WriteLine("8. Salva nuovo Album");
                        Console.WriteLine("9. Cerca per id dell'album");
                        Console.WriteLine("10. Cerca per id dell'artista");
                        Console.WriteLine("11. Cerca per titolo dell'album");
                        Console.WriteLine("12. Cerca per periodo di uscita dell'album");
                        Console.WriteLine("13. Cerca per genere dell'album");
                        Console.WriteLine("14. Ottieni la durata totale dell'album");
                        Console.WriteLine("15. Aggiorna album");
                        Console.WriteLine("16. Cancella Album");
                        break;
                    case 3:
                        Console.WriteLine("Menu Traccia:");
                        Console.WriteLine("17. Salva nuova traccia");
                        Console.WriteLine("18. Cerca traccia tramite id album");
                        Console.WriteLine("19. Cerca traccia tramite il titolo");
                        Console.WriteLine("20. Aggiorna traccia");
                        Console.WriteLine("21. Cancella traccia");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        return;
                }

                Console.WriteLine("0. Torna al menu principale");
                Console.Write("Scegli un'opzione: ");

                if (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 21)
                {
                    Console.WriteLine("Inserisci un numero valido!");
                    continue;
                }

                if (scelta == 0)
                    break;

                EseguiAzione(scelta);
                Console.WriteLine("Premi invio per proseguire...");
                Console.ReadLine();

            } while (scelta != 0);
        }

        public static void EseguiAzione(int scelta)
        {
            switch (scelta)
            {
                case 1: CercaNomeArtista(); break;
                case 2: CercaNazione(); break;
                case 3: CercaPeriodo(); break;
                case 4: SalvaArtista(); break;
                case 5: AggiornaArtista(); break;
                case 6: CancellaArtista(); break;
                case 7: ReportArtista(); break;
                case 8: RegistraAlbum(); break;
                case 9: CercaAlbumId(); break;
                case 10: CercaAlbumArtistaId(); break;
                case 11: CercaAlbumTitolo(); break;
                case 12: CercaAlbumDate(); break;
                case 13: CercaAlbumGenere(); break;
                case 14: OttieniDurataTot(); break;
                case 15: AggiornaAlbumId(); break;
                case 16: EliminaAlbumId(); break;
                case 17: RegistraTraccia(); break;
                case 18: CercaTracciaIdAlbum(); break;
                case 19: CercaTracciaTitolo(); break;
                case 20: AggiornaTraccia(); break;
                case 21: EliminaTraccia(); break;
                default: Console.WriteLine("Scelta errata"); break;
            }
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

        public static void RegistraAlbum()
        {
            Console.WriteLine("Inserisci ID dell'album: ");
            int idAlbum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci il titolo dell'album: ");
            string nomeAlbum = Console.ReadLine();
            Console.WriteLine("Inserisci la data di uscita dell'album: ");
            DateOnly dataUscita = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci genere dell'album: ");
            string genere = Console.ReadLine();
            Console.WriteLine("Inserisci ID dell'artista: ");
            int idArtista = Convert.ToInt32(Console.ReadLine());

            IAlbumService album = new AlbumService();
            album.RegistraAlbum(idAlbum, nomeAlbum, dataUscita, genere, idArtista);
        }

        public static void CercaAlbumId()
        {
            Console.WriteLine("Inserisci ID dell'album: ");
            int idAlbum = Convert.ToInt32(Console.ReadLine());


            IAlbumService album = new AlbumService();
            album.CercaAlbumId(idAlbum);
        }

        public static void CercaAlbumArtistaId()
        {
            Console.WriteLine("Inserisci ID dell'artista");
            int idArtista = Convert.ToInt32(Console.ReadLine());


            IAlbumService album = new AlbumService();
            album.CercaAlbumArtistaId(idArtista);
        }

        public static void CercaAlbumTitolo()
        {
            Console.WriteLine("Inserisci titolo dell'album");
            string titolo = Console.ReadLine();


            IAlbumService album = new AlbumService();
            album.CercaAlbumTitolo(titolo);
        }
        public static void CercaAlbumDate()
        {
            Console.WriteLine("Inserisci data inizio");
            DateOnly dataInizio = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci data fine");
            DateOnly dataFine = DateOnly.Parse(Console.ReadLine());


            IAlbumService album = new AlbumService();
            album.CercaAlbumDate(dataInizio, dataFine);
        }
        public static void CercaAlbumGenere()
        {
            Console.WriteLine("Inserisci genere dell'album");
            string genere = Console.ReadLine();

            IAlbumService album = new AlbumService();
            album.CercaAlbumGenere(genere);
        }
        public static void OttieniDurataTot()
        {
            Console.WriteLine("Ottieni durata totale dell'album, inserisci l'id dell'album");
            int idAlbum = Convert.ToInt32(Console.ReadLine());

            IAlbumService album = new AlbumService();
            album.OttieniDurataTot(idAlbum);
        }

        public static void AggiornaAlbumId()
        {
            Console.WriteLine("Inserisci ID dell'album: ");
            int idAlbum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci il titolo dell'album: ");
            string nomeAlbum = Console.ReadLine();
            Console.WriteLine("Inserisci la data di uscita dell'album: ");
            DateOnly dataUscita = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci genere dell'album: ");
            string genere = Console.ReadLine();
            Console.WriteLine("Inserisci ID dell'artista: ");
            int idArtista = Convert.ToInt32(Console.ReadLine());

            IAlbumService album = new AlbumService();
            album.AggiornaAlbumId(idAlbum, nomeAlbum, dataUscita, genere, idArtista);
        }
        public static void EliminaAlbumId()
        {
            Console.WriteLine("Elimina un album, inserisci l'id dell'album");
            int idAlbum = Convert.ToInt32(Console.ReadLine());

            IAlbumService album = new AlbumService();
            album.EliminaAlbumId(idAlbum);
        }

        public static void RegistraTraccia()
        {
            Console.WriteLine("Inserisci ID della traccia: ");
            int idTraccia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ilnumero della traccia:");
            int numeroTraccia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci il titolo della traccia: ");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci durata della traccia: ");
            int durata = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ID album: ");
            int idAlbum = Convert.ToInt32(Console.ReadLine());

            ITracciaService traccia = new TracciaService();
            traccia.RegistraTraccia(idTraccia, numeroTraccia, titolo, durata, idAlbum);
        }

        public static void CercaTracciaIdAlbum()
        {
            Console.WriteLine("Inserisci ID dell'album");
            int idAlbum = Convert.ToInt32(Console.ReadLine());


            ITracciaService traccia = new TracciaService();
            traccia.CercaTracciaIdAlbum(idAlbum);
        }
        public static void CercaTracciaTitolo()
        {
            Console.WriteLine("Inserisci titolo della traccia");
            string titolo = Console.ReadLine();


            ITracciaService traccia = new TracciaService();
            traccia.CercaTracciaTitolo(titolo);
        }
        public static void AggiornaTraccia()
        {
            Console.WriteLine("Inserisci ID della traccia: ");
            int idTraccia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ilnumero della traccia:");
            int numeroTraccia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci il titolo della traccia: ");
            string titolo = Console.ReadLine();
            Console.WriteLine("Inserisci durata della traccia: ");
            int durata = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserisci ID album: ");
            int idAlbum = Convert.ToInt32(Console.ReadLine());

            ITracciaService traccia = new TracciaService();
            traccia.AggiornaTraccia(idTraccia, numeroTraccia, titolo, durata, idAlbum);
        }
        public static void EliminaTraccia()
        {
            Console.WriteLine("Inserisci id della traccia");
            int idTraccia = Convert.ToInt32(Console.ReadLine());


            ITracciaService traccia = new TracciaService();
            traccia.EliminaTraccia(idTraccia);
        }
    }
}
