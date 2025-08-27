using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonWebAPI.Infra.Data.Configurations.Vouchers
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            
            builder.ToTable("Vouchers");

            builder.HasKey(v => v.VoucherId);

            
            builder.Property(v => v.VoucherName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(v => v.VoucherType)
                .IsRequired()
                .HasConversion<int>();
                

            builder.Property(v => v.DebitAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)"); 

            builder.Property(v => v.CreditAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(v => v.IssuanceDate)
                .HasDefaultValue(DateTime.Now);

            builder.Property(v => v.Description)
                .HasMaxLength(500);

           
            builder.HasOne(v => v.Person)
                .WithMany(p => p.Vouchers) 
                .HasForeignKey("PersonId") 
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
 