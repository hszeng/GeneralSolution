using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Services
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class BookService:IBookService
    {
        private List<Book> _Books = new List<Book>();
        public void AddBook(Book book)
        {
            book.BookNo = Guid.NewGuid().ToString();
            _Books.Add(book);
        }

        public List<Book> GetAllBooks()
        {
            return _Books;
        }

        public void ReomveBook(string id)
        {
            Book book = _Books.Find(b=>b.BookNo==id);
            _Books.Remove(book);
        }
    }
}
