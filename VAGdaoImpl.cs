using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Virtual_Art_Gallery.Data.IVirtualArtGallery;
using Virtual_Art_Gallery.Models;
using static Virtual_Art_Gallery.Models.ArtWorkNotFoundException;
using static Virtual_Art_Gallery.Models.UserNotFoundException;

namespace Virtual_Art_Gallery.Data
{
    internal class VAGdaoImpl : IVirtualArtGallery
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public bool AddArtwork(Artwork1 artwork)
        {
            string query = "insert into artworkdetails(artwork_id, title, description, artist, created_date) values (@auid, @autitle, @audescription, @auartist, @aucdate)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@auid", artwork.ArtworkId);
                    command.Parameters.AddWithValue("@autitle", artwork.Title);
                    command.Parameters.AddWithValue("@audescription", artwork.Description);
                    command.Parameters.AddWithValue("@auartist", artwork.Artist);
                    command.Parameters.AddWithValue("@aucdate", artwork.CreatedDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArtWorkNotFoundException("Artwork could not be added!!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new artwork: " + e.Message);
            }
        }

        public bool UpdateArtwork(Artwork1 artwork)
        {
            string query = "update artworkdetails set title=@autitle, description=@audescription, artist=@auartist, created_date=@aucdate where artwork_id=@auid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@auid", artwork.ArtworkId);
                    command.Parameters.AddWithValue("@autitle", artwork.Title);
                    command.Parameters.AddWithValue("@audescription", artwork.Description);
                    command.Parameters.AddWithValue("@auartist", artwork.Artist);
                    command.Parameters.AddWithValue("@aucdate", artwork.CreatedDate);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArtWorkNotFoundException("Artwork could not be updated!!");
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
            string query = "delete from artworkdetails where artwork_id = @auid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@auid", artworkId);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArtWorkNotFoundException("Artwork not found or could not be deleted!!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting artwork: " + e.Message);
            }
        }

        public Artwork1 GetArtworkById(int artworkId)
        {
            Artwork1 artwork = null;
            string query = "select * from artworkdetails where artwork_id = @auid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@auid", artworkId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        artwork = new Artwork1
                        {
                            ArtworkId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Artist = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4)
                        };
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving artwork: " + e.Message);
            }
            return artwork;
        }

        public List<Artwork1> SearchArtworks(string keyword)
        {
            List<Artwork1> artworks = new List<Artwork1>();
            string query = "select * from artworkdetails where title like @keyword or description like @keyword";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        artworks.Add(new Artwork1
                        {
                            ArtworkId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Artist = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4)
                        });
                    }
                    if (artworks == null)
                    {
                        throw new ArtWorkNotFoundException("Artwork Id not found!!");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error searching artworks: " + e.Message);
            }
            return artworks;
        }

        public bool AddArtworkToFavorite(int userId, int artworkId)
        {
            string query = "insert into user_favorites(user_id, artwork_id) values (@uid, @auid)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@uid", userId);
                    command.Parameters.AddWithValue("@auid", artworkId);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new ArtWorkNotFoundException("By Artwork Id not add favorite.");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error adding to favorites: " + e.Message);
            }
        }

        public bool RemoveArtworkFromFavorite(int userId, int artworkId)
        {
            string query = "delete from user_favorites where user_id = @uid and artwork_id = @auid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@uid", userId);
                    command.Parameters.AddWithValue("@auid", artworkId);
                    if (command.ExecuteNonQuery() <= 0)
                    {
                        throw new UserNotFoundException("Favorite not found or could not be removed.");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error removing from favorites: " + e.Message);
            }
        }

        public List<Artwork1> GetUserFavoriteArtworks(int userId)
        {
            List<Artwork1> favorites = new List<Artwork1>();
            string query = "select a.* from artworks a join user_favorites uf on a.artwork_id = uf.artwork_id where uf.user_id = @uid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@uid", userId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        favorites.Add(new Artwork1
                        {
                            ArtworkId = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Artist = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4)
                        });
                    }
                }
                if (favorites == null)
                {
                    throw new UserNotFoundException("User Id not found!!");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error retrieving user favorites: " + e.Message);
            }
            return favorites;
        }
    }
}
