using API.Mediator.Commands;
using API.Mediator.Handlers;

namespace Test.UnitTests;
public class PostCommandHandlerUnitTests
{
    private readonly Mock<IRepository<Post>> _postRepository;
    public PostCommandHandlerUnitTests()
    {
        _postRepository = new();
    }

    [Fact]
    public async Task Add_AddPost_ReturnsSameProduct()
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
    public async Task Update_UpdatePostWithAutoFixture_ReturnsSameProduct()
    {
        //Arrange            
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var post = fixture.Build<Post>()
               .With(n => n.Id, 1)
               .With(n => n.Content, "Updated Content 2")
           .Create();

        var createPostCommand = fixture.Build<UpdatePost>()
                   .With(n => n.Id, 1)
                   .With(n => n.Content, "Updated Content 2")
               .Create();

        var _postRepositoryFixture = fixture.Freeze<Mock<IRepository<Post>>>();
        _postRepositoryFixture.Setup(
            s => s.UpdateAsync(It.IsAny<Post>()))
            .ReturnsAsync(post);

        var _handler = fixture.Create<UpdatePostHandler>();

        //Act
        var result = await _handler.Handle(createPostCommand, default);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Delete_DeletePost_ReturnsNothing()
    {
        //Arrange
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var deletePostCommand = fixture.Build<DeletePost>()
              .With(n => n.Id, 1)
          .Create();

        var _postRepositoryFixture = fixture.Freeze<Mock<IRepository<Post>>>();
        _postRepositoryFixture.Setup(
            s => s.DeleteAsync(It.IsAny<int>()));

        var _handler = fixture.Create<DeletePostHandler>();

        //Act
        await _handler.Handle(deletePostCommand, default);

        //Assert
        _postRepositoryFixture.Verify(v => v.DeleteAsync(It.IsAny<int>()), Times.Once);
    }
}