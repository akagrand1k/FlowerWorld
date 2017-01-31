using FlowerWorld.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.AuthService
{
    public class UserDto : User
    {
        
        private UserDto MapUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Password = user.Password
            };
        }
    }
}
