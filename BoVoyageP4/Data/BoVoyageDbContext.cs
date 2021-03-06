﻿using BoVoyageP4.Models;
using System.Data.Entity;

namespace BoVoyageP4.Data
{
    public class BoVoyageDbContext : DbContext
    {
        public BoVoyageDbContext() : base("BoVoyageConnectionString")
        {
        }

        public DbSet<AgenceVoyage> AgencesVoyages { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Commercial> Commercials { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Assurance> Assurances { get; set; }

        public DbSet<DossierReservation> DossierReservations { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Voyage> Voyages { get; set; }

        public DbSet<VoyageImage> VoyageImages { get; set; }

        public DbSet<FormulaireContact> FormulaireContacts { get; set; }

    }
}