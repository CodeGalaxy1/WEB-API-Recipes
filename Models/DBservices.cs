using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Recipes_Web_API.Models
{
    public class DBservices
    {
        public SqlConnection connect()
        {
            //string conStr = @"Data Source=DESKTOP-QCT98SA\SQLEXPRESS;Initial Catalog=DBRecipes;Integrated Security=True";
            string conStr = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            return con;
        }

        //Get
        public List<Recipe> GetRecipe()
        {
            List<Recipe> listRecipe = new List<Recipe>();
            SqlConnection con = connect();
            SqlCommand command = new SqlCommand("SELECT * " +
                                                "From " +
                                                "TBRecipes " +
                                                "Order by Recipe_Id", con);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                Recipe r = new Recipe(int.Parse(dr["Recipe_Id"].ToString()), dr["Recipe_Name"].ToString(), dr["Recipe_Time"].ToString(), dr["Recipe_Type"].ToString(), dr["Recipe_Category"].ToString());
                listRecipe.Add(r);
            }

            con.Close();
            return listRecipe;
        }
        //Post
        public int PostRecipe(Recipe r)
        {
            SqlConnection con = connect();
            SqlCommand command = new SqlCommand("INSERT " +
                                                "INTO TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) " +
                                                $"VALUES('{r.name}', '{r.time}', '{r.type}', '{r.category}')", con);
            int res = command.ExecuteNonQuery();

            con.Close();
            return res;
        }
        //Put
        public int PutRecipe(Recipe r)
        {
            SqlConnection con = connect();
            SqlCommand command = new SqlCommand("UPDATE TBRecipes " +
                                                $"SET Recipe_Name='{r.name}', Recipe_Time='{r.time}', Recipe_Type='{r.type}', Recipe_Category='{r.category}'" +
                                                $"WHERE Recipe_Id='{r.id}'", con);
            int res = command.ExecuteNonQuery();

            con.Close();
            return res;
        }
        //Delete
        public int DeleteRecipe(int id)
        {
            SqlConnection con = connect();
            SqlCommand command = new SqlCommand("DELETE TBRecipes " +
                                                $"WHERE Recipe_Id='{id}'", con);
            int res = command.ExecuteNonQuery();

            con.Close();
            return res;
        }
    }
}