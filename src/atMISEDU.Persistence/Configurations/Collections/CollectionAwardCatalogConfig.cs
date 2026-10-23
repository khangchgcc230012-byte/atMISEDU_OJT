using atMISEDU.Domain.Constants;
using atMISEDU.Domain.Constants.Collections;
using atMISEDU.Domain.Entities.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace atMISEDU.Persistence.Configurations.Collections
{
    public class CollectionAwardCatalogConfiguration : IEntityTypeConfiguration<CollectionAwardCatalog>
    {
        public void Configure(EntityTypeBuilder<CollectionAwardCatalog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName(CollectionAwardCatalogConst.FIELD_ID);
            builder.Property(x => x.AwardName).HasColumnName(CollectionAwardCatalogConst.FIELD_AWARD_NAME);
            builder.Property(x => x.AwardDescription).HasColumnName(CollectionAwardCatalogConst.FIELD_AWARD_DESCRIPTION);
            builder.Property(x => x.AwardIcon).HasColumnName(CollectionAwardCatalogConst.FIELD_AWARD_ICON);
            builder.Property(x => x.AwardPoint).HasColumnName(CollectionAwardCatalogConst.FIELD_AWARD_POINT);
            builder.Property(x => x.CreatedBy).HasColumnName(CollectionAwardCatalogConst.FIELD_CREATED_BY);
            builder.Property(x => x.CreatedDate).HasColumnName(CollectionAwardCatalogConst.FIELD_CREATED_DATE);
            builder.Property(x => x.IsActived).HasColumnName(CollectionAwardCatalogConst.FIELD_IS_ACTIVED);

            builder.ToTable(TableConst.TABLE_COLLECTION_AWARD_CATALOG);
        }
    }
}