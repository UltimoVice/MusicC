using Microsoft.Data.SqlClient;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public interface IAlbumDao
    {
        void Save(Album album, SqlConnection connection, SqlTransaction transaction);

        Album? GetById(int AlbumId, SqlConnection connection, SqlTransaction transaction);

        List<Album?> GetByIdArtista(int ArtistaId, SqlConnection connection, SqlTransaction transaction);

        List<Album?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction);

        List<Album?> GetByDate(DateOnly DataInizio, DateOnly DataFine, SqlConnection connection, SqlTransaction transaction);
        
        List<Album?> GetByGenere(string Genere, SqlConnection connection, SqlTransaction transaction);

        Album GetDurataTotale (int AlbumId, SqlConnection connection, SqlTransaction transaction);

        void UpdateById(int AlbumId, string Titolo, DateOnly dataUscita, string genere, int artistaId, SqlConnection connection, SqlTransaction transaction);

        void DeleteById(int AlbumId, SqlConnection connection, SqlTransaction transaction);
    }
}
