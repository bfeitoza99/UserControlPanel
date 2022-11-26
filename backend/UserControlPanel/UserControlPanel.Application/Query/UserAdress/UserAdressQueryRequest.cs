using MediatR;

namespace UserControlPanel.Application.Query.UserAdress
{
    public class UserAdressQueryRequest : IRequest<UserAdressQueryResponse>
    {
        public UserAdressQueryRequest(string cep)
        {
            Cep = cep;
        }
        public string Cep { get; set; }
    }
}
