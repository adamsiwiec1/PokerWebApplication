using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PopulaeControls()
        {

            string PlayerID;

            if (Request.Cookies["NWTDbFinalProjFall2020_CartID"] != null)
            {
                //if they have a cookie (cartid) already, then we select it
                cartID = Request.Cookies["NWTDbFinalProjFall2020_CartID"].Value;

            }
            else
            {
                //if not, then we create a cookie for them
                cartID = Guid.NewGuid().ToString();

                HttpCookie cookie = new HttpCookie("NWTDbFinalProjFall2020_CartID", cartID);

                TimeSpan timespan = new TimeSpan(10, 0, 0, 0);

                DateTime expirationDate = DateTime.Now.Add(timespan);

                cookie.Expires = expirationDate;

                Response.Cookies.Add(cookie);
            }
        }

}