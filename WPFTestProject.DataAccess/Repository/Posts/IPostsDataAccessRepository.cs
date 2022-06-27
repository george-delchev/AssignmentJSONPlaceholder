using System.Collections.Generic;
using System.Threading.Tasks;
using WPFTestProject.DataAccess.Models.Posts;

namespace WPFTestProject.DataAccess.Repository.Posts
{
    public interface IPostsDataAccessRepository
    {
        Task<List<PostDA>> GetPosts();
    }
}
