using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConsoleApp1
{
    internal class Program
    {
        //static void Main1(string[] args)
        //{
        //    string cS = ConfigurationManager.ConnectionStrings["adodb"].ConnectionString;

        //    SqlConnection sq = new SqlConnection(cS);
        //       sq.Open();
        //    string querry = "Select * from Student";
        //    SqlCommand cmd=new SqlCommand(querry, sq);
        //    SqlDataReader cq=cmd.ExecuteReader();
        //    while (cq.Read())
        //    {
        //        Console.WriteLine(cq["StudentName"]);
        //    }
        //    sq.Close();


        //}
        static void Main2(String[] args)
        {
            string str=ConfigurationManager.ConnectionStrings["adodb"].ConnectionString;
            // SqlConnection sq = new SqlConnection(str)
            SqlConnection sq = null;
            using (sq = new SqlConnection(str))
            sq.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Student";
            cmd.Connection = sq;
           SqlDataReader cq= cmd.ExecuteReader();
            while (cq.Read())
            {
                Console.WriteLine(cq["StudentName"]);
            }
            sq.Close();




        }
        static void Main3(String[] args) {
            string str= ConfigurationManager.ConnectionStrings["adodb"].ConnectionString;
            SqlConnection sq = null;
            try
            {
                using (sq = new SqlConnection(str))
                    sq.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * from Student";
                cmd.Connection = sq;
                SqlDataReader cq=cmd.ExecuteReader();
                while (cq.Read())
                {
                    Console.WriteLine(cq["StudentName"]);
                }
                    } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
     
        }
        public static void Main(String[] args)
        {
            string str= ConfigurationManager.ConnectionStrings["adodb"].ConnectionString;
            int id = int.Parse(Console.ReadLine());
            string name= Console.ReadLine();
            SqlConnection sq = null;
            using ( sq=new SqlConnection(str))
                sq.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText="insert into Student values(@StudentId,@StudentName";
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@StudentName", name);
            cmd.Connection= sq;
            int i=cmd.ExecuteNonQuery();
            if(i==1)
            {
                Console.WriteLine("Data Added Sucesssfully");
                sq.Close();
            }
            else
            {
                Console.WriteLine("Data Failled");
                sq.Close() ;
            }

             
        }
    }

    
}
