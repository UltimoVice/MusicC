using Microsoft.Data.SqlClient;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public interface IArtistaDao
    {
        void Save(Artista artista, SqlConnection connection, SqlTransaction transaction);

        Artista? GetById(int idArtista, SqlConnection connection, SqlTransaction transaction);
        List<Artista?> GetByNome(string Nome, SqlConnection connection, SqlTransaction transaction);

        List<Artista?> GetByNazione(string Nazione, SqlConnection connection, SqlTransaction transaction);

        List<Artista?> GetByPeriodo(int AnnoInizio, int AnnoFine, SqlConnection connection, SqlTransaction transaction);

        string GetReport(int ArtistaId, SqlConnection connection, SqlTransaction transaction);

        void UpdateById(int ArtistaId, string Nome, string Nazione, int AnnoInizio, SqlConnection connection, SqlTransaction transaction);

        void DeleteById(int ArtistaId, SqlConnection connection, SqlTransaction transaction);
    }
}
