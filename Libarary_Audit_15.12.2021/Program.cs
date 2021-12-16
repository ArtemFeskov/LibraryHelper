using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

//Library audit.
//Description: Program helps user to audit books.
//Features: Create application that models library processes:
//1.	Add book.
//2.	Make/Cancel a reservation for a book.
//3.	Show all books in alphabetical order.
//4.	Show reserved book.
//5.	Show available books.
//6.	Archive book (don’t delete from db, but do not show).
//7.Export books info to file. (to CSV file with columns ID, Title, Author)

//Requirements:

//1.You can choose any type of applications but you have to implement all features. There are 2 possible ways to create application:
//a.    Console application.For console application it could be printed available options that user can do.
//b.    Web application. For web application, it could be any Visual Studio web template (MVC, Web API).
//2.As database provider, you should use MS SQL Server. You can use any ORM (e.g.EntityFramework, Dapper). 
//3.Code style:
//a.    Code conventions.
//b.    Each class, interface, enum, structure is a separate file.
//c.    Business logic is in separate folder.                                         //I haven`t learnt this yet.
//d.	Data access layer is in separate folder.                                      //I haven`t learnt this yet.
//4.Database should have good design
//a.	Database is normalized
//b.	Primary keys are set
//c.	Foreign keys are set
//d.    Number of tables: 1 - 2                                                       //I haven`t learnt this yet.
//5.Will be a plus use patterns(e.g. UnitOfWork, repository)
//6.Unit tests are welcome. 
//7.Source code should be published to Github repository or any possible ways. 




namespace Libarary_Audit_15._12._2021
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Libary_ls libary_Ls = new Libary_ls();


            //1
            libary_Ls.Add(new Book("Cold Heart", "Artem Feskov")); Console.WriteLine();

            //2
            libary_Ls.Reserv_Book(libary_Ls.libary_Ls[0]); Console.WriteLine();

            //3
            libary_Ls.Print_Name_Books(); Console.WriteLine();

            //4
            libary_Ls.Print_Reserved_Books(); Console.WriteLine();

            //5
            libary_Ls.Print_Available_Books(); Console.WriteLine();

            //6
            libary_Ls.Print_All_Books_Exept_Archive(); Console.WriteLine();

            //7
            libary_Ls.Save_CSV_File(); Console.WriteLine();

        }

    }
}
