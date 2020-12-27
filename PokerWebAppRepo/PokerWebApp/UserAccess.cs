using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class UserAccess
    {
        public static List<Player> GetAllPlayerInfo()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetAllPlayerInfo";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            DataTable table = new DataTable();

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            cmd.Connection.Close();
       
            List<Player> allPlayers = new List<Player>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow dr = table.Rows[i];
                Player player = new Player();
                string id = dr["Id"].ToString();
                string pdetailid = dr["PlayerDetailID"].ToString();
                string gameid = dr["GameID"].ToString();
                string cookie = dr["cookie"].ToString();
                string name = dr["Name"].ToString();
                string venmo = dr["Venmo"].ToString();
                string balance = dr["balance"].ToString();
                string face = dr["C1_Value"].ToString();
                string suit = dr["C1_Suit"].ToString();
                string face2 = dr["C2_Value"].ToString();
                string suit2 = dr["C2_Suit"].ToString();

                player.Id = id;
                player.PlayerDetailID = int.Parse(pdetailid);
                player.GameID = int.Parse(gameid);
                player.PlayerCookie = cookie;
                player.Name = name;
                player.Venmo = venmo;
                player.Balance = decimal.Parse(balance);
                //maybe?
                player.PlayerList.Add(player);

                if (face != null && suit != null && face2 != null && suit2 != null)
                {
                    player.InHand1 = Card.MkStr(face, suit);
                    player.InHand2 = Card.MkStr(face2, suit2);
                }
                allPlayers.Add(player);
            }

            return allPlayers;
        }

    }
}