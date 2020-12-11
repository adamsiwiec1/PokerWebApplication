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
    public partial class AddPlayer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_AddPlayer_Click(object sender, EventArgs e)
        {
            string playerId = playerByEmailDDL.SelectedValue;
            string playerName = playerNameTxtbox.Text;
            string playerVenmo = playerVenmoTxtbox.Text;
            decimal playerBalance = decimal.Parse(playerBalanceTxtbox.Text);

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //pass this object to the Sqlconnection class that is embeded
            SqlConnection conn = new SqlConnection(connString);

            //command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spAddPlayerDetails";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //add parameters
            SqlParameter param = new SqlParameter("@pid", playerId);
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
                statusLabel.Text = "The player was sucessfully added.";

                statusLabel.Visible = true;
            }
            else
            {
                statusLabel.Text = "The player was NOT sucessfully added. Try Again.";
            }

            cmd.Connection.Close();
        }
    }
    
}