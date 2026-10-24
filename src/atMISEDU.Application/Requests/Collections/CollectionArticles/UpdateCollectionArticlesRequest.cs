using atMISEDU.Contract.Abstractions;
using System.Text.Json.Serialization;

namespace atMISEDU.Application.Requests.Collections.CollectionArticles
{
    public class UpdateCollectionArticlesRequest : ICommand
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string? ArticleTitle { get; set; }
        public string? ArticleAbstract { get; set; }
        public string? ArticleContent { get; set; }
        public string? ArticleThumbnail { get; set; }
        public int? ArticlePublishedDate { get; set; }
        public int? ArticleTimeReading { get; set; }
        public int? ArticleViews { get; set; }
        public string? ArticleIPAddress { get; set; }
        public string? ArticleBrowser { get; set; }
        public string? ArticleOstype { get; set; }
        public byte? IsActived { get; set; }
        public List<int>? TagIds { get; set; }
    }
}