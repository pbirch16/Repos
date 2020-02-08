using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EF6Console2
{
    public class StudentConfigurations : EntityTypeConfiguration<Student>
    {
        public StudentConfigurations()
        {
            this.Property(s => s.StudentName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.StudentName)
                .IsConcurrencyToken();

            //Configure a one-to-one relationship between Student and StudentAddress
            this.HasOptional(s => s.Address)        //Mark Student.Address property optional (nullable)
                .WithRequired(ad => ad.Student);    //Mark StudentAddress.Sudent property as required (Not Null)                               
        }
    }
}
