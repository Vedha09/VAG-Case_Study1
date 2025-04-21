using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Data
{
    internal interface IArtistdao
    {
        int AddArtist(Artist artist);
        int UpdateArtistNation(int id, string new_nation);
        int DeleteArtist(int id);
        Artist GetArtistByName(string name);
        Artist GetArtistById(int id);
        List<Artist> GetAllArtists();
    }
}
