using System.Data.SqlClient;
using System.Net;
using static VirtualArtGalleryTests.DBUtilityTests;
using static VirtualArtGalleryTests.VirtualArtGalleryImpl;

namespace VirtualArtGalleryTests
{
    internal interface IVirtualArtGallery
    {
        bool AddArtwork(ArtworkManagement artwork);
        void GetArtworkById(int artworkId);
        bool GetArtworkById(ArtworkManagement artwork);
        bool RemoveArtwork(int artworkId);
        List<ArtworkManagement> SearchArtworks(string keyword);
        bool UpdateArtwork(ArtworkManagement artwork);
    }
}
