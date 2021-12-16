using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libarary_Audit_15._12._2021
{
    internal class Book
    {
        private int _id = 30;


        public int ID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsArhiving { get; set; }
        public bool IsReserved { get; set; }

        public Book()
        {

        }
        public Book( string title, string author)
        {
            _id++;

            ID = _id;
            Title = title;
            Author = author;
            IsArhiving = false;
            IsReserved = false;
        }
    }
}
