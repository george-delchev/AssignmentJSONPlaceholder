using AutoMapper;
using Moq;
using System.Collections.Generic;
using WPFTestProject.DataAccess.Models.Posts;
using WPFTestProject.DataAccess.Repository.Posts;
using WPFTestProject.Svc.Managers.Posts;
using WPFTestProject.Svc.Models.Posts;
using Xunit;

namespace WPFTestProject.Tests
{
    public class PostsManagerTests
    {
        [Fact]
        public async void GetPosts_CallsGetPostsRepository()
        {
            var mockRepo = new Mock<IPostsDataAccessRepository>();
            mockRepo.Setup(x => x.GetPosts()).ReturnsAsync(new List<PostDA>());

            var mockMapper = new Mock<IMapper>();

            CPostsManager mgr = new CPostsManager(mockRepo.Object, mockMapper.Object);
            await mgr.GetPosts();

            mockRepo.Verify(x => x.GetPosts(),Times.Once);
        }
        [Fact]
        public async void GetPosts_CallsMapper()
        {
            var modelDA = new List<PostDA>();
            var model = new List<Post>();

            var mockRepo = new Mock<IPostsDataAccessRepository>();
            mockRepo.Setup(x => x.GetPosts()).ReturnsAsync(modelDA);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<PostDA>, List<Post>>(modelDA)).Returns(model);

            CPostsManager mgr = new CPostsManager(mockRepo.Object, mockMapper.Object);

            await mgr.GetPosts();

            mockMapper.Verify(x => x.Map<List<PostDA>, List<Post>>(modelDA), Times.Once);
        }
        [Fact]
        public async void GetPosts_ReturnsPosts()
        {
            var modelDA = new List<PostDA>();
            var model = new List<Post>();

            var mockRepo = new Mock<IPostsDataAccessRepository>();
            mockRepo.Setup(x => x.GetPosts()).ReturnsAsync(modelDA);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<PostDA>, List<Post>>(modelDA)).Returns(model);

            CPostsManager mgr = new CPostsManager(mockRepo.Object, mockMapper.Object);

            var returned = await mgr.GetPosts();

            Assert.Equal(model, returned);
        }
    }
}
