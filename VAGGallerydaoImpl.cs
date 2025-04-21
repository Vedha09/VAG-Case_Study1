using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Virtual_Art_Gallery.Models;
using static Virtual_Art_Gallery.Data.IGallerydao;


namespace Virtual_Art_Gallery.Data
{
    internal class VAGGallerydaoImpl : IGallerydao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddGallery(Gallery gallery)
        {
            int rowsAffected = 0;
            string query = $"insert into galleries(gallery_id, gallery_name, decription, location, opening_hours, curator) values (@gid, @gname, @gdesc, @gloc, @gopeninghrs, @gcurator)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@sid", gallery.GalleryID));
                    command.Parameters.Add(new SqlParameter("@sfirstname", gallery.GalleryName));
                    command.Parameters.Add(new SqlParameter("@slastname", gallery.Description));
                    command.Parameters.Add(new SqlParameter("@sdateofbirth", gallery.Location));
                    command.Parameters.Add(new SqlParameter("@semail", gallery.OpeningHours));
                    command.Parameters.Add(new SqlParameter("@sphonenumber", gallery.Curator));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new GalleryException("Gallery could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new gallery");
            }
            return rowsAffected;
        }

        public int DeleteGallery(int id)
        {
            int rowsAffected = 0;
            string query = "delete from galleries where gallery_id = @gid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@gid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new GalleryException("Id not found, Couldn't delete gallery!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new gallery");
            }
            return rowsAffected;
        }

        public List<Gallery> GetAllGalleries()
        {
            List<Gallery> galleries = new List<Gallery>();
            Gallery gallery = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from galleries";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gallery = new Gallery();
                        gallery.GalleryID = reader.GetInt32(0);
                        gallery.GalleryName = reader.GetString(1);
                        gallery.Description = reader.GetString(2);
                        gallery.Location = reader.GetString(3);
                        gallery.OpeningHours = reader.GetString(4);
                        gallery.Curator = GetCuratorByGalleryId(gallery.GalleryID);
                        galleries.Add(gallery);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return galleries;
        }

        public Gallery GetGalleryByName(string name)
        {
            Gallery gallery = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from galleries where gallery_name = @gname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@gname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gallery = new Gallery();
                        gallery.GalleryID = reader.GetInt32(0);
                        gallery.GalleryName = reader.GetString(1);
                        gallery.Description = reader.GetString(2);
                        gallery.Location = reader.GetString(3);
                        gallery.OpeningHours = reader.GetString(4);
                        gallery.Curator = GetCuratorByGalleryId(gallery.GalleryID);
                    }

                    if (gallery == null)
                    {
                        throw new GalleryException("Gallery Name not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given gallery name: " + e.Message);
                }
            }
            return gallery;
        }

        public Gallery GetGalleryByLocation(string loc)
        {
            Gallery gallery = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from galleries where location = @gloc";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@gloc", loc);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gallery = new Gallery();
                        gallery.GalleryID = reader.GetInt32(0);
                        gallery.GalleryName = reader.GetString(1);
                        gallery.Description = reader.GetString(2);
                        gallery.Location = reader.GetString(3);
                        gallery.OpeningHours = reader.GetString(4);
                        gallery.Curator = GetCuratorByGalleryId(gallery.GalleryID);
                    }

                    if (gallery == null)
                    {
                        throw new GalleryException("Gallery Location not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given gallery location: " + e.Message);
                }
            }
            return gallery;
        }

        public Gallery GetGalleryById(int id)
        {
            Gallery gallery = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from galleries where gallery_id = @gid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@gid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gallery = new Gallery();
                        gallery.GalleryID = reader.GetInt32(0);
                        gallery.GalleryName = reader.GetString(1);
                        gallery.Description = reader.GetString(2);
                        gallery.Location = reader.GetString(3);
                        gallery.OpeningHours = reader.GetString(4);
                        gallery.Curator = GetCuratorByGalleryId(gallery.GalleryID);
                    }

                    if (gallery == null)
                    {
                        throw new GalleryException("Gallery Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in gallery with the given gallery id: " + e.Message);
                }
            }
            return gallery;
        }

        public IEnumerable<Artist_Curator> GetCuratorByGalleryId(int gId)
        {
            Gallery gallery = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from galleries where gallery_id = @gid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@gid", gId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        gallery = new Gallery();
                        gallery.GalleryID = reader.GetInt32(0);
                        gallery.GalleryName = reader.GetString(1);
                        gallery.Description = reader.GetString(2);
                        gallery.Location = reader.GetString(3);
                        gallery.OpeningHours = reader.GetString(4);
                        gallery.Curator = GetCuratorByGalleryId(gallery.GalleryID);
                    }

                    if (gallery == null)
                    {
                        throw new GalleryException("Gallery Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in gallery with the given gallery id: " + e.Message);
                }
            }
            return (IEnumerable<Artist_Curator>)gallery;
        }

        public int UpdateGalleryDescription(int id, string new_desc)
        {
            int rowsAffected = 0;
            Gallery gal = GetGalleryById(id);
            if (gal == null)
            {
                throw new GalleryException($"Gallery not found for the given gallery {id}");
            }
            else
            {
                string query = "update galleries set description = @gdesc where gallery_id = @gid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@gid", id);
                        command.Parameters.AddWithValue("@gdesc", new_desc);
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
