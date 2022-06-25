using JSONPlaceholder.APIAccess.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholder.APIAccess.Interfaces
{
    public interface IJSONPlaceholderService
    {
        Task<List<Post>> GetPosts();
    }
}
