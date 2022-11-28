using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Application.Query.UserGender;
using UserControlPanel.Domain.Interfaces.Repository;
using Xunit;

namespace UserControlPanel.Tests.UserAddress
{
    public class UserAddressTests
    {
        [Fact]
        public async Task UserAddress_GetByCep()
        {

            var mapper = new Mock<IMapper>();
            var repository = new Mock<IUserGenderRepository>();

            var handler = new Mock<UserAdressQueryHandle>(repository.Object, mapper.Object);

            UserAdressQueryRequest query = new UserAdressQueryRequest("123445565");

            var response = await handler.Object.Handle(query, default(CancellationToken));

            Assert.IsType<UserAdressQueryResponse>(response);
        }
    }
}
