namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts
{
    public interface IVideo : IContent
    {
        string Type { get; set; }
    }
}