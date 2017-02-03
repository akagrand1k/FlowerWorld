using FlowerWorld.DAL.Models;
using FlowerWorld.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlowerWorld.BL.Service.AuthService
{
    public class UserService : IUserService
    {
        IRepository<User> userRepository;

        public UserService(IRepository<User> userRepo)
        {
            userRepository = userRepo;
        }

        public UserDto Authentication(UserDto model)
        {
            var password = GetHashString(model.Password).ToString();
            var user = userRepository.Get.Where(x => x.UserName.Equals(model.UserName)
                && x.Password.Equals((password))).FirstOrDefault();
            
            return MapUserDto(user);

        }

        public Guid GetHashString(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);

            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return new Guid(hash);
        }

        public void Registration(UserDto model)
        {
            User user = new User();
            if (model != null)
            {
                user.UserName = model.UserName;
                user.Password = GetHashString(model.Password).ToString();
                user.DateCreate = DateTime.Now;
                user.DateUpdate = DateTime.Now;

                userRepository.Add(user);
            }
        }
    
        public IEnumerable<User> FullUserList
        {
            get
            {
                return userRepository.Get;
            }
        }
        
        public void DeleteUser(int id)
        {
            if (id != 0)
            {
                userRepository.Delete(id);
            }
        }

        public void EditUser(UserDto dto)
        {
            User entity = userRepository.GetById(dto.Id);

            entity.UserName = dto.UserName;
            entity.DateUpdate = DateTime.Now;

            userRepository.Update(entity);
        }

        public User GetUserById(int id)
        {
            
            return userRepository.GetById(id);
        }
        private UserDto MapUserDto(User user)
        {
            if (user != null)
            {
                return new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password
                };
            }
            else
                return null;
        }
    }
}

