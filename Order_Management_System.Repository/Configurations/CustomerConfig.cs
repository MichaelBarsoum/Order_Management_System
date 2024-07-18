using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management_System.Repositories.Models;

namespace Order_Management_System.CORE.Configurations
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(C => C.Id).IsClustered();
            builder.HasMany(C => C.Orders).WithOne(C => C.Customer);

        }
    }
}
