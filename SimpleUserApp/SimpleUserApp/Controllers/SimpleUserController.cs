using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleUserApp.DataAccess.Interface;
using SimpleUserApp.Models;
using SimpleUserApp.Models.DTO;

namespace SimpleUserApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleUserController : ControllerBase
    {
        private readonly ISimpleUser _repository;
        public SimpleUserController(ISimpleUser repository)
        {
            _repository = repository;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<SimpleUser>>> GetAllUsers()
        {
            try
            {
                var response = await _repository.GetAllUsers();
                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SimpleUser>> GetUserbyID(int id)
        {
            try
            {
               

                var response = await _repository.GetUserByID(id);
                if(response == null)
                {
                    return NotFound();
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<SimpleUser>> CreateUser([FromBody] CreateSimpleUserDTO new_user)
        {
            try
            {
                var newUser = new SimpleUser()
                {    
                    Name = new_user.Name,
                    Email = new_user.Email,
                    Stack = new_user.Stack,

                };
                var AddNewUser = await _repository.CreateUser(new_user);
                return Ok(AddNewUser);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SimpleUser>> UpdateUser(int id,[FromBody]SimpleUser userToUpdate)
        {
            if(id != userToUpdate.Id)
            {
                return BadRequest();
            }
            try
            {
            await _repository.UpdaterUSer(userToUpdate);
                
                return Ok(userToUpdate);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SimpleUser>> DeleteUser(int id)
        {
            try
            {
               await  _repository.DeleteUser(id);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
