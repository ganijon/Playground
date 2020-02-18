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
        private readonly ISubject<Book> _subject;

        public BookService(IRepository repository)
        {
            _repository = repository;
            _subject = new ReplaySubject<Book>(1);
        }

        public Book Create(Book obj)
        {
            _repository.Add(obj);
            _subject.OnNext(obj);
            return obj;
        }

        public IObservable<Book> BookAdded()
        {
            return _subject.AsObservable();
        }
    }
}
