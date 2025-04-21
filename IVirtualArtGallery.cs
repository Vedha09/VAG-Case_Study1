using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;

namespace Virtual_Art_Gallery.Data
{
    internal interface IVirtualArtGallery
    {
        bool AddArtwork(Artwork1 artwork);
        bool UpdateArtwork(Artwork1 artwork);
        bool RemoveArtwork(int artworkId);
        Artwork1 GetArtworkById(int artworkId);
        List<Artwork1> SearchArtworks(string keyword);

        bool AddArtworkToFavorite(int userId, int artworkId);
        bool RemoveArtworkFromFavorite(int userId, int artworkId);
        List<Artwork1> GetUserFavoriteArtworks(int userId);
    }
}
