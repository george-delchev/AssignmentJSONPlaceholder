using WPFTestProject.Svc.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPFTestProject.Svc.Managers.Posts
{
    public interface IPostsManager
    {
        Task<List<Post>> GetPosts();
    }
}
