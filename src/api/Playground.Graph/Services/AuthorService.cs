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
    public interface IAuthorService
    {
        IObservable<Author> AuthorAdded();
        Author Create(Author obj);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IRepository _repository;
        private readonly ISubject<Author> _subject;

        public AuthorService(IRepository repository)
        {
            _repository = repository;
            _subject = new ReplaySubject<Author>(1);
        }

        public Author Create(Author obj)
        {
            _repository.Add(obj);
            _subject.OnNext(obj);
            return obj;
        }

        public IObservable<Author> AuthorAdded()
        {
            return _subject.AsObservable();
        }
    }
}
