﻿using AM1.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //Configurer la relation *-*
            //builder.HasMany(f => f.Passengers)
            //    .WithMany(p=>p.Flights)
            //    .UsingEntity(t=>t.ToTable("reservations"));

            //Configurer la retaltion 1-*
            builder.HasOne(f=>f.Plane).WithMany(p=>p.Flights)
                .HasForeignKey(f=>f.PlaneFK).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
