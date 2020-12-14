using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.GameFolder
{
    public partial class JoinGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void btn_JoinGameCreatePlayerCookieAndDetails_Click(object sender, EventArgs e)
        {
            int gameID = int.Parse(allGamesDDL.SelectedValue);
            string playerName = playerNameTxtbox.Text;
            string playerVenmo = playerVenmoTxtbox.Text;
            decimal playerBalance = decimal.Parse(playerBalanceTxtbox.Text);
   

            //COOKIE
            HttpContext context = HttpContext.Current;
            string playerGameID;

            if (context.Request.Cookies["SmootWebsite_PlayerGameID"] != null)
            {
                playerGameID = context.Request.Cookies["SmootWebsite_PlayerGameID"].Value;

            }
            else
            {
                playerGameID = Guid.NewGuid().ToString();
                HttpCookie cookie = new HttpCookie("SmootWebsite_PlayerGameID", playerGameID);
                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);
                DateTime expirationDate = DateTime.Now.Add(timespan);
                cookie.Expires = expirationDate;
                context.Response.Cookies.Add(cookie);
            }
            //END OF COOKIE

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spJoinGameAddPlayerDetailsAndCookie";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@gameid", gameID);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@playerGameId", playerGameID);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@pid", User.Identity.GetUserId());
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@pname", playerName);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@venmo", playerVenmo);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@balance", playerBalance);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            cmd.Connection.Open();

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Response.Redirect("~/GameFolder/GameLobby.aspx");
            }
            else
            {
                Response.Redirect("~/ErrorView/DefaultError.aspx");
            }

            cmd.Connection.Close();

            Response.Redirect("~/GameFolder/GameLobby.aspx");
        }
    }
}