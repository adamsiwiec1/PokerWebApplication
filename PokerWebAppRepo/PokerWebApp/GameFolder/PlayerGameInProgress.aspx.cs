using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.GameFolder
{
    public partial class PlayerGameInProgress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {


            Player player1 = GameAccess.GetPlayerDetailsByID(User.Identity.GetUserId());




            //populate board blank cards
            img_b1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_b5.ImageUrl = "~/Images/FACE DOWN.jpg";

            //populate players blank cards
            img_C1P1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P1.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P2.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P3.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P4.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P5.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P5.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C1P6.ImageUrl = "~/Images/FACE DOWN.jpg";
            img_C2P6.ImageUrl = "~/Images/FACE DOWN.jpg";


        }

        protected void btn_Test_Click(object sender, EventArgs e)
        {
            //player1.InHand1 = 


        }
    }
}