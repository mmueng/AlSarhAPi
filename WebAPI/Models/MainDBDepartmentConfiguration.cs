

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class MainDBDepartmentConfiguration : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<MainDep>
    {
        public void Configure(EntityTypeBuilder<MainDep> builder)
        {
            builder.HasMany(g => g.DepartmentList)
               .WithOne(s => s.CurrMainDep)
               .HasForeignKey(s => s.CurrMainDepID);

           // builder.HasOne(ss => ss.Subject)
           //  .WithMany(s => s.StudentSubjects)
           //  .HasForeignKey(ss => ss.SubjectId);
        }
        public void Configure(EntityTypeBuilder<LoginModel> builder)
        {
            builder.HasNoKey();
        }
        //microsoft.entityframeworkcore
    }
}
