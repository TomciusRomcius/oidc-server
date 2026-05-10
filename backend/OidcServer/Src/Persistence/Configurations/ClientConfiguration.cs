using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OidcServer.Domain.Client;

namespace OidcServer.Persistence.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<ClientAggregate>
{
    public void Configure(EntityTypeBuilder<ClientAggregate> builder)
    {
        builder.HasKey(client => client.ClientId);
        builder.Property(client => client.ClientId)
            .HasMaxLength(32);
    }
}
