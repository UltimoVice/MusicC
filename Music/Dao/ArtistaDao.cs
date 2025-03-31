using Microsoft.Data.SqlClient;
using Music.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Music.Dao
{
    public class ArtistaDao : IArtistaDao
    {
        public void DeleteById(int ArtistaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"delete from artista                             
                             where artista_Id = @ArtistaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ArtistaId", ArtistaId);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"artista rimosso; sono state coinvolte {righeCoinvolte} righe");
            }
        }

        public List<Artista?> GetByNazione(string Nazione, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from artista
                             where nazione = @Nazione";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Nazione", Nazione);

                List<Artista> artista = new List<Artista>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artista artisti = new Artista();
                        artisti.ArtistaId = reader.GetInt32(0);
                        artisti.Nome = reader.GetString(1);
                        artisti.Nazione = reader.GetString(2);
                        artisti.AnnoInizio = reader.GetInt32(3);

                        artista.Add(artisti);
                    }
                }
                StampaArtisti(artista);
                return artista;
            }
        }

        public List<Artista?> GetByNome(string Nome, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from artista
                             where nome LIKE @Nome";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Nome", "%" + Nome + "%");

                List<Artista> artista = new List<Artista>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artista artisti = new Artista();
                        artisti.ArtistaId = reader.GetInt32(0);
                        artisti.Nome = reader.GetString(1);
                        artisti.Nazione = reader.GetString(2);
                        artisti.AnnoInizio = reader.GetInt32(3);

                        artista.Add(artisti);
                    }
                }

                StampaArtisti(artista);

                return artista;
            }
        }

        public List<Artista?> GetByPeriodo(int AnnoInizio, int AnnoFine, SqlConnection connection, SqlTransaction transaction)
        {

            string query = @"select * from artista
                             where anno_inizio BETWEEN @AnnoInizio AND @AnnoFine";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@AnnoInizio", AnnoInizio);
                command.Parameters.AddWithValue("@AnnoFine", AnnoFine);

                List<Artista> artista = new List<Artista>();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artista artisti = new Artista();
                        artisti.ArtistaId = reader.GetInt32(0);
                        artisti.Nome = reader.GetString(1);
                        artisti.Nazione = reader.GetString(2);
                        artisti.AnnoInizio = reader.GetInt32(3);

                        artista.Add(artisti);
                        
                    }
                    StampaArtisti(artista);
                }
                return artista;
            }
        }

        public string GetReport(int ArtistaId, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select a.nome, al.titolo, t.titolo 
                             from artista a, traccia t, album al
                             where a.artista_id = al.artista_id
                             and al.album_id = t.album_id
                             and a.artista_id = @ArtistaId";


            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ArtistaId", ArtistaId);

                // Variabile per contenere il report finale
                StringBuilder report = new StringBuilder();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Variabili per tenere traccia dell'artista e degli album
                    string currentArtist = "";
                    List<string> currentAlbums = new List<string>();
                    List<string> currentTracks = new List<string>();

                    while (reader.Read())
                    {
                        string artistName = reader.GetString(0);  // Nome dell'artista
                        string albumTitle = reader.GetString(1);  // Titolo dell'album
                        string trackTitle = reader.GetString(2);  // Titolo della traccia

                        // Se il nome dell'artista cambia, scriviamo il report per l'artista corrente
                        if (artistName != currentArtist)
                        {
                            if (currentArtist != "")
                            {
                                // Aggiungi gli album e le tracce del vecchio artista al report
                                report.AppendLine($"Artista: {currentArtist}");
                                foreach (var album in currentAlbums)
                                {
                                    report.AppendLine($" Album: {album}");
                                    foreach (var track in currentTracks)
                                    {
                                        report.AppendLine($" Traccia: {track}");
                                    }
                                }
                            }

                            // Resetta per il nuovo artista
                            currentArtist = artistName;
                            currentAlbums.Clear();
                            currentTracks.Clear();
                        }

                        // Aggiungi album e traccia alla lista dell'artista
                        if (!currentAlbums.Contains(albumTitle))
                        {
                            currentAlbums.Add(albumTitle);
                        }
                        currentTracks.Add(trackTitle);
                    }

                    // Aggiungi il report dell'ultimo artista
                    if (currentArtist != "")
                    {
                        report.AppendLine($"Artista: {currentArtist}");
                        foreach (var album in currentAlbums)
                        {
                            report.AppendLine($"  Album: {album}");
                            foreach (var track in currentTracks)
                            {
                                report.AppendLine($"    Traccia: {track}");
                            }
                        }
                    }
                }

                // Restituisci il report formattato
                return report.ToString();
            }
        }

        public void Save(Artista artista, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"insert into artista (artista_id, nome, nazione, anno_inizio) 
                             values (@ArtistaId, @Nome, @Nazione, @AnnoInizio)";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ArtistaId", artista.ArtistaId);
                command.Parameters.AddWithValue("@Nome", artista.Nome);
                command.Parameters.AddWithValue("@Nazione", artista.Nazione);
                command.Parameters.AddWithValue("@AnnoInizio", artista.AnnoInizio);

                int righeCoinvolte = command.ExecuteNonQuery();

                Console.WriteLine($"artista inserito; sono state coinvolte {righeCoinvolte} righe");

            }
        }

        public void UpdateById(int ArtistaId, string Nome, string Nazione, int AnnoInizio, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"update artista
                             set artista_id = @ArtistaId, nome = @Nome, nazione = @Nazione, anno_inizio = @AnnoInizio
                             where artista_id = @ArtistaId";

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@ArtistaId", ArtistaId);
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@Nazione", Nazione);
                command.Parameters.AddWithValue("@AnnoInizio", AnnoInizio);

                int righeCoinvolte = command.ExecuteNonQuery(); //esegue la transazione

                Console.WriteLine($"noleggio aggiornato; sono state coinvolte{righeCoinvolte} righe");
            }
        }
        public void StampaArtisti(List<Artista?> artisti)
        {
            foreach (var artista in artisti)
            {
                if (artista != null)
                {
                    Console.WriteLine($"ID: {artista.ArtistaId}, Nome: {artista.Nome}, Nazione: {artista.Nazione}, Anno Inizio: {artista.AnnoInizio}");
                }
            }
        }

        public Artista? GetById(int idArtista, SqlConnection connection, SqlTransaction transaction)
        {
            string query = @"select * from artista
                             where artista_id = @IdArtista"
            ;

            using (SqlCommand command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdArtista", idArtista);

                Artista artista = null;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        artista = new Artista();
                        artista.ArtistaId = reader.GetInt32(0);
                        artista.Nome = reader.GetString(1);
                        artista.Nazione = reader.GetString(2);
                        artista.AnnoInizio = reader.GetInt32(3);
                    }
                }
                return artista;
            }
        }
    }
}
