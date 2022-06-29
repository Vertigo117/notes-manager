using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Configurations;

public class NoteEntityConfiguration : BaseEntityConfiguration<NoteEntity>
{
    public override void Configure(EntityTypeBuilder<NoteEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(NotesManagerDbContext.Notes));

        builder.Property(entity => entity.Name).IsRequired(false);
        builder.Property(entity => entity.Text).IsRequired(false);
        builder.Property(entity => entity.CreationDate)
            .IsRequired()
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd();
        builder.Property(entity => entity.UserId).IsRequired();

        builder.HasOne(entity => entity.User).WithMany(entity => entity.Notes).HasForeignKey(entity => entity.UserId);
    }
}