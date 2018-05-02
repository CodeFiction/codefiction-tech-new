namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts
{
    public interface IPodcast : IContent
    {
        int Season { get; set; }
        string SoundcloudId { get; set; }
        string Guest { get; set; }
    }
}