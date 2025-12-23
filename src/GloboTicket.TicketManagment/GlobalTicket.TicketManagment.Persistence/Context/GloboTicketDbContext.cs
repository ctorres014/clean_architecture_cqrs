using GloboTicket.TicketManagment.Domain.Common;
using GloboTicket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagment.Persistence.Context
{
    public class GloboTicketDbContext : DbContext
    {
        public GloboTicketDbContext(DbContextOptions<GloboTicketDbContext> context)
            : base(context)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Apply configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GloboTicketDbContext).Assembly);
            // seed data, added through migrations
            #region Category
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
                var musicalGuid = Guid.Parse("{FE9A5E7D-5D6C-4F3B-8D9E-8E1C2D5C8BCE}");
                var playGuid = Guid.Parse("{7D4E4B6C-2A1F-4F3E-9F8E-3C2B1A0D9E8F}");
                var conferenceGuid = Guid.Parse("{A1B2C3D4-E5F6-4789-ABCD-1234567890AB}");

                modelBuilder.Entity<Category>().HasData(new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                });

                modelBuilder.Entity<Category>().HasData(new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                });

                modelBuilder.Entity<Category>().HasData(new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                });

                modelBuilder.Entity<Category>().HasData(new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                });

            #endregion
            #region Event
            modelBuilder.Entity<Event>().HasData(new Event{
                Id = Guid.Parse("{D28888E9-2BA9-473A-A40F-EF8A7875835C}"),
                Name = "John Egbert Live",
                Price = "65",
                Artist = "John Egbert",
                Date = new DateTime(2025,6, 1),
                Description = "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already sold over 25 million albums worldwide.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/concert1.png",
                CategoryId = concertGuid,
                CreatedBy = "System",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{D7B4F2E2-5D3C-4A8C-9A6F-8D9E7C6B5A4F}"),
                Name = "The State of Affairs: Michael Live!",
                Price = "85",
                Artist = "Michael Johnson",
                Date = new DateTime(2025, 9, 1),
                Description = "Michael Johnson doesn't need an introduction either. His 25th album is coming out this fall and we are going to celebrate the launch with a big concert.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/concert2.png",
                CategoryId = concertGuid,
                CreatedBy = "System",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                Id = Guid.Parse("{A1C2E3F4-5678-4B9A-BCDE-1234567890AB}"),
                Name = "To the Moon and Back",
                Price = "135",
                Artist = "Nick Sailor",
                Date = new DateTime(2025, 12, 1),
                Description = "The critics are raving about this new musical production that takes you on an emotional ride through the universe.",
                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical1.png",
                CategoryId = musicalGuid,
                CreatedBy = "System",
                CreateDate = DateTime.Now
            });


            #endregion
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }   
            }
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
