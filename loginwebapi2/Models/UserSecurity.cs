using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace loginwebapi2.Models
{
    public class UserSecurity
    {
        //  public string Login(Login login)
        //        {
        //            string msg = " ";
        //            if (login != null)
        //            {
        //                SqlConnection Con = new SqlConnection(strcon);
        //                SqlCommand cmd = new SqlCommand("loginuser", Con);
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Username", login.Username);
        //                cmd.Parameters.AddWithValue("@Password", login.Password);

        //                Con.Open();
        //                int i = cmd.ExecuteNonQuery();
        //                Con.Close();

        //                if (i > 0)
        //                {
        //                    msg = "You logged In successfully ";
        //                }
        //                else
        //                {
        //                    msg = "Error";
        //                }
        //            }
        //            return msg;
        //     }

    }
}