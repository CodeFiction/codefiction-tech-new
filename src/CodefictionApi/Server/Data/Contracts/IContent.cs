using System;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Data.Contracts
{
    public interface IContent
    {
        int Id { get; set; }
        string Title { get; set; }
        string Slug { get; set; }
        string YoutubeUrl { get; set; }
        string ShortDescription { get; set; }
        string LongDescription { get; set; }
        string[] Attendees { get; set; }
        string[] Tags { get; set; }
        Relation[] Relations { get; set; }
        DateTime PublishDate { get; set; }
    }
}