using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }
    }
}
