using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PokerWebApp
{
    public class GameAccess
    {


        public static DataTable GetAllPlayers()
        {


            //connection string object that holds info about the server and the db
            //this is where we get the info about a caetegory for our user to then display it

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //pass this object to the Sqlconnection class that is embeded
            SqlConnection conn = new SqlConnection(connString);

            //command object
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetAllPlayers";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;


            DataTable table = new DataTable();

            try
            {
                //opens sql connection and reads, we need this in read/display methods only. 
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {



            }
            finally
            {
                //Im done with it now so i close the connection. We do this 'clean up' in the finally block.
                cmd.Connection.Close();

            }

            return table;

        }


        public static string GetPlayerNameByID(int playerID)
        {

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetPlayerNameByID";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@playerDetailID", playerID);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);



            cmd.Connection.Open();


            var reader = cmd.ExecuteScalar();
            string name = reader.ToString();


            cmd.Connection.Close();

            return name;
        }



        public static Player GetPlayerCardsByName(string playerName)
        {

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetPlayerCardsByName";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@pname", playerName);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);


            DataTable table = new DataTable();

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();

            cmd.Connection.Close();

            Player player = new Player();

            DataRow dr = table.Rows[0];


            string face = dr["C1_Value"].ToString();
            string suit = dr["C1_Suit"].ToString();
            string face2 = dr["C2_Value"].ToString();
            string suit2 = dr["C2_Suit"].ToString();

            player.InHand1 = Card.MkStr(face, suit);
            player.InHand2 = Card.MkStr(face2, suit2);

            return player;

        }



        public static Player UpdateThenGetPlayerCardsByName(string playerName, string newValue1, string newSuit1, string newValue2, string newSuit2)
        {

            //This is basically done, its for the button


            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spUpdateThenGetPlayerCardsByName";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@pname", playerName);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@c1_value", newValue1);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@c1_suit", newSuit1);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param); 

            param = new SqlParameter("@c2_value", newValue2);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@c2_suit", newSuit2);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);


            DataTable table = new DataTable();

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();

            cmd.Connection.Close();

            Player player = new Player();

            DataRow dr = table.Rows[0];


            string face = dr["C1_Value"].ToString();
            string suit = dr["C1_Suit"].ToString();
            string face2 = dr["C2_Value"].ToString();
            string suit2 = dr["C2_Suit"].ToString();

            player.InHand1 = Card.MkStr(face, suit);
            player.InHand2 = Card.MkStr(face2, suit2);

            return player;

        }


        public static void UpdateBoard(string boardId, string value1, string suit1, string value2, string suiit2, string value3, string suit3, string value4, string suit4, string value5, string suit5)
        {

            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spUpdateBoard";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@boardid", boardId);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C1_value", value1);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C1_suit", suit1);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C2_value", value2);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C2_suit", suiit2);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C3_value", value3);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C3_suit", suit3);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C4_value", value4);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C4_suit", suit4);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C5_value", value5);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@C5_suit", suit5);
            param.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(param);

            DataTable table = new DataTable();

            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            table.Load(reader);
            reader.Close();

            cmd.Connection.Close();

            Player player = new Player();

            DataRow dr = table.Rows[0];

            string face1 = dr["B1_Value"].ToString();
            string s1 = dr["B1_Suit"].ToString();
            string face2 = dr["B2_Value"].ToString();
            string s2 = dr["B2_Suit"].ToString();
            string face3 = dr["B3_Value"].ToString();
            string s3 = dr["B3_Suit"].ToString();
            string face4 = dr["B4_Value"].ToString();
            string s4 = dr["B4_Suit"].ToString();
            string face5 = dr["B5_Value"].ToString();
            string s5 = dr["B5_Suit"].ToString();
        }


        public static string GetCurrentCookie(string playerId)
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "spGetCurrentCookie";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter("@currentUser", playerId);
            param.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(param);

            cmd.Connection.Open();

            var reader = cmd.ExecuteScalar();
            string playerCookie = reader.ToString();

            cmd.Connection.Close();

            return playerCookie;
        }




























        //public static Player GetPlayerCardsByName(string playerName)
        //{

        //    string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        //    SqlConnection conn = new SqlConnection(connString);

        //    SqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = "spGetPlayerCardsByName";
        //    cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //    SqlParameter param = new SqlParameter("@pname", playerName);
        //    param.DbType = System.Data.DbType.String;
        //    cmd.Parameters.Add(param);


        //    DataTable table = new DataTable();

        //    cmd.Connection.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    table.Load(reader);
        //    reader.Close();

        //    cmd.Connection.Close();

        //    Player player = new Player();

        //    DataRow dr = table.Rows[0];


        //    string face = dr["C1_Value"].ToString();
        //    string suit = dr["C1_Suit"].ToString();
        //    string face2 = dr["C2_Value"].ToString();
        //    string suit2 = dr["C2_Suit"].ToString();

        //    player.InHand1 = Card.MkStr(face, suit);
        //    player.InHand2 = Card.MkStr(face2, suit2);

        //    return player;

        //}

    }
}