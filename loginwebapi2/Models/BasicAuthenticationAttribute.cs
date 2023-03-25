using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;


namespace loginwebapi2.Models
{

    
    public class BasicAuthenticationAttribute :AuthorizationFilterAttribute
    {

        //public override void OnAuthorization(HttpActionContext actionContext)
        //{

        //    if (actionContext.Request.Headers.Authorization == null)
        //    {
        //        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //    }
        //    else
        //    {
        //        string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
        //        string dcodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
        //        string[] arr = dcodeAuthToken.Split(':');

        //        bool isValidUsre = GetTokeDetail(authenticationToken);

        //        string userName = arr[0];
        //        string password = arr[1];

        //        if (isValidUsre)
        //        {
        //            BAL bl = new BAL();

        //            isValidUsre = bl.IsLogin(userName, password);

        //            //if (userName == "SM@spidosoft.com")
        //            if (isValidUsre)
        //            {
        //                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
        //            }
        //            else
        //            {
        //                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        //            }
        //        }
        //        else
        //        {
        //            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

        //        }



        //    }



        //}
        //private bool GetTokeDetail(string tokenValue)
        //{

        //    bool isValidToken = false;

        //    // connectoin string 
        //    string strCon = @"data source=DESKTOP-3BL9M8E;initial catalog=DemoDB;integrated security=true";

        //    // it's used to connect to sql server.. make sure to pass connecttion string variable
        //    SqlConnection con = new SqlConnection(strCon);

        //    SqlCommand cmd = new SqlCommand("GetTOkenDetail", con);

        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@Tokenval", tokenValue);

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    da.SelectCommand = cmd;

        //    DataSet ds = new DataSet("EmpTable");

        //    da.Fill(ds);

        //    DataTable dt = ds.Tables[0];

        //    string tokeyKey = dt.Rows[0]["TokenValue"].ToString();

        //    DateTime tokenDate = Convert.ToDateTime(dt.Rows[0]["GenDate"]);

        //    DateTime currentTime = DateTime.Now;

        //    int minOld = tokenDate.Minute;

        //    int minNew = DateTime.Now.Minute;

        //    if ((minNew - minOld) == 0)
        //    {
        //        // token is valid and update token time..
        //       // UpdateTokeDetail(tokenValue);
        //        isValidToken = true;
        //    }
        //    else
        //    {
        //        // delete token from database 
        //        // go to login page...
        //       // DeleteTokeDetail(tokenValue);
        //        isValidToken = false;
        //    }



        //    return isValidToken;
        //}

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            BAL bal = new BAL();
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] usernamePasswordArray = decodedAuthenticationToken.Split(':');
                string Username = usernamePasswordArray[0];
                string Password = usernamePasswordArray[1];
                if (Username != null && Password!=null)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username,Password), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }



    }
}