using AutoMapper;
using JSONPlaceholder.Svc.Models.Posts;
using WPFTestProject.DataAccess.Models.Posts;

namespace JSONPlaceholder.Svc.Mappings.Posts
{
    public class PostsMappings : Profile
    {
        public PostsMappings()
        {
            CreateMap<PostDA, Post>();
        }
    }
}
