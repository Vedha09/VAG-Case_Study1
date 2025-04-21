using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Data
{
    internal interface IGallerydao
    {
        int AddGallery(Gallery gallery);
        int UpdateGalleryDescription(int id, string new_desc);
        int DeleteGallery(int id);
        Gallery GetGalleryByName(string name);
        Gallery GetGalleryByLocation(string loc);
        Gallery GetGalleryById(int id);
        List<Gallery> GetAllGalleries();
        IEnumerable<Artist_Curator> GetCuratorByGalleryId(int gId);
    }
}
