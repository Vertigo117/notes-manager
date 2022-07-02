using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesManager.Domain.Entities;
using NotesManager.Domain.Enums;
using NotesManager.Domain.Extensions;

namespace NotesManager.Storage.PostgreSql.Configurations;

public class RoleEntityConfiguration : BaseEntityConfiguration<RoleEntity>
{
    public override void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(NotesManagerDbContext.Roles));

        builder.Property(entity => entity.Name).HasConversion<EnumToStringConverter<UserRoles>>().IsRequired();
        builder.Property(entity => entity.Description).IsRequired(false);

        builder.HasMany(entity => entity.Users).WithOne(entity => entity.Role).HasForeignKey(entity => entity.RoleId);

        builder.HasData(GetRoles());
    }

    private static IEnumerable<RoleEntity> GetRoles()
    {
        return Enum.GetValues<UserRoles>()
            .Select(value => new RoleEntity
            {
                Id = (int) value,
                Name = value,
                Description = value.GetDescription()
            });
    }
}