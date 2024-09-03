using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebapp.Data;
using MVCWebapp.Models;
using MVCWebapp.ViewModel;

namespace MVCWebapp.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MVCWebappContext _context;

        public UsersController(MVCWebappContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAggregatedInfo>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            var userSkills = await _context.Skill.Where(skill => skill.UserId == id).ToListAsync();

            if (user == null)
            {
                return NotFound();
            }

            var UserAggregateInfo = new UserAggregatedInfo
            {
                User = user,
                UserSkills = userSkills
            };

            return UserAggregateInfo;
        }
    }
}
