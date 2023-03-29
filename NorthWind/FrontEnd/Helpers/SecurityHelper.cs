using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class SecurityHelper
    {
        private ServiceRepository _ServiceRepository;
        public SecurityHelper()
        {
            _ServiceRepository = new ServiceRepository();

        }
        public TokenModel Login(UserViewModel user)
        {
            try
            {
                TokenModel TokenModel;

                HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Authenticate/login", user);
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                TokenModel = JsonConvert.DeserializeObject<TokenModel>(content);

                return TokenModel;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
