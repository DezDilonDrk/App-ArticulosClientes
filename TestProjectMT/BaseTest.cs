using SesionMT;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProjectMT
{
    public class BaseTest
    {
        protected UserSession mySession;
        public async Task Init(string currentServer)
        {
            this.mySession = new UserSession(currentServer);
            mySession.Init("leandro.santilario@mthelmets.com", "Leandro321");
        }
    }
}
