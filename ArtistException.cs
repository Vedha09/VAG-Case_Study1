﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    class ArtistException : Exception
    {
        public ArtistException(string message) : base(message) { }
    }
}
