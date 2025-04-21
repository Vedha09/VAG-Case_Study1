using System.Data.SqlClient;
using System.Net;
using static VirtualArtGalleryTests.DBUtilityTests;
using static VirtualArtGalleryTests.IVirtualArtGallery;

namespace VirtualArtGalleryTests
{
    internal class VirtualArtGalleryImpl : IVirtualArtGallery
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public bool AddArtwork(ArtworkManagement artwork)
        {
            string query = "INSERT INTO artworkmanagements(artwork_id, title, description, artist, created_date) VALUES(@amid, @amtitle, @amdescription, @amartist, @amyear)";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@amid", artwork.ArtworkId);
                    command.Parameters.AddWithValue("@amtitle", artwork.Title);
                    command.Parameters.AddWithValue("@amdescription", artwork.Description);
                    command.Parameters.AddWithValue("@amartist", artwork.Artist);
                    command.Parameters.AddWithValue("@amyear", artwork.CreatedDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Artwork could not be added!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new artwork: " + e.Message);
            }
        }

        public bool UpdateArtwork(ArtworkManagement artwork)
        {
            string query = "UPDATE artworkmanagements SET title=@amtitle, description=@amdescription, artist=@amartist, created_date=@year WHERE artwork_id=@amid";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@amid", artwork.ArtworkId);
                    command.Parameters.AddWithValue("@amtitle", artwork.Title);
                    command.Parameters.AddWithValue("@amdescription", artwork.Description);
                    command.Parameters.AddWithValue("@amartist", artwork.Artist);
                    command.Parameters.AddWithValue("@amyear", artwork.CreatedDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Artwork could not be updated!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error updating artwork: " + e.Message);
            }
        }

        public bool RemoveArtwork(int artworkId)
        {
            string query = "DELETE FROM artworkmanagements WHERE artwork_id = @amid";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@amid", artworkId);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Artwork not found or could not be deleted!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting artwork: " + e.Message);
            }
        }

        public void GetArtworkById(int artworkId)
        {
            ArtworkManagement artwork = null;
            string query = "SELECT * FROM artworkmanagements WHERE artwork_id = @amid";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@amid", artworkId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        artwork = new ArtworkManagement
                        {
                            ArtworkId = reader.GetInt32(reader.GetOrdinal("artwork_id")),
                            Title = reader.GetString(reader.GetOrdinal("title")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            Artist = reader.GetString(reader.GetOrdinal("artist")),
                            CreatedDate = reader.GetDateTime(reader.GetOrdinal("created_date"))
                        };
                    }
                }
                if (artwork == null)
                {
                    throw new Exception("Artwork not found!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving artwork: " + e.Message);
            }
        }

        public bool GetArtworkById(ArtworkManagement artwork)
        {
            string query = "SELECT * FROM artworkmanagements WHERE artwork_id = @amid";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@amid", artwork.ArtworkId);
                    command.Parameters.AddWithValue("@amtitle", artwork.Title);
                    command.Parameters.AddWithValue("@amdescription", artwork.Description);
                    command.Parameters.AddWithValue("@amartist", artwork.Artist);
                    command.Parameters.AddWithValue("@amyear", artwork.CreatedDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new Exception("Artwork could not be added!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new artwork: " + e.Message);
            }
        }

        public List<ArtworkManagement> SearchArtworks(string keyword)
        {
            List<ArtworkManagement> artworks = new List<ArtworkManagement>();
            string query = "SELECT * FROM artworks WHERE title LIKE @keyword OR description LIKE @keyword";
            try
            {
                using (con = DBUtilityTests.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        artworks.Add(new ArtworkManagement
                        {
                            ArtworkId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Artist = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4)
                        });
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error searching artworks: " + e.Message);
            }
            return artworks;
        }
    }
}
