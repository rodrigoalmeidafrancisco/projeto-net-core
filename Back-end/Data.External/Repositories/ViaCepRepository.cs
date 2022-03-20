using Data.External.Base;
using HttpCore;

namespace Data.External.Repositories
{
    public class ViaCepRepository : BaseHttp
    {
        private readonly BaseHttpFactory _client;
        private readonly string _systemName = "ViaCEP";

        public ViaCepRepository(IHttpClientFactory factory)
        {
            _client = new BaseHttpFactory(factory, "HttpFactoryViaCEP");
        }




    }
}
