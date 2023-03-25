using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using loginwebapi2.Models;

namespace loginwebapi2.Models
{
    public class BAL
    {
        DAL dal = new DAL();



        public string loginn(string Username, string Password)
        {

            return dal.loginn(Username, Password);

        }

        public Singup GetUSer(int UserID)
        {
            return dal.GetUSer(UserID);
        }

            public DataTable RetriveData(int id)
        {
            DataTable dt = new DataTable();


            return dt;
        }
        internal string login(Login login)
        {
            throw new NotImplementedException();
        }

        public string getlogin(Login login)
        {
            string response = dal.GetLogin(login);
            return response;
        }


        public string getsignup(Singup singup)
        {
            DAL dal = new DAL();
            string response = dal.Getsingup(singup);
            return response;
                 
        }

        public String update(Singup singup)
        {
            DAL dal = new DAL();
            string response = dal.update(singup);
            return response;

        }

        public string Delete(int Id)
        {
            DAL dal = new DAL();
            string response = dal.Delete(Id);
            return response;

        }

    }


}