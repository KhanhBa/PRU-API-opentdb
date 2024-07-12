using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : Controller
    {
        private readonly PRUContext _PRUContext;
        public UsersController(PRUContext PRUContext) {
            _PRUContext = PRUContext;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string userName,string password)
        { 
        var result = await _PRUContext.Users.FirstOrDefaultAsync(x=>x.UserName==userName && x.Password==password);
        if (result == null)
            {
             return NotFound("Error");
            }
        else return Ok(result);
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(string userName, string password)
        {
            var user = new User { UserName = userName, Password = password ,Score=0,Status=true};
            var check = await _PRUContext.Users.FirstOrDefaultAsync(x=>x.UserName==userName);
            if (check != null) { return NotFound("UserName is exist!!!"); }
            var result = await _PRUContext.Users.AddAsync(user);
            _PRUContext.SaveChanges();
            if (result == null)
            {
                return NotFound("Error");
            }
            else return Ok(result.Entity);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _PRUContext.Users.ToListAsync();
            return Ok(result);
        }
        [HttpPatch("Update/{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateUser user, [FromRoute]int id)
        {
            var check = await _PRUContext.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if (check == null) { return NotFound("Error"); }
            else
            {
                check.UserName = user.UserName == null? check.UserName : user.UserName;
                check.Password = user.Password == null ? check.Password : user.Password;
                check.Status =  user.Status.HasValue ? user.Status.Value :check.Status ;
                check.Score = user.Score.HasValue ? user.Score.Value : check.Score;
            }
            await _PRUContext.SaveChangesAsync();
            return Ok(check);
        }
    }
}
