using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace loginwebapi2.Models
{

    public class DAL
    {
        string strcon = ConfigurationManager.ConnectionStrings["loginapi"].ConnectionString;



        public string loginn(string Username, string Password)
        {
            string strcon = ConfigurationManager.ConnectionStrings["loginapi"].ConnectionString;
            string msg = " ";
            if (Username != null)
            {
                SqlConnection Con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("loginuser", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);

                Con.Open();
                int i = cmd.ExecuteNonQuery();
                Con.Close();

                if (i > 0)
                {

                    msg = "You logged In successfully ";
                    //GetUSer();

                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;

        }

        public Singup GetUSer(int UserID)
        {

            // connectoin string 
            string strCon = ConfigurationManager.ConnectionStrings["loginapi"].ConnectionString;

            // it's used to connect to sql server.. make sure to pass connecttion string variable
            SqlConnection con = new SqlConnection(strCon);

            SqlCommand cmd = new SqlCommand("ShowData", con);

            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@id", UserID);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = cmd;

            DataSet ds = new DataSet("EmpTable");

            da.Fill(ds);

            DataTable dt = ds.Tables[0];


            Singup model = new Singup();

            model.FirstName = dt.Rows[0]["FirstName"].ToString();
            model.LastName = dt.Rows[0]["LastName"].ToString();
            model.UserName = dt.Rows[0]["UserName"].ToString();
            model.Email = dt.Rows[0]["Email"].ToString();
            model.Gender = dt.Rows[0]["Gender"].ToString();


            return model;

        }




        public string GetLogin (Login login)
        {
            string msg = " ";
            if (login != null)
            {
                SqlConnection Con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("loginuser", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@Password", login.Password);
               
                Con.Open();
                int i = cmd.ExecuteNonQuery();
                Con.Close();

                if (i > 0)
                {
                    msg = "You logged In successfully ";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        internal string update(Singup singup)
        {
            throw new NotImplementedException();
        }

        public string Getsingup(Singup singup)
        {
            string msg = " ";
            if (singup != null)
            {
                SqlConnection Con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("sp_signup", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Id", singup.Id);
                cmd.Parameters.AddWithValue("@Active", singup.Active);
                cmd.Parameters.AddWithValue("@FirstName", singup.FirstName);
                cmd.Parameters.AddWithValue("@LastName", singup.LastName);
                cmd.Parameters.AddWithValue("@UserName", singup.UserName);
                cmd.Parameters.AddWithValue("@Password", singup.Password);
                cmd.Parameters.AddWithValue("@Email", singup.Email);
                cmd.Parameters.AddWithValue("@Gender", singup.Gender);

                Con.Open();
                int i = cmd.ExecuteNonQuery();
                Con.Close();

                if (i > 0)
                {
                    msg = "Signup Successfully ";
                }
                else
                {
                    msg = "Error";
                }
            }
            return msg;
        }

        public string update(int id, Singup singup)
        {

            string msg = " ";
            if (singup != null)
            {
                SqlConnection Con = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand("SP_update", Con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", singup.Id);
                cmd.Parameters.AddWithValue("@Active", singup.Active);
                cmd.Parameters.AddWithValue("@FirstName", singup.FirstName);
                cmd.Parameters.AddWithValue("@LastName", singup.LastName);
                cmd.Parameters.AddWithValue("@UserName", singup.UserName);
                cmd.Parameters.AddWithValue("@Password", singup.Password);
                cmd.Parameters.AddWithValue("@Email", singup.Email);
                cmd.Parameters.AddWithValue("@Gender", singup.Gender);
                Con.Open();
                int i = cmd.ExecuteNonQuery();
                Con.Close();

                if (i > 0)
                {
                    msg = "data has been Updated ";
                }
                else
                {
                    msg = "Error";
                }

            }
            return msg;


        }

        public string Delete(int id)
        {
            string msg = " ";

            SqlConnection Con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("spdeletesignup", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            Con.Open();
            int i = cmd.ExecuteNonQuery();
            Con.Close();

            if (i > 0)
            {
                msg = "data has been deleted ";
            }
            else
            {
                msg = "Error";
            }


            return msg;




        }














    }
}