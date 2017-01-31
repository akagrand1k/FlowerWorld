using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.AuthService
{
    public interface IUserService
    {
        IEnumerable<User> FullUserList { get; }
        User GetUserById(int id);
        UserDto Authentication(UserDto user);
        void Registration(UserDto user);
        Guid GetHashString(string password);
        void DeleteUser(int id);
        void EditUser(UserDto user);
    }
}