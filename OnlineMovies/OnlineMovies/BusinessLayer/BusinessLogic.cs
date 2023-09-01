using OnlineMovies.DataLayer;
using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineMovies.DataLayer;

namespace OnlineMovies.BusinessLayer
{
    public class BusinessLogic
    {
        private readonly UserDataAccess userDataAccess;

        public BusinessLogic()
        {
            userDataAccess = new UserDataAccess();
        }

        public User SignIn(string username, string password)
        {
            // You can add validation logic here, e.g., check if username and password are valid.
            // For simplicity, we'll directly call the DAL to retrieve the user.
            return userDataAccess.GetUserByUsernameAndPassword(username, password);
        }
    }
}