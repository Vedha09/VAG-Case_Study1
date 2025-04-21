using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery
{
    internal class Art_Work
    {
        public int ArtworkID { get; set; }
        public string Title { get; set; }

        public Art_Work(int id, string title)
        {
            ArtworkID = id;
            Title = title;
        }
    }
}
