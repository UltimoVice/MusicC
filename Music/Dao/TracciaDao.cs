using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public class TracciaDao : ITracciaDao
    {
        public void DeleteById(int ArtistaId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<TracciaDao?> GetByAlbumId(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public List<TracciaDao?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Save(TracciaDao tracciaDao, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int ArtistaId, ArtistaDao artistaDao, SqlConnection connection, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
