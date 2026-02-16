using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace ActionHistoryApp.API.Persistence.Entities
{
    public class ActionItem
    {
        public int Id { get; set; }
        public string DataBaseName { get; set; } = string.Empty;
        public string WhoDid { get; set; } = string.Empty;
        public string WhatDid { get; set; } = string.Empty;
        public DateTime WhenDid { get; set; }
    }

    public class ActionItemConfig : IEntityTypeConfiguration<ActionItem>
    {
        public void Configure (EntityTypeBuilder<ActionItem> builder)
        {
            builder.Property(_ => _.DataBaseName).IsRequired();
            builder.Property(_ => _.WhoDid).IsRequired();
            builder.Property(_ => _.WhatDid).IsRequired();
            builder.Property(_ => _.WhenDid).IsRequired();
        }
    }
}
