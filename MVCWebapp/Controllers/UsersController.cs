using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebapp.Repositories.GenericRepositories;
using MVCWebapp.DTOs.UserDTOs;
using MVCWebapp.Models;
using AutoMapper;

namespace MVCWebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepositories _genericRepositories;

        public UsersController(IMapper mapper, IGenericRepositories genericRepositories)
        {
            _mapper = mapper;
            _genericRepositories = genericRepositories;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserReadDTO>>> GetUser()
        {
            var users = await _genericRepositories.SelectAll<User>();
            var userDTO = _mapper.Map<List<UserReadDTO>>(users);
            return Ok(userDTO);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            var user = await _genericRepositories.SelectbyId<User>(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserReadDTO>(user);

            return Ok(userDTO);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDTO userUpdateDTO)
        {
            
            if(id != userUpdateDTO.UserId)
            {
                return BadRequest();
            }
            var user=_mapper.Map<User>(userUpdateDTO);

            await _genericRepositories.UpdatebyId(id, user);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> PostUser(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);
            user.IsDeleted = false;
            await _genericRepositories.Create(user);
            var userRead = _mapper.Map<UserReadDTO>(user);
            return CreatedAtAction("GetUser", new { id = userRead.UserId }, userRead);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _genericRepositories.SelectbyId<User>(id);
            if (user == null)
            {
                return NotFound();
            }
            user.IsDeleted = true;
            await _genericRepositories.UpdatebyId(id, user);

            return NoContent();
        }
    }
}
