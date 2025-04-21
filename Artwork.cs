using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;

namespace Virtual_Art_Gallery
{
    internal class Artwork
    {
        public int artWorkId;
        public string title;
        public string description;
        public DateTime creationDate;
        public string medium;
        public string imageurl;
        public int ArtWorkID
        {
            set
            {
                artWorkId = value;
            }
            get 
            { 
                return artWorkId;
            }
        }
        public string Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }
        public string Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }
        public DateTime CreationDate
        {
            set
            {
                creationDate = value;
            }
            get
            {
                return creationDate;
            }
        }
        public string Medium
        {
            set
            {
                medium = value;
            }
            get
            {
                return medium;
            }
        }
        public virtual string ImageUrl
        {
            set
            {
                imageurl = value;
            }
            get
            {
                return imageurl;
            }
        }

        public Artwork(int artWorkId, string title, string description, DateTime creationDate, string medium, string imageurl)
        {
            ArtWorkID = artWorkId;
            Title = title;
            Description = description;
            CreationDate = creationDate;
            Medium = medium;
            ImageUrl = imageurl;
        }

        public Artwork()
        {
        }

        public void DisplayArtWork()
        {
            Console.WriteLine($"ArtWork ID: {ArtWorkID}, ArtWork Title: {Title}, ArtWork Description: {Description}, It's Creation Date: {CreationDate}, ArtWork Medium: {Medium}, ArtWork ImageURL : {ImageUrl}");
        }
    }
}
