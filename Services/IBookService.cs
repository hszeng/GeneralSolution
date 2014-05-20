using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IBookService
    {
        [OperationContract]
        void AddBook(Book book);
        [OperationContract]
        List<Book> GetAllBooks();
        [OperationContract]
        void ReomveBook(string id);
    }
}
