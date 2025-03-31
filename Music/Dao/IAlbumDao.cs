using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public interface IAlbumDao
    {
        void Save(AlbumDao albumDao, SqlConnection connection, SqlTransaction transaction);

        List<AlbumDao?> GetById(int AlbumId, SqlConnection connection, SqlTransaction transaction);

        List<AlbumDao?> GetByIdArtista(int ArtistaId, SqlConnection connection, SqlTransaction transaction);

        List<AlbumDao?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction);

        List<AlbumDao?> GetByDate(DateOnly DataInizio, DateOnly DataFine, SqlConnection connection, SqlTransaction transaction);
        
        List<AlbumDao?> GetByGenere(string Genere, SqlConnection connection, SqlTransaction transaction);

        AlbumDao GetDurataTotale (int AlbumId, SqlConnection connection, SqlTransaction transaction);

        void UpdateById(int AlbumId, AlbumDao albumDao, SqlConnection connection, SqlTransaction transaction);

        void DeleteById(int AlbumId, SqlConnection connection, SqlTransaction transaction);
    }
}
