using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActionHistoryApp.API.Persistence.Entities
{
    [Table("Actions")] // Указываем имя таблицы
    public class ActionItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("DataBaseName")]
        public string DataBaseName { get; set; } = string.Empty;
        [Required]
        public string WhoDid { get; set; } = string.Empty;
        [Required]
        public string WhatDid { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "datetime2")]
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
