using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.GameFolder
{
    public partial class GameLobby : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void PopulateControls()
        {
            //HttpContext context = HttpContext.Current;
            //string playerGameID;

            //playerGameID = context.Request.Cookies["SmootWebsite_PlayerGameID"].Value;

            //string currentUserCookieFromDB = GameAccess.GetCurrentCookie(User.Identity.GetUserId());



       

        }

    }
}