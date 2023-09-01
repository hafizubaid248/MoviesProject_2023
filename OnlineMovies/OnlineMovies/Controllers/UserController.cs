using OnlineMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineMovies.BusinessLayer;


namespace OnlineMovies.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly BusinessLogic userLogic;

        public UserController()
        {
            userLogic = new BusinessLogic();
        }

        [HttpPost]
        [Route("user/signin")]
        public IHttpActionResult SignIn([FromBody] SignInRequest request)
        {
           
            User user = userLogic.SignIn(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized(); 
            }

            
            return Ok(user);
        }
    }
}
