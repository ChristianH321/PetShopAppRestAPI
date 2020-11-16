using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PetShop.Core.ApplicationService;
using TodoApiAuthentication;
using PetShop.Core.Entities;
using PetShop.Core.DomainService;

namespace Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private IRepository<User> repository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IRepository<User> repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }

    }
}