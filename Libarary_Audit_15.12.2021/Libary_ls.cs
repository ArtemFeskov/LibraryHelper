using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.IO;

namespace Libarary_Audit_15._12._2021
{
    internal class Libary_ls
    {
        DataTable dt;
       public  List<Book> libary_Ls = new List<Book>();

        SqlConnection ConnectToDB = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LB_DataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        

        public void Add(Book book)
        {
            libary_Ls.Add(book); 
        }

        public bool Reserv_Book(Book book)
        {
            return book.IsReserved == false ? true : false;
        }

        public void Print_Available_Books()
        {
            int count = 1;
            foreach (Book book in libary_Ls)
            {
                if (book.IsArhiving == true && book.IsReserved == true)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(count + ") " + book.Title.ToString() + " - " + book.Author.ToString());
                    count++;
                }
            }
        }

        public void Print_Reserved_Books()
        {
            int count = 1;
            foreach (var book in libary_Ls)
            {
                if (book.IsReserved == true)
                {
                    Console.WriteLine(count + ") " + book.Title.ToString() + " - " + book.Author.ToString());
                    count++;
                }
                else
                    continue;
            }
        }

        public void Print_Name_Books() 
        {
            var SortedBooks = from u in libary_Ls
                              orderby u.Title
                              select u;

            foreach (var book in SortedBooks)
                Console.WriteLine(book.Title.ToString() + " - " + book.Author.ToString());
        }

        public void Print_All_Books_Exept_Archive()
        {
            int count = 1;
            foreach (var book in libary_Ls)
            {
                if (book.IsArhiving == true)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(count + ") " + book.Title.ToString() + " - " + book.Author.ToString());
                    count++;
                }

            }
        }

        public void Save_CSV_File()
        {
            string path = "C:/Users/artem/Desktop/Артем Учьоба/Artem C++/Домашка/Роботи/Libarary_Audit_15.12.2021/Libarary_Audit_15.12.2021/Saves/SaveFcsv.csv";
            dt.ToCSV(path);
        }




        public Libary_ls()
        {
            ConnectToDB.Open();         // Open DB
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnectToDB;
            cmd.CommandText = "SELECT * FROM [dbo].[Books]";

            DataTable DataTable = new DataTable();
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(DataTable);            //Fill DB
            ConnectToDB.Close();        //close connection


            libary_Ls = (from DataRow dr in DataTable.Rows      //Copy in list
                            select new Book()
                            {   
                                Title = dr["_Title"].ToString(),
                                Author=dr["_Authour"].ToString(),
                                ID = Convert.ToInt32(dr["_Id"]),
                                IsArhiving = Convert.ToBoolean(dr["_IsArhiving"]),
                                IsReserved = Convert.ToBoolean(dr["_IsReserving"])

                            }).ToList();

            dt = DataTable;
        }
    }
}
