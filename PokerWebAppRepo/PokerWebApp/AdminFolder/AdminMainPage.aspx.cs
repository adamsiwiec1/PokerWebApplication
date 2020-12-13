using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.AdminFolder
{
    public partial class AdminMainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_AddPlayer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminFolder/AddPlayer.aspx");
        }

        protected void btn_RemovePlayer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminFolder/RemovePlayer.aspx");
        }

        protected void btn_CreateGame_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminFolder/CreatePlayer.aspx");
        }
    }
}