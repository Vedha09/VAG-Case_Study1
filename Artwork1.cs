using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    internal class Artwork1
    {
        private int artworkId;
        private string title;
        private string artist;
        private string description;
        private DateTime createdDate;

        public int ArtworkId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public Artwork1() { }

        public Artwork1(int artworkId, string title, string artist, string description, DateTime createdDate)
        {
            this.artworkId = artworkId;
            this.title = title;
            this.artist = artist;
            this.description = description;
            this.createdDate = createdDate;
        }

        public void DisplayArtWork1()
        {
            Console.WriteLine($"ArtWork ID: {ArtworkId}, ArtWork Title: {Title}, ArtWork Description: {Description}, ArtWork Artist: {Artist}, It's Creation Date: {CreatedDate}");
        }
    }
}
