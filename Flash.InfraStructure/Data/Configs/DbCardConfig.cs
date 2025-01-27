using Flash.Domain.Models.Card;
using Microsoft.EntityFrameworkCore;

namespace Flash.InfraStructure.Data.Configs
{
    public class DbCardConfig
    {
        public static void Setup(ModelBuilder builder)
        {
            builder.Entity<Card>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreatedOn).IsRequired();
                entity.Property(e => e.Revised).IsRequired();
                entity.Property(e => e.Matter).IsRequired();
                entity.Property(e => e.Urgency).IsRequired();
            });
        }
    }
}