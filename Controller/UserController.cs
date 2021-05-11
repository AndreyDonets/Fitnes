using FitnesBL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnesBL.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            User = new User(userName, new Gender(genderName), birthDate, weight, height);
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                if (formatter.Deserialize(fs) is User user)
                    User = user;
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
                formatter.Serialize(fs, User);
        }
    }
}
