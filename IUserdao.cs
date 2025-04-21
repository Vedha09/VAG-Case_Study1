using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Data
{
    internal interface IUserdao
    {
        int AddUser(User user);
        int UpdateUserProfilePicture(int id, string new_dp);
        int DeleteUser(int id);
        User GetUserByFirstName(string name);
        User GetUserByLastName(string name);
        User GetUserById(int id);
        List<User> GetAllUsers();
        IEnumerable<Art_Work> GetFavoriteArtworksByUserId(int uId);
    }
}
