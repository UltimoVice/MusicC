using Microsoft.Data.SqlClient;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public interface ITracciaDao
    {
        void Save(Traccia traccia, SqlConnection connection, SqlTransaction transaction);
        Traccia? GetByTracciaId(int tracciaId, SqlConnection connection, SqlTransaction transaction);
        List<Traccia?> GetByAlbumId(int AlbumId, SqlConnection connection, SqlTransaction transaction);
        List<Traccia?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction);
        void UpdateById(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId, SqlConnection connection, SqlTransaction transaction);
        void DeleteById(int tracciaId, SqlConnection connection, SqlTransaction transaction);
    }
}
