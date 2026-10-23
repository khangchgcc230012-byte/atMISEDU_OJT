using atMISEDU.Contract.Abstractions;

namespace atMISEDU.Application.Requests.Collections.CollectionArticles
{
    public class CreateCollectionArticlesRequest : ICommand
    {
        public string? ArticleTitle { get; set; }
        public string? ArticleAbstract { get; set; }
        public string? ArticleContent { get; set; }
        public string? ArticleThumbnail { get; set; }
        public int? ArticlePublishedDate { get; set; }
        public int? ArticleTimeReading { get; set; } = 0;
        public int? ArticleViews { get; set; } = 0;
        public string? ArticleIPAddress { get; set; }
        public string? ArticleBrowser { get; set; }
        public string? ArticleOstype { get; set; }
        public int? CreatedBy { get; set; }
        public byte? IsActived { get; set; } = 1;
        public List<int>? TagIds { get; set; }
    }
}