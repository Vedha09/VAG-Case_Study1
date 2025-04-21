using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Virtual_Art_Gallery.Data.IArtworkdao;
using System.Data.SqlClient;
using Virtual_Art_Gallery.Models;
using static Virtual_Art_Gallery.Models.ArtworkException;

namespace Virtual_Art_Gallery.Data
{
    internal class VAGArtworkdaoImpl
    {
        internal class ArtworksDaoImpl : IArtworkdao
        {
            SqlConnection con = null;
            SqlCommand command = null;

            public int AddArtwork(Artwork artwork)
            {
                int rowsAffected = 0;
                string query = $"insert into artworks(artwork_id, title, description, creation_date, medium, imageurl) values (@awid, @awtitle, @awdesc, @awc_date, @awmed, @awiurl)";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.Add(new SqlParameter("@awid", artwork.ArtWorkID));
                        command.Parameters.Add(new SqlParameter("@awtitle", artwork.Title));
                        command.Parameters.Add(new SqlParameter("@awdesc", artwork.Description));
                        command.Parameters.Add(new SqlParameter("@awc_date", artwork.CreationDate));
                        command.Parameters.Add(new SqlParameter("@awmed", artwork.Medium));
                        command.Parameters.Add(new SqlParameter("@awiurl", artwork.ImageUrl));
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    if (rowsAffected <= 0)
                    {
                        throw new ArtworkException("Artwork could not be added!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error in adding a new artwork");
                }
                return rowsAffected;
            }

            public int DeleteArtwork(int id)
            {
                int rowsAffected = 0;
                string query = "delete from artworks where artwork_id = @awid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.Add(new SqlParameter("@awid", id));
                        rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected <= 0)
                        {
                            throw new ArtworkException("Id not found, Couldn't delete artwork!!");
                        }
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error in deleting a new artwork");
                }
                return rowsAffected;
            }

            public List<Artwork> GetAllArtworks()
            {
                List<Artwork> artworks = new List<Artwork>();
                Artwork artwork = null;
                SqlConnection con = null;
                SqlCommand command = null;
                string query = "select * from artworks";

                using (con = DBUtility.GetConnection())
                {
                    try
                    {
                        command = new SqlCommand(query, con);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            artwork = new Artwork();
                            artwork.ArtWorkID = reader.GetInt32(0);
                            artwork.Title = reader.GetString(1);
                            artwork.Description = reader.GetString(2);
                            artwork.CreationDate = reader.GetDateTime(3);
                            artwork.Medium = reader.GetString(4);
                            artwork.ImageUrl = reader.GetString(5);
                            artworks.Add(artwork);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                return artworks;
            }

            public Artwork GetArtworkByTitle(string title)
            {
                Artwork artwork = null;
                SqlConnection con = null;
                SqlCommand command = null;
                string query = "select * from artworks where title = @awtitle";

                using (con = DBUtility.GetConnection())
                {
                    try
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@awtitle", title);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            artwork = new Artwork();
                            artwork.ArtWorkID = reader.GetInt32(0);
                            artwork.Title = reader.GetString(1);
                            artwork.Description = reader.GetString(2);
                            artwork.CreationDate = reader.GetDateTime(3);
                            artwork.Medium = reader.GetString(4);
                            artwork.ImageUrl = reader.GetString(5);
                        }

                        if (artwork == null)
                        {
                            throw new ArtworkException("Artwork Title not found!!");
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error fetching with the given artwork title: " + e.Message);
                    }
                }
                return artwork;
            }

            public Artwork GetArtworkById(int id)
            {
                Artwork artwork = null;
                SqlConnection con = null;
                SqlCommand command = null;
                string query = "select * from artworks where artwork_id = @awid";

                using (con = DBUtility.GetConnection())
                {
                    try
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@awid", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            artwork = new Artwork();
                            artwork.ArtWorkID = reader.GetInt32(0);
                            artwork.Title = reader.GetString(1);
                            artwork.Description = reader.GetString(2);
                            artwork.CreationDate = reader.GetDateTime(3);
                            artwork.Medium = reader.GetString(4);
                            artwork.ImageUrl = reader.GetString(5);
                        }

                        if (artwork == null)
                        {
                            throw new ArtworkException("Artwork Id not found!!");
                        }
                    }
                    catch (SqlException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error fetching in artwork with the given artwork id: " + e.Message);
                    }
                }
                return artwork;
            }

            public int UpdateArtworkMedium(int id, string new_med)
            {
                int rowsAffected = 0;
                Artwork art = GetArtworkById(id);
                if (art == null)
                {
                    throw new ArtworkException($"Artwork not found for the given artwork {id}");
                }
                else
                {
                    string query = "update artworks set medium = @awmed where artwork_id = @awid";
                    try
                    {
                        using (con = DBUtility.GetConnection())
                        {
                            command = new SqlCommand(query, con);
                            command.Parameters.AddWithValue("@awid", id);
                            command.Parameters.AddWithValue("@awmed", new_med);
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
}
