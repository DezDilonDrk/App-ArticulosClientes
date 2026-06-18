using System;
using System.Collections.Generic;
using System.Text;

namespace SesionMT.Client
{
    public class BaseApiClient
    {
        protected TokenHelper tokenHelper;
        protected UserSession mySession;
        protected EnsureFunctions ensureFunctions;
        
        public BaseApiClient(UserSession session){
            mySession = session;
        }
    }
}
