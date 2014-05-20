using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region sync
            //WS.BookServiceClient bsc = new WS.BookServiceClient("NetTcpBinding_IBookService");
            //WS.Book bk1 = new WS.Book();
            //bk1.BookName = "数学之美";
            //bk1.BookPrice = 36;
            //WS.Book bk2 = new WS.Book();
            //bk2.BookName = "浪潮之巅";
            //bk2.BookPrice = 50;
            //bsc.AddBook(bk1);
            //bsc.AddBook(bk2);
            //foreach (var book in bsc.GetAllBooks())
            //{
            //    Console.WriteLine("{0}\t{1}",book.BookName,book.BookPrice);
            //}
            //Console.ReadKey();
            #endregion
            #region async
            WS.BookServiceClient bst = new WS.BookServiceClient("NetTcpBinding_IBookService");
            bst.AddBookCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(bst_AddBookCompleted);
            bst.GetAllBooksCompleted += new EventHandler<WS.GetAllBooksCompletedEventArgs>(bst_GetAllBooksCompleted);
            WS.Book bk1 = new WS.Book();
            bk1.BookName = "数学之美async";
            bk1.BookPrice = 36;
            WS.Book bk2 = new WS.Book();
            bk2.BookName = "浪潮之巅async";
            bk2.BookPrice = 50;
            bst.AddBookAsync(bk1);
            bst.AddBookAsync(bk2);
            bst.GetAllBooksAsync();
            Console.ReadKey();
            #endregion
        }

        static void bst_GetAllBooksCompleted(object sender, WS.GetAllBooksCompletedEventArgs e)
        {
            foreach (var book in e.Result)
            {
                Console.WriteLine("{0}\t{1}",book.BookName,book.BookPrice);
            };
        }

        static void bst_AddBookCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Added complete");
        }
    }
}
