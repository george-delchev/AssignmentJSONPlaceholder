using AutoMapper;
using JSONPlaceholder.Svc.Models.Posts;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPFTestProject.DataAccess.Models.Posts;
using WPFTestProject.DataAccess.Repository.Posts;

namespace JSONPlaceholder.Svc.Managers.Posts
{
    public class CPostsManager : IPostsManager
    {
        private readonly IPostsDataAccessRepository dataAccessManager;
        private readonly IMapper _mapper;

        public CPostsManager(IPostsDataAccessRepository dataAccess, IMapper mapper)
        {
            this.dataAccessManager = dataAccess;
            _mapper = mapper;
        }

        public async Task<List<Post>> GetPosts()
        {
            var dbModel = await dataAccessManager.GetPosts();

            var model = _mapper.Map<List<PostDA>, List<Post>>(dbModel);

            return model;
        }
    }
}
