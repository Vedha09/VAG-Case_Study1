using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;
using static Virtual_Art_Gallery.Models.UserException;
using static Virtual_Art_Gallery.Data.IUserdao;
using System.Data.SqlClient;

namespace Virtual_Art_Gallery.Data
{
    internal class VAGUserdaoImpl : IUserdao
    {
        SqlConnection con = null;
        SqlCommand command = null;

        public int AddUser(User user)
        {
            int rowsAffected = 0;
            string query = $"insert into users(user_id, usename, password, email, first_name, last_name, date_of_birth, profile_picture, favorite_artworks) values (@uid, @uname, @upassword, @uemail, @ufname, @ulname, @udop, @udp, @ufavartworks)";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@uid", user.UserID));
                    command.Parameters.Add(new SqlParameter("@uname", user.Username));
                    command.Parameters.Add(new SqlParameter("@upassword", user.Password));
                    command.Parameters.Add(new SqlParameter("@ufname", user.FirstName));
                    command.Parameters.Add(new SqlParameter("@ulname", user.LastName));
                    command.Parameters.Add(new SqlParameter("@uemail", user.Email));
                    command.Parameters.Add(new SqlParameter("@udop", user.DateOfBirth));
                    command.Parameters.Add(new SqlParameter("@udp", user.ProfilePicture));
                    command.Parameters.Add(new SqlParameter("@ufavartworks", user.FavoriteArtworks));
                    rowsAffected = command.ExecuteNonQuery();
                }
                if (rowsAffected <= 0)
                {
                    throw new UserException("User could not be added!!");
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in adding a new user");
            }
            return rowsAffected;
        }

        public int DeleteUser(int id)
        {
            int rowsAffected = 0;
            string query = "delete from users where user_id = @sid";
            try
            {
                using (con = DBUtility.GetConnection())
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.Add(new SqlParameter("@sid", id));
                    rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected <= 0)
                    {
                        throw new UserException("Id not found, Couldn't delete user!!");
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new Exception("Error in deleting a new user");
            }
            return rowsAffected;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            User user = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from users";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(2);
                        user.FirstName = reader.GetString(4);
                        user.LastName = reader.GetString(5);
                        user.DateOfBirth = reader.GetDateTime(6);
                        user.ProfilePicture = reader.GetString(7);
                        user.FavoriteArtworks = GetFavoriteArtworksByUserId(user.UserID);
                        users.Add(user);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return users;
        }

        public User GetUserByFirstName(string name)
        {
            User user = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from users where first_name = @ufname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@ufname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        
                    }

                    if (user == null)
                    {
                        throw new UserException("User FirstName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given user firstname: " + e.Message);
                }
            }
            return user;
        }

        public User GetUserByLastName(string name)
        {
            User user = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from users where last_name = @ulname";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@ulname", name);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(2);
                        user.FirstName = reader.GetString(4);
                        user.LastName = reader.GetString(5);
                        user.DateOfBirth = reader.GetDateTime(6);
                        user.ProfilePicture = reader.GetString(7);
                        user.FavoriteArtworks = GetFavoriteArtworksByUserId(user.UserID);
                    }

                    if (user == null)
                    {
                        throw new UserException("User LastName not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching with the given user lastname: " + e.Message);
                }
            }
            return user;
        }

        public User GetUserById(int id)
        {
            User user = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from users where user_id = @uid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@uid", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(2);
                        user.FirstName = reader.GetString(4);
                        user.LastName = reader.GetString(5);
                        user.DateOfBirth = reader.GetDateTime(6);
                        user.ProfilePicture = reader.GetString(7);
                        user.FavoriteArtworks = GetFavoriteArtworksByUserId(user.UserID);
                    }

                    if (user == null)
                    {
                        throw new UserException("User Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in user with the given user id: " + e.Message);
                }
            }
            return user;
        }

        public IEnumerable<Art_Work> GetFavoriteArtworksByUserId(int uId)
        {
            User user = null;
            SqlConnection con = null;
            SqlCommand command = null;
            string query = "select * from users where user_id = @uid";

            using (con = DBUtility.GetConnection())
            {
                try
                {
                    command = new SqlCommand(query, con);
                    command.Parameters.AddWithValue("@uid", uId);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user = new User();
                        user.UserID = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.Email = reader.GetString(2);
                        user.FirstName = reader.GetString(4);
                        user.LastName = reader.GetString(5);
                        user.DateOfBirth = reader.GetDateTime(6);
                        user.ProfilePicture = reader.GetString(7);
                        user.FavoriteArtworks = GetFavoriteArtworksByUserId(user.UserID);
                    }

                    if (user == null)
                    {
                        throw new UserException("User Id not found!!");
                    }
                }
                catch (SqlException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw new Exception("Error fetching in user with the given user id: " + e.Message);
                }
            }
            return (IEnumerable<Art_Work>)user;
        }
        
        public int UpdateUserProfilePicture(int id, string new_dp)
        {
            int rowsAffected = 0;
            User usr = GetUserById(id);
            if (usr == null)
            {
                throw new UserException($"User not found for the given user {id}");
            }
            else
            {
                string query = "update users set profile_picture = @udp where user_id = @uid";
                try
                {
                    using (con = DBUtility.GetConnection())
                    {
                        command = new SqlCommand(query, con);
                        command.Parameters.AddWithValue("@uid", id);
                        command.Parameters.AddWithValue("@udp", new_dp);
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
