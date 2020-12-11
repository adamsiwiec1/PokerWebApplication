using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PokerWebApp.AdminFolder
{
    public partial class CreateGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_CreateGame_Click(object sender, EventArgs e)
        {
            string gameName = gameNameTxtBox.Text;
            DateTime gameCreateTime;
            gameCreateTime = DateTime.Now;


            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //pass this object to the Sqlconnection class that is embeded
            SqlConnection conn = new SqlConnection(connString);

            //command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spCreateGame";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //add parameters
            SqlParameter param = new SqlParameter("@gname", gameName);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);


            param = new SqlParameter("@gdate", gameCreateTime);
            param.DbType = System.Data.DbType.DateTime;
            cmd.Parameters.Add(param);


            cmd.Connection.Open();

            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                statusLabel.Text = "The game was sucessfully added.";

                statusLabel.Visible = true;
            }
            else
            {
                statusLabel.Text = "The game was NOT sucessfully added. Try Again.";
            }

            cmd.Connection.Close();
        }
    }
}