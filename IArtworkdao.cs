using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Data
{
    internal interface IArtworkdao
    {
        int AddArtwork(Artwork artwork);
        int UpdateArtworkMedium(int id, string new_med);
        int DeleteArtwork(int id);
        Artwork GetArtworkByTitle(string title);
        Artwork GetArtworkById(int id);
        List<Artwork> GetAllArtworks();
    }
}
