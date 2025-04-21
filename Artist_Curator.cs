using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery
{
    internal class Artist_Curator
    {
        public int ArtistID { get; set; }
        public string ArtistName {  get; set; }

        public Artist_Curator(int artistId, string artist_name)
        {
            ArtistID = artistId;
            ArtistName = artist_name;
        }
    }
}
