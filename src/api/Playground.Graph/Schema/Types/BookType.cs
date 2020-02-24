using Playground.Data;
using GraphQL.Types;

namespace Playground.Graph.Schema.Types
{
    public class BookType : ObjectGraphType<Book>
    {

        public BookType()
        {
            Name = "Book";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Book.");
            Field(x => x.Name).Description("The name of the Book");
            Field(x => x.Genre).Description("Book genre");
            Field(x => x.Published).Description("If the book is published or not");
            Field(x => x.AuthorId).Description("Book's author id");
            Field(x => x.Author, type: typeof(AuthorType)).Description("Book's author");
        }
    }
}
