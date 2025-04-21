using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;
using static Virtual_Art_Gallery.Data.IArtistdao;
using static Virtual_Art_Gallery.Models.ArtistException;

namespace Virtual_Art_Gallery.Data
{
    internal class VAGArtistdaoImpl : IArtistdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddArtist(Artist artist)
        {
            int rowsAffected = 0;
            string query = $"insert into artists(artist_id, artist_name, biography, birth_date, nationality, website, contact_information) values (@aid, @aname, @abio, @adob, @anation, @aweb, @acontactinfo)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@aid", artist.ArtistID));
                    command.Parameters.Add(new SqlParameter("@aname", artist.ArtistName));
                    command.Parameters.Add(new SqlParameter("@abio", artist.Biography));
                    command.Parameters.Add(new SqlParameter("@adob", artist.BirthDate));
                    command.Parameters.Add(new SqlParameter("@anation", artist.Nationality));
                    command.Parameters.Add(new SqlParameter("@aweb", artist.Website));
                    command.Parameters.Add(new SqlParameter("@acontactinfo", artist.ContactInformation));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new ArtistException("Artist could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new artist");
            }
            return rowsAffected;
        }

        public int DeleteArtist(int id)
        {
            int rowsAffected = 0;
            string query = "delete from artists where artist_id = @sid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@aid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new ArtistException("Id not found, Couldn't delete artist!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new artist");
            }
            return rowsAffected;
        }

        public List<Artist> GetAllArtists()
        {
            List<Artist> artists = new List<Artist>();
            Artist artist = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from artists";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        artist = new Artist();
                        artist.ArtistID = reader.GetInt32(0);
                        artist.ArtistName = reader.GetString(1);
                        artist.Biography = reader.GetString(2);
                        artist.BirthDate = reader.GetDateTime(3);
                        artist.Nationality = reader.GetString(4);
                        artist.Website = reader.GetString(5);
                        artist.ContactInformation = reader.GetString(6);
                        artists.Add(artist);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return artists;
        }

        public Artist GetArtistByName(string name)
        {
            Artist artist = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from artists where artist_name = @aname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        artist = new Artist();
                        artist.ArtistID = reader.GetInt32(0);
                        artist.ArtistName = reader.GetString(1);
                        artist.Biography = reader.GetString(2);
                        artist.BirthDate = reader.GetDateTime(3);
                        artist.Nationality = reader.GetString(4);
                        artist.Website = reader.GetString(5);
                        artist.ContactInformation = reader.GetString(6);
                    }

                    if (artist == null)
                    {
                        throw new ArtistException("Artist FirstName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given artist firstname: " + e.Message);
                }
            }
            return artist;
        }

        public Artist GetArtistById(int id)
        {
            Artist artist = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from artists where artist_id = @aid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@aid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        artist = new Artist();
                        artist.ArtistID = reader.GetInt32(0);
                        artist.ArtistName = reader.GetString(1);
                        artist.Biography = reader.GetString(2);
                        artist.BirthDate = reader.GetDateTime(3);
                        artist.Nationality = reader.GetString(4);
                        artist.Website = reader.GetString(5);
                        artist.ContactInformation = reader.GetString(6);
                    }

                    if (artist == null)
                    {
                        throw new ArtistException("Artist Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in artist with the given artist id: " + e.Message);
                }
            }
            return artist;
        }

        public int UpdateArtistNation(int id, string new_nation)
        {
            int rowsAffected = 0;
            Artist art1 = GetArtistById(id);
            if (art1 == null)
            {
                throw new ArtistException($"Artist not found for the given artist {id}");
            }
            else
            {
                string query = "update artists set nationality = @anation where artist_id = @aid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@aid", id);
                        command.Parameters.AddWithValue("@anation", new_nation);
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                return rowsAffected;
            }
        }
    }
}
