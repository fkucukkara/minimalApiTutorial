using Domain.Models;
using MinimalApi.Mediator.Handlers;
using MinimalApi.Mediator.Queries;
using Moq;

namespace Test.UnitTests;
public class PostQueryHandlerUnitTests
{
    private readonly Mock<IRepository<Post>> _postRepository;
    public PostQueryHandlerUnitTests()
    {
        _postRepository = new();
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccess_WhenGetPostModelValid()
    {
        //Arrange
        var getPost = new GetPost() { Id = 1 };

        _postRepository.Setup(
            s => s.GetByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Post());

        var _handler = new GetPostHandler(_postRepository.Object);

        //Act
        var result = await _handler.Handle(getPost, default);

        //Assert
        Assert.NotNull(result);
    }
}