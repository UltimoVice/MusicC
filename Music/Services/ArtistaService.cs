using Microsoft.Data.SqlClient;
using Music.Connection;
using Music.Dao;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Services
{
    public class ArtistaService : IArtistaService
    {
        public void Registra(int artistaId, string nome, string nazione, int annoInizio) 
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();
                    artista.ArtistaId = artistaId;
                    artista.Nome = nome;
                    artista.Nazione = nazione;
                    artista.AnnoInizio = annoInizio;

                    IArtistaDao artistaDao = new ArtistaDao();
                    artistaDao.Save(artista, connection, transaction);

                    Console.WriteLine("artista registrato");
                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Registrazione fallita");
                }
            }
        }

        public void CercaNomeArtista(string nome)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();

                    IArtistaDao artistaDao = new ArtistaDao();
                    artistaDao.GetByNome(nome, connection, transaction);

                    Console.WriteLine("Artisti trovati");
                    
                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaNazioneArtista(string nazione)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();

                    IArtistaDao artistaDao = new ArtistaDao();
                    artistaDao.GetByNazione(nazione, connection, transaction);

                    Console.WriteLine("Artisti trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaPeriodoArtista(int annoInizio, int annoFine)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();

                    IArtistaDao artistaDao = new ArtistaDao();
                    artistaDao.GetByPeriodo(annoInizio, annoFine, connection, transaction);

                    Console.WriteLine("Artisti trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void AggiornaArtista(int artistaId, string Nome, string Nazione, int AnnoInizio)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();
                    IArtistaDao artistaDao = new ArtistaDao();

                    Artista? artista1 = artistaDao.GetById(artistaId, connection, transaction);

                    artista1.Nome = Nome;
                    artista1.Nazione = Nazione;
                    artista1.AnnoInizio = AnnoInizio;

                    artistaDao.UpdateById(artistaId, Nome, Nazione, AnnoInizio, connection, transaction);

                    Console.WriteLine("Artista aggiornato");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Aggiornamento fallito");
                }
            }
        }

        public void CancellaArtista(int artistaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Artista artista = new Artista();

                    IArtistaDao artistaDao = new ArtistaDao();
                    artistaDao.DeleteById(artistaId, connection, transaction);

                    Console.WriteLine("Artista eliminato");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Eliminazione fallita");
                }
            }
        }

        public void OttieniReport(int artistaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    IArtistaDao artistaDao = new ArtistaDao();
                    string report = artistaDao.GetReport(artistaId, connection, transaction);

                    if (!string.IsNullOrEmpty(report))
                    {
                        Console.WriteLine("Report ottenuto:");
                        Console.WriteLine(report);
                    }
                    else
                    {
                        Console.WriteLine("Nessun artista trovato con l'ID specificato.");
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Report fallito");
                }
            }
        }

    }
}
