using SmartSchool.BL.Models;
using System.Threading.Tasks;
//using JWT.Models;

namespace SmartSchool.BL.Services
{
    public interface IAuthService
    {
        //add endpoints such as register or login , .....
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> LoginAsync(LoginModel model);
        Task<string> AddRoleAsync(AddRoleModel model);

    }
}
