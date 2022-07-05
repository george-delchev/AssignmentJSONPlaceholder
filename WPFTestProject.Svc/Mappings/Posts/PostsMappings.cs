using AutoMapper;
using WPFTestProject.Svc.Models.Posts;
using WPFTestProject.DataAccess.Models.Posts;

namespace WPFTestProject.Svc.Mappings.Posts
{
    public class PostsMappings : Profile
    {
        public PostsMappings()
        {
            CreateMap<PostDA, Post>();
        }
    }
}
