using Domain.Models;
using MinimalApi.Mediator.Commands;
using MinimalApi.Mediator.Handlers;
using Moq;

namespace Test.UnitTests
{
    public class PostCommandHandlerUnitTests
    {
        private readonly Mock<IRepository<Post>> _postRepository;
        public PostCommandHandlerUnitTests()
        {
            _postRepository = new();
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenPostModelValid()
        {
            //Arrange
            var post = new Post() { Content = "Unit Test 101" };

            var createPostCommand = new CreatePost()
            { Post = post };

            _postRepository.Setup(
                s => s.CreateAsync(It.IsAny<Post>()))
                .ReturnsAsync(post);

            var _handler = new CreatePostHandler(_postRepository.Object);

            //Act
            var result = await _handler.Handle(createPostCommand, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenPutModelValid()
        {
            //Arrange
            var post = new Post() { Content = "Unit Test 101" };

            var createPostCommand = new UpdatePost()
            { Id = 1, Content = "Updated Content" };

            _postRepository.Setup(
                s => s.UpdateAsync(It.IsAny<Post>()))
                .ReturnsAsync(post);

            var _handler = new UpdatePostHandler(_postRepository.Object);

            //Act
            var result = await _handler.Handle(createPostCommand, default);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenDeleteModelValid()
        {
            //Arrange
            var deletePostCommand = new DeletePost()
            { Id = 1 };

            _postRepository.Setup(
                s => s.DeleteAsync(It.IsAny<int>()));


            var _handler = new DeletePostHandler(_postRepository.Object);

            //Act
            await _handler.Handle(deletePostCommand, default);

            //Assert
            _postRepository.Verify(v => v.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}