using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public interface ITracciaDao
    {
        void Save(TracciaDao tracciaDao, SqlConnection connection, SqlTransaction transaction);

        List<TracciaDao?> GetByAlbumId(int AlbumId, SqlConnection connection, SqlTransaction transaction);

        List<TracciaDao?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction);

        void UpdateById(int ArtistaId, ArtistaDao artistaDao, SqlConnection connection, SqlTransaction transaction);

        void DeleteById(int ArtistaId, SqlConnection connection, SqlTransaction transaction);
    }
}
