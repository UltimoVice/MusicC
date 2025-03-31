using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public class AlbumDao : IAlbumDao
    {
        public void DeleteById(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<AlbumDao?> GetByDate(DateOnly DataInizio, DateOnly DataFine, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<AlbumDao?> GetByGenere(string Genere, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<AlbumDao?> GetById(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<AlbumDao?> GetByIdArtista(int ArtistaId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<AlbumDao?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public AlbumDao GetDurataTotale(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Save(AlbumDao albumDao, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int AlbumId, AlbumDao albumDao, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
