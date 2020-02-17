using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Playground.Data;
using Playground.Repository;

namespace Playground.Graph.Services
{
    public interface IBookService
    {
        IObservable<Book> BookAdded();
        Book Create(Book obj);
    }

    public class BookService : IBookService
    {
        private readonly IRepository _repository;
        private readonly ISubject<Book> _sub;

        public BookService(IRepository repository)
        {
            _repository = repository;
            _sub = new ReplaySubject<Book>(1);
        }

        public Book Create(Book obj)
        {
            _repository.Add(obj);
            _sub.OnNext(obj);
            return obj;
        }

        public IObservable<Book> BookAdded()
        {
            return _sub.AsObservable();
        }
    }
}
