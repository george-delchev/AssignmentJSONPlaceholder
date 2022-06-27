using JSONPlaceholder.Svc.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSONPlaceholder.Svc.Managers.Posts
{
    public interface IPostsManager
    {
        Task<List<Post>> GetPosts();
    }
}
