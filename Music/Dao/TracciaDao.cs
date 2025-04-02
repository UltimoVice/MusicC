using Microsoft.Data.SqlClient;
using Music.Connection;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.Dao
{
    public class TracciaDao : ITracciaDao
    {
        public void DeleteById(int tracciaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"delete from traccia                             
                             where traccia_Id = @tracciaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@tracciaId", tracciaId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"traccia rimosso; sono state coinvolte {righeCoinvolte} righe");
            }
        }
        public Traccia? GetByTracciaId(int tracciaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from traccia
                             where traccia_Id = @tracciaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@tracciaId", tracciaId);

                Traccia traccia = new Traccia();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Traccia traccia1 = new Traccia();
                        traccia1.TracciaId = tracciaId;
                        traccia1.NumeroTraccia = reader.GetInt32(1);
                        traccia1.Titolo = reader.GetString(2);
                        traccia1.Durata = reader.GetInt32(3);
                        traccia1.AlbumId = reader.GetInt32(4);

                        Console.WriteLine(traccia1);
                    }

                }
                return traccia;
            }
        }

        public List<Traccia?> GetByAlbumId(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from traccia
                             where album_id = @AlbumId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@AlbumId", AlbumId);

                List<Traccia> traccia = new List<Traccia>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Traccia traccia1 = new Traccia();
                        traccia1.AlbumId = AlbumId;
                        traccia1.TracciaId = reader.GetInt32(0);
                        traccia1.NumeroTraccia = reader.GetInt32(1);
                        traccia1.Durata = reader.GetInt32(3);
                        traccia1.Titolo = reader.GetString(2);

                        traccia.Add(traccia1);

                    }
                    StampaTraccie(traccia);
                }
                return traccia;
            }

        }
        public void StampaTraccie(List<Traccia?> traccia)
        {
            foreach (var track in traccia)
            {
                if (track != null)
                {
                    Console.WriteLine($"Traccia ID: {track.TracciaId}, Numero traccia: {track.NumeroTraccia}, Titolo: {track.Titolo},  Durata: {track.Durata},  Album ID: {track.AlbumId}");
                }
            }
        }

        public List<Traccia?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from traccia
                             where titolo LIKE @titolo";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@titolo", "%" + Titolo + "%");

                List<Traccia> traccia = new List<Traccia>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Traccia traccia1 = new Traccia();
                        traccia1.AlbumId = reader.GetInt32(4); 
                        traccia1.TracciaId = reader.GetInt32(0);
                        traccia1.NumeroTraccia = reader.GetInt32(1);
                        traccia1.Durata = reader.GetInt32(3);
                        traccia1.Titolo = reader.GetString(2);

                        traccia.Add(traccia1);

                    }
                    StampaTraccie(traccia);
                }
                return traccia;
            }
        }

        public void Save(Traccia traccia, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"insert into traccia (traccia_id,numero_traccia, titolo, durata, album_id) 
                             values (@tracciaId,@numeroTraccia, @titolo, @durata,  @albumId)";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@tracciaId", traccia.TracciaId);
                command.Parameters.AddWithValue("@numeroTraccia", traccia.NumeroTraccia);
                command.Parameters.AddWithValue("@titolo", traccia.Titolo);
                command.Parameters.AddWithValue("@durata", traccia.Durata);
                command.Parameters.AddWithValue("@albumId", traccia.AlbumId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"Traccia inserito; sono state coinvolte {righeCoinvolte} righe");

            }
        }

        public void UpdateById(int tracciaId, int numeroTraccia, string titolo, int durata, int albumId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"update traccia
                             set traccia_id = @tracciaId, numero_traccia = @numeroTraccia, titolo = @titolo, durata = @durata, album_id = @albumId
                             where traccia_id = @tracciaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@tracciaId", tracciaId);
                command.Parameters.AddWithValue("@numeroTraccia", numeroTraccia);
                command.Parameters.AddWithValue("@titolo", titolo);
                command.Parameters.AddWithValue("@durata", durata);
                command.Parameters.AddWithValue("@albumId", albumId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"Traccia aggiornata; sono state coinvolte {righeCoinvolte} righe");

            }
        }
    }
}
