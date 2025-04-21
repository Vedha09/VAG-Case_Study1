using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Virtual_Art_Gallery.Data.VAGArtworkdaoImpl;

namespace Virtual_Art_Gallery.Models
{
    public class ArtworkException : Exception
    {
        public ArtworkException(string message) : base(message) { }
    }
}
