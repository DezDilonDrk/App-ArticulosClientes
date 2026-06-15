using SesionMT;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectMT
{
    public class BaseTest
    {
        public TokenHelper tokenHelper = new TokenHelper();
        protected UserSession mySession;
        private string token;
        public async Task Init(string currentServer)
        {
            this.mySession = new UserSession(currentServer);
            mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
            this.token = await mySession.GenerateToken();
            mySession.GetClient().DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
        public async Task checkTokenTest()
        {
            if (token != null) { 
                tokenHelper.setToken(token); 
            }
            if (this.token == null) { 
                this.token = await mySession.GenerateToken();
                mySession.GetClient().DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            if (tokenHelper.tokenExpired()) {
                this.token = await mySession.GenerateToken();
                mySession.GetClient().DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
