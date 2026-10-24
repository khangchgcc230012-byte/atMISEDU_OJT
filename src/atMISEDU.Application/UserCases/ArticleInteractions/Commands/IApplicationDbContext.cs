using atMISEDU.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace atMISEDU.Application;

public interface IApplicationDbContext
{
    DbSet<ArticleInteraction> ArticleInteractions { get; }
    DbSet<ArticleDiscussionInteraction> ArticleDiscussionInteractions { get; set; }
    DbSet<ArticleVote> ArticleVotes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}