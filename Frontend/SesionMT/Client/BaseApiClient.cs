using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SesionMT.Client
{
    public class BaseApiClient
    {
        protected TokenHelper tokenHelper;
        protected UserSession mySession;
        protected EnsureFunctions ensureFunctions;
        protected JsonSerializerOptions optionsNotCaseSensitive = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public BaseApiClient(UserSession session){
            mySession = session;
        }
    }
}
