using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Music.Connection;
using Music.Dao;
using Music.Models;

namespace Music.Services
{
    public class TracciaService : ITracciaService
    {
        public void AggiornaTraccia(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Traccia album = new Traccia();
                    ITracciaDao tracciaDao = new TracciaDao();

                    Traccia? traccia1 = tracciaDao.GetByTracciaId(tracciaId, connection, transaction);

                    traccia1.TracciaId = tracciaId;
                    traccia1.Titolo = titolo;
                    traccia1.NumeroTraccia = numeroTraccia;
                    traccia1.Durata = durata;
                    traccia1.AlbumId = albumId;

                    tracciaDao.UpdateById(tracciaId, numeroTraccia, titolo, durata, albumId, connection, transaction);

                    Console.WriteLine("Traccia aggiornata");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Aggiornamento fallito");
                }
            }
        }

        public void CercaTracciaIdAlbum(int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Traccia traccia = new Traccia();

                    ITracciaDao tracciaDao = new TracciaDao();
                    tracciaDao.GetByAlbumId(albumId, connection, transaction);

                    Console.WriteLine("Traccia trovata");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaTracciaTitolo(string titolo)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Traccia traccia = new Traccia();

                    ITracciaDao tracciaDao = new TracciaDao();
                    tracciaDao.GetByTitolo(titolo, connection, transaction);

                    Console.WriteLine("Traccia trovata");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void EliminaTraccia(int tracciaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Traccia traccia = new Traccia();

                    ITracciaDao tracciaDao = new TracciaDao();
                    tracciaDao.DeleteById(tracciaId, connection, transaction);

                    Console.WriteLine("Traccia eliminata");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void RegistraTraccia(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Traccia traccia = new Traccia();
                    traccia.TracciaId = tracciaId;
                    traccia.NumeroTraccia = numeroTraccia;
                    traccia.Titolo = titolo;
                    traccia.Durata = durata;
                    traccia.AlbumId = albumId;

                    ITracciaDao traccia1 = new TracciaDao();
                    traccia1.Save(traccia, connection, transaction);

                    Console.WriteLine("Traccia registrata");
                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Registrazione fallita");
                }
            }
        }
    }
}
