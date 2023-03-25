using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using loginwebapi2.Models;

namespace loginwebapi2.Controllers
{
    public class ValuesController : ApiController
    {
        //login

        //http://localhost:58814/api/values/Getlogin
        [Route("api/values/GetLogin")]
        [HttpPost]
        [BasicAuthentication]
        public string Getlogin(string Username, string Password)
        {
            BAL bal = new BAL();
            string response = bal.loginn(Username, Password);
            return response;
        }
      


        [HttpGet]
        public Singup GetUser(int UserId)
        {
            BAL bal = new BAL();

            Singup response = bal.GetUSer(UserId);
            return response;


        }


        //http://localhost:58814/api/values/getsingup
        [Route("api/values/Getsingup")]
        [HttpPost]
        public string getsingup(Singup singup)
        {
            BAL bal = new BAL();
            string response = bal.getsignup(singup);
            return response;
        }

        [Route("api/values/update")]
        [HttpPut]
        public string update(Singup singup)
        {
            BAL bal = new BAL();
            string response = bal.update(singup);
            return response;
        }

        [Route("api/values/Delete")]
        [HttpDelete]
        public string Delete(int Id)
        {
            BAL bal = new BAL();
            string response = bal.Delete(Id);
            return response;
        }
    }

}

