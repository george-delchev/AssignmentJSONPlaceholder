using JSONPlaceholder.APIAccess.Interfaces.Models;
using System.Threading.Tasks;

namespace JSONPlaceholder.APIAccess.Interfaces
{
    public interface IJSONPlaceholderService
    {
        Task<Posts> GetPosts();
    }
}
