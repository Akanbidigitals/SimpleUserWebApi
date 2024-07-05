using SimpleUserApp.Models;
using SimpleUserApp.Models.DTO;

namespace SimpleUserApp.DataAccess.Interface
{
    public interface ISimpleUser
    {
        Task<SimpleUser> CreateUser(CreateSimpleUserDTO new_user);

        Task <SimpleUser> GetUserByID(int user_id);

        Task<IEnumerable<SimpleUser>> GetAllUsers();

        Task<SimpleUser> UpdaterUSer(SimpleUser new_user);

        Task<string> DeleteUser(int  user_id);
    }
}
