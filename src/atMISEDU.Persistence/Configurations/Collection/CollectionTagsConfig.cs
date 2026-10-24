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
            builder.Property(x => x.Id).HasColumnName(CollectionTagsConst.FIELD_KEY_TAGS);
            builder.Property(x => x.TagsName).HasColumnName(CollectionTagsConst.FIELD_TAGS_NAME).HasMaxLength(CollectionTagsConst.TAGS_NAME_MAX_LENGTH);
            builder.Property(x => x.TagsDescription).HasColumnName(CollectionTagsConst.FIELD_TAGS_DESCRIPTION).HasMaxLength(CollectionTagsConst.TAGS_DESCRIPTION_MAX_LENGTH);
            builder.Property(x => x.TagsIcon).HasColumnName(CollectionTagsConst.FIELD_TAGS_ICON).HasMaxLength(CollectionTagsConst.TAGS_ICON_MAX_LENGTH);
            builder.Property(x => x.TagsStyle).HasColumnName(CollectionTagsConst.FIELD_TAGS_STYLE).HasMaxLength(CollectionTagsConst.TAGS_STYLE_MAX_LENGTH);
            builder.Property(x => x.CreatedBy).HasColumnName(CollectionTagsConst.FIELD_CREATED_BY);
            builder.Property(x => x.CreatedDate).HasColumnName(CollectionTagsConst.FIELD_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(CollectionTagsConst.FIELD_IS_ACTIVED);

            builder.ToTable(TableConst.TABLE_COLLECTION_TAGS);
        }
    }
}