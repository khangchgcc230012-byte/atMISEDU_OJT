using atMISEDU.Domain.Constants;
using atMISEDU.Domain.Constants.Collections;
using atMISEDU.Domain.Entities.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace atMISEDU.Persistence.Configurations.Collections
{
    public class CollectionTagsConfiguration : IEntityTypeConfiguration<CollectionTags>
    {
        public void Configure(EntityTypeBuilder<CollectionTags> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(CollectionTagsConst.FIELD_ID);
            builder.Property(x => x.TagName).HasColumnName(CollectionTagsConst.FIELD_TAG_NAME);
            builder.Property(x => x.TagSlug).HasColumnName(CollectionTagsConst.FIELD_TAG_SLUG);
            builder.Property(x => x.TagDescription).HasColumnName(CollectionTagsConst.FIELD_TAG_DESCRIPTION);
            builder.Property(x => x.TagColor).HasColumnName(CollectionTagsConst.FIELD_TAG_COLOR);
            builder.Property(x => x.CreatedBy).HasColumnName(CollectionTagsConst.FIELD_CREATED_BY);
            builder.Property(x => x.CreatedDate).HasColumnName(CollectionTagsConst.FIELD_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(CollectionTagsConst.FIELD_IS_ACTIVED);

            builder.ToTable(TableConst.TABLE_COLLECTION_TAGS);
        }
    }
}