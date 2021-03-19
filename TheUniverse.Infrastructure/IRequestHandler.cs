namespace iQuest.TheUniverse.Infrastructure
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}