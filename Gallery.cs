using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery
{
    internal class Gallery
    {
        public int galleryId;
        public string galleryName;
        public string description;
        public string location;
        public IEnumerable<Artist_Curator> curator;
        public string opening_hours;

        public int GalleryID
        {
            set
            {
                galleryId = value;
            }
            get
            {
                return galleryId;
            }
        }
        public string GalleryName
        {
            set
            {
                galleryName = value;
            }
            get
            {
                return galleryName;
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
        public string Location
        {
            set
            {
                location = value;
            }
            get
            {
                return location;
            }
        }
        public IEnumerable<Artist_Curator> Curator
        {
            set
            {
                curator = value;
            }
            get
            {
                return curator;
            }
        }
        public string OpeningHours
        {
            set
            {
                opening_hours = value;
            }
            get
            {
                return opening_hours;
            }
        }
        public Gallery(int galleryId, string galleryName, string description, string location, string opening_hours, IEnumerable<Artist_Curator> curator)
        {
            GalleryID = galleryId;
            GalleryName = galleryName;
            Description = description;
            Location = location;
            Curator = curator;
            OpeningHours = opening_hours;
        }

        public Gallery()
        {
        }

        public void DisplayGallery()
        {
            Console.WriteLine($"Gallery ID: {GalleryID}, Gallery Name: {GalleryName}, Description for Gallery: {Description}, ArtGallery's Location: {Location}, {OpeningHours}, InCharge of ArtGallery(Curator): ");

            foreach (var c in Curator)
            {
                Console.WriteLine($" --- Artist's ID - {c.ArtistID}: Artist's Name - {c.ArtistName}");
            }
        }
    }
}
