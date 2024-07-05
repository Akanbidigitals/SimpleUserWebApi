using Microsoft.EntityFrameworkCore;
using SimpleUserApp.DataAccess.DataContext;
using SimpleUserApp.DataAccess.Interface;
using SimpleUserApp.Models;
using SimpleUserApp.Models.DTO;

namespace SimpleUserApp.DataAccess.Repository
{
    public class SimpleUserRepository : ISimpleUser
    {
        private readonly SimpleUserContext _database;
        public SimpleUserRepository(SimpleUserContext database)
        {
            _database = database;
        }
        public async Task<SimpleUser> CreateUser(CreateSimpleUserDTO new_user)
        {
            try
            {
                var checkDb = await _database.Users.AnyAsync(x => x.Name == new_user.Name);
                if(checkDb)
                {
                    throw new Exception("User already exist");
                }
                var createNewUser = new SimpleUser()
                {
                    Name = new_user.Name,
                    Email = new_user.Email,
                    Stack = new_user.Stack,
                };
                await _database.Users.AddAsync(createNewUser);
                await _database.SaveChangesAsync();
                return createNewUser;

            }catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public async Task<string> DeleteUser(int user_id)
        {
            var checkId = await CheckIdIdItExist(user_id);
            if (checkId == null)
            {
                throw new Exception("Id does not exist");
            }
            _database.Users.Remove(checkId);
            await _database.SaveChangesAsync();
            return "Item Deleted Succesfully";
        }

        public async Task<IEnumerable<SimpleUser>> GetAllUsers()
        {
            try
            {
                var allUsersCredentials = await _database.Users.ToListAsync();
                return allUsersCredentials;
            }
           
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
        }

        public async Task<SimpleUser> GetUserByID(int user_id)
        {
            try
            {
                var getIdCretedtials = await CheckIdIdItExist(user_id);
                if (getIdCretedtials == null)
                {
                    throw new Exception("User does not exist");
                }
                return getIdCretedtials;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }

        public async Task<SimpleUser> UpdaterUSer(SimpleUser new_to_update)
        {
            try
            {
                var checkifIdexist = await _database.Users.FindAsync(new_to_update.Id);
                if(checkifIdexist == null)
                {
                    throw new Exception("User Id does not exist");
                }
                
                checkifIdexist.Name = new_to_update.Name ?? checkifIdexist.Name;
                checkifIdexist.Email = new_to_update.Email ?? checkifIdexist.Email;
                checkifIdexist.Stack = new_to_update.Stack ?? checkifIdexist.Stack;
                 _database.Users.Update(checkifIdexist);
                await _database.SaveChangesAsync();
                return checkifIdexist;

            }catch( Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //// Validator method
        private async Task<SimpleUser> CheckIdIdItExist(int id)
        {
            try
            {
               var credentials = await _database.Users.FirstOrDefaultAsync(x => x.Id == id);
                if(credentials != null)
                {
                    return credentials;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
