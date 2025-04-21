using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery
{
    internal class Artist
    {
        public int artistId;
        public string artistName;
        public string biography;
        public DateTime birthDate;
        public string nationality;
        public string website;
        public string contact_information;

        public int ArtistID
        {
            set
            {
                artistId = value;
            }
            get
            {
                return artistId;
            }
        }
        public string ArtistName
        {
            set 
            { 
                artistName = value; 
            }
            get
            {
                return artistName;
            }
        }
        public string Biography
        {
            set
            {
                biography = value;
            }
            get
            {
                return biography;
            }
        }
        public DateTime BirthDate
        {
            set
            {
                birthDate = value;
            }
            get
            {
                return birthDate;
            }
        }
        public string Nationality
        {
            set
            {
                nationality = value;
            }
            get
            {
                return nationality;
            }
        }
        public string Website
        {
            set
            {
                website = value;
            }
            get
            {
                return website;
            }
        }
        public string ContactInformation
        {
            set
            {
                contact_information = value;
            }
            get
            {
                return contact_information;
            }
        }

        public Artist(int artistId, string artistName, string biography, DateTime birthDate, string nationality, string website, string contact_information)
        {
            ArtistID = artistId;
            ArtistName = artistName;
            Biography = biography;
            BirthDate = birthDate;
            Nationality = nationality;
            Website = website;
            ContactInformation = contact_information;
        }

        public Artist()
        {
        }

        public void DisplayArtist()
        {
            Console.WriteLine($"Artist ID: {ArtistID}, Artist Name: {ArtistName}, Artist's Biography: {Biography}, Artist's Date of Birth: {BirthDate}, Artist's Nationality: {Nationality}, Artist's Website: {Website}, Artist's Contact Information: {ContactInformation}");
        }
    }
}
