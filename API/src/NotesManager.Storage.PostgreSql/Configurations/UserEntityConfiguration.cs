using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotesManager.Domain.Entities;

namespace NotesManager.Storage.PostgreSql.Configurations;

public class UserEntityConfiguration : BaseEntityConfiguration<UserEntity>
{
    public override void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(NotesManagerDbContext.Users));

        builder.Property(entity => entity.Email).IsRequired();
        builder.Property(entity => entity.Name).IsRequired();
        builder.Property(entity => entity.PasswordHash).IsRequired();

        builder.HasMany(entity => entity.Notes)
            .WithOne(entity => entity.User)
            .HasForeignKey(entity => entity.UserId)
            .IsRequired();
    }
}