namespace iQuest.TheUniverse.Infrastructure
{
    public interface IRequestHandler
    {
        object Execute(object request);
    }
}