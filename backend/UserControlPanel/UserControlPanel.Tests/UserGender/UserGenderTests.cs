using AutoMapper;
using Moq;
using UserControlPanel.Application.Query.UserGender;
using UserControlPanel.Domain.Interfaces.Repository;
using Xunit;

namespace UserControlPanel.Tests.UserGender
{
    public class UserGenderTests
    {
        [Fact]
        public async Task UserGender_GetAll()
        {

            var mapper = new Mock<IMapper>();
            var repository = new Mock<IUserGenderRepository>();

            var handler = new Mock<UserGenderQueryHandle>(repository.Object, mapper.Object);

            UserGenderQueryRequest query = new UserGenderQueryRequest();

            var response = await handler.Object.Handle(query, default(CancellationToken));

            Assert.IsType<UserGenderQueryResponse>(response);
        }
    }
}
