namespace CodefictionApi.Core.Contracts
{
    public interface IVideo : IContent
    {
        string Type { get; set; }
    }
}