using Microsoft.Data.SqlClient;
using Music.Models;
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
            string query = @"delete from album                             
                             where album_id = @AlbumId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@AlbumId", AlbumId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"album rimosso; sono state coinvolte {righeCoinvolte} righe");
            }
        }

        public List<Album?> GetByDate(DateOnly DataInizio, DateOnly DataFine, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from album
                             where data_uscita BETWEEN @DataInizio AND @DataFine";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@DataInizio", DataInizio);
                command.Parameters.AddWithValue("@DataFine", DataFine);

                List<Album> album = new List<Album>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Album album1 = new Album();
                        album1.AlbumId = reader.GetInt32(0);
                        album1.Titolo = reader.GetString(1);
                        album1.DataUscita = DateOnly.FromDateTime(reader.GetDateTime(2));
                        album1.Genere = reader.GetString(3);
                        album1.ArtistaId = reader.GetInt32(4);

                        album.Add(album1);

                    }
                    StampaAlbum(album);
                }
                return album;
            }
        }

        public void StampaAlbum(List<Album?> album)
        {
            foreach (var alb in album)
            {
                if (alb != null)
                {
                    Console.WriteLine($"Album ID: {alb.AlbumId}, Titolo: {alb.Titolo}, Data uscita: {alb.DataUscita},  Genere: {alb.Genere},  Artista ID: {alb.ArtistaId}");
                }
            }
        }

        public List<Album?> GetByGenere(string Genere, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from album
                             where genere = @Genere";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Genere", Genere);

                List<Album> album = new List<Album>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Album album1 = new Album();
                        album1.AlbumId = reader.GetInt32(0);
                        album1.Titolo = reader.GetString(1);
                        album1.DataUscita = DateOnly.FromDateTime(reader.GetDateTime(2));
                        album1.Genere = Genere;
                        album1.ArtistaId = reader.GetInt32(4);

                        album.Add(album1);

                    }
                    StampaAlbum(album);
                }
                return album;
            }
        }

        public Album? GetById(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from album
                             where Album_Id = @AlbumId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@AlbumId", AlbumId);

                Album album = new Album();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Album album1 = new Album();
                        album1.AlbumId = AlbumId;
                        album1.Titolo = reader.GetString(1);
                        album1.DataUscita = DateOnly.FromDateTime(reader.GetDateTime(2));
                        album1.Genere = reader.GetString(3);
                        album1.ArtistaId = reader.GetInt32(4);

                        Console.WriteLine(album1);
                    }
                    
                }
                return album;
            }
        }

        public List<Album?> GetByIdArtista(int ArtistaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from album
                             where Artista_Id = @ArtistaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ArtistaId", ArtistaId);

                List<Album> album = new List<Album>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Album album1 = new Album();
                        album1.AlbumId = reader.GetInt32(0);
                        album1.Titolo = reader.GetString(1);
                        album1.DataUscita = DateOnly.FromDateTime(reader.GetDateTime(2));
                        album1.Genere = reader.GetString(3);
                        album1.ArtistaId = ArtistaId;

                        album.Add(album1);

                    }
                    StampaAlbum(album);
                }
                return album;
            }
        }

        public List<Album?> GetByTitolo(string Titolo, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from album
                             where Titolo = @Titolo";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Titolo", Titolo);

                List<Album> album = new List<Album>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Album album1 = new Album();
                        album1.AlbumId = reader.GetInt32(0);
                        album1.Titolo = Titolo;
                        album1.DataUscita = DateOnly.FromDateTime(reader.GetDateTime(2));
                        album1.Genere = reader.GetString(3);
                        album1.ArtistaId = reader.GetInt32(4);

                        album.Add(album1);

                    }
                    StampaAlbum(album);
                }
                return album;
            }
        }

        public Album GetDurataTotale(int AlbumId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select a.titolo, sum(t.durata) as tot_durata 
                             from album a, traccia t 
                             where a.album_id = t.album_id
                             and a.album_id = @albumId
                             group by a.titolo";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@albumId", AlbumId);

                Album album = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        album = new Album();
                        album.Titolo = reader.GetString(0);

                        
                        int durataTot = reader.GetInt32(1);

                        Console.WriteLine($"Durata totale dell'album {album.Titolo} è : {durataTot}");

                    }

                }
                return album;

            }
        }

        public void Save(Album album, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"insert into album (album_id, titolo, data_uscita, genere, artista_id) 
                             values (@albumId, @titolo, @dataUscita, @genere, @artistaId)";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@albumId", album.AlbumId);
                command.Parameters.AddWithValue("@titolo", album.Titolo);
                command.Parameters.AddWithValue("@dataUscita", album.DataUscita);
                command.Parameters.AddWithValue("@genere", album.Genere);
                command.Parameters.AddWithValue("@artistaId", album.ArtistaId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"Album inserito; sono state coinvolte {righeCoinvolte} righe");

            }
        }

        public void UpdateById(int AlbumId, string Titolo, DateOnly dataUscita, string genere, int artistaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"update album
                             set album_id = @albumId, titolo = @titolo, data_uscita = @dataUscita, genere = @genere, artista_id = @artistaId
                             where album_id = @AlbumId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@albumId", AlbumId);
                command.Parameters.AddWithValue("@titolo", Titolo);
                command.Parameters.AddWithValue("@dataUscita", dataUscita);
                command.Parameters.AddWithValue("@genere", genere);
                command.Parameters.AddWithValue("@artistaId", artistaId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"Album aggiornato; sono state coinvolte {righeCoinvolte} righe");

            }

        }
    }
}
