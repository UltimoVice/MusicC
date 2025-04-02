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
    public class AlbumService : IAlbumService
    {
        public void AggiornaAlbumId(int albumId, string titolo, DateOnly dataUscita, string genere, int artistaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();
                    IAlbumDao albumDao = new AlbumDao();

                    Album? album1 = albumDao.GetById(albumId, connection, transaction);

                    album1.AlbumId = albumId;
                    album1.Titolo = titolo;
                    album1.DataUscita = dataUscita;
                    album1.Genere = genere;
                    album1.ArtistaId = artistaId;

                    albumDao.UpdateById(albumId, titolo, dataUscita, genere, artistaId, connection, transaction);

                    Console.WriteLine("Album aggiornato");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Aggiornamento fallito");
                }
            }
        }

        public void CercaAlbumArtistaId(int artistaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetByIdArtista(artistaId, connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaAlbumDate(DateOnly dataInizio, DateOnly dataFine)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetByDate( dataInizio, dataFine , connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaAlbumGenere(string genere)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetByGenere(genere, connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaAlbumId(int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetById(albumId, connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void CercaAlbumTitolo(string titolo)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetByTitolo(titolo, connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void EliminaAlbumId(int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.DeleteById(albumId, connection, transaction);

                    Console.WriteLine("Album eliminato");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Eliminazione fallita");
                }
            }
        }

        public void OttieniDurataTot(int albumId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.GetDurataTotale(albumId, connection, transaction);

                    Console.WriteLine("Album trovati");

                    transaction.Commit();
                }
                catch
                {
                    transaction!.Rollback();
                    Console.WriteLine("Ricerca fallita");
                }
            }
        }

        public void RegistraAlbum(int albumId, string titolo, DateOnly dataUscita, string genere, int artistaId)
        {
            using (SqlConnection connection = MusicConnection.Open())
            {
                SqlTransaction transaction = null;
                try
                {
                    transaction = connection.BeginTransaction();

                    Album album = new Album();
                    album.ArtistaId = artistaId;
                    album.AlbumId = albumId;
                    album.Titolo = titolo;
                    album.DataUscita = dataUscita;
                    album.Genere = genere;

                    IAlbumDao albumDao = new AlbumDao();
                    albumDao.Save(album, connection, transaction);

                    Console.WriteLine("Album registrato");
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
