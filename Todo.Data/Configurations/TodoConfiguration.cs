
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Models.Entities.Todo>
    {
        public void Configure(EntityTypeBuilder<Models.Entities.Todo> builder)
        {
            builder.ToTable("Tasks").HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("PostId");
            builder.Property(c => c.CreatedTime).HasColumnName("CreatedTime");
            builder.Property(c => c.DueDate).HasColumnName("UpdatedTime");
            builder.Property(c => c.Title).HasColumnName("Title");
            builder.Property(c => c.Priority).HasColumnName("Content");
            builder.Property(c => c.IsCompleted).HasColumnName("IsCompleted");
            builder.Property(c => c.Description).HasColumnName("Description");

            builder.Property(c => c.UserId).HasColumnName("UserId");
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId");


            builder.HasOne(x => x.Category).WithMany(x => x.Todos).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.NoAction);


            builder.Navigation(x => x.Category).AutoInclude();
            builder.Navigation(x => x.User).AutoInclude();

        }
    }
}
