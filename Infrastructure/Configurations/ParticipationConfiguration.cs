using ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ParticipationConfiguration : IEntityTypeConfiguration<Participation>
    {
        public void Configure(EntityTypeBuilder<Participation> builder)
        {
            builder.HasKey(t => new { t.ParticipantFK, t.CagnotteFK }); //Clée primaire composée  

            builder.HasOne(t => t.MYparticipant)
                     .WithMany(f => f.participations)
                     .HasForeignKey(t => t.ParticipantFK);
            builder.HasOne(t => t.MYcagnotte)//  My Passanger heya l variable de Ticket prop de navigation [] 
                   .WithMany(p => p.participations)
                   .HasForeignKey(t => t.CagnotteFK);
        }
    }
}
