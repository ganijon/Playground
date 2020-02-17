using GraphQL;
using Playground.Graph.Schema.Queries;
using Playground.Graph.Schema.Mutations;
using Playground.Graph.Schema.Subscriptions;

namespace Playground.Graph.Schema
{
    public class TheSchema : GraphQL.Types.Schema
    {
        public TheSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TheQuery>();
            Mutation = resolver.Resolve<TheMutation>();
            Subscription = resolver.Resolve<TheSubscription>();
        }
    }
}
