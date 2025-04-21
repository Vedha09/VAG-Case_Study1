using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery
{
    internal class User
    {
        public int userId;
        public string username;
        public string password;
        public string email;
        public string firstName;
        public string lastName;
        public DateTime dateOfBirth;
        public string profilePicture;
        public IEnumerable<Art_Work> favorite_artworks;

        public int UserID
        {
            set
            {
                userId = value;
            }
            get
            {
                return userId;
            }
        }
        public string Username
        {
            set
            {
                username = value;
            }
            get
            {
                return username;
            }
        }
        public string Password
        {
            set
            {
                password = value;
            }
            get
            {
                return password;
            }
        }
        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string FirstName
        {
            set
            {
                firstName = value;
            }
            get
            {
                return firstName;
            }
        }
        public string LastName
        {
            set
            {
                lastName = value;
            }
            get
            {
                return lastName;
            }
        }
        public DateTime DateOfBirth
        {
            set
            {
                dateOfBirth = value;
            }
            get
            {
                return dateOfBirth;
            }
        }
        public string ProfilePicture
        {
            set
            {
                profilePicture = value;
            }
            get
            {
                return profilePicture;
            }
        }
        public IEnumerable<Art_Work> FavoriteArtworks
        {
            set
            {
                favorite_artworks = value;
            }
            get
            {
                return favorite_artworks;
            }
        }

        public User(int userId, string userName, string password, string email, string firstName, string lastName, DateTime dateOfBirth, string profilePicture, IEnumerable<Art_Work> favorite_artworks)
        {
            UserID = userId;
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            ProfilePicture = profilePicture;
            FavoriteArtworks = favorite_artworks;
        }

        public User()
        {
        }

        public void DisplayUserDetails()
        {
            Console.WriteLine($"User ID: {UserID}, User Name: {Username}, User Password: {Password}, User Email: {Email}, User's First Name: {FirstName}, User's Last Name: {LastName}, Date of Birth: {DateOfBirth}, User's Profile Picture: {ProfilePicture}, Favorite Artworks referred by User: ");

            foreach(var a in FavoriteArtworks)
            {
                Console.WriteLine($" --- Artwork's ID - {a.ArtworkID}: Artwork Title - {a.Title}");
            }
        }
    }
}
