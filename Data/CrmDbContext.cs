using Microsoft.EntityFrameworkCore;
using aspnet_crm_dashboard.Models;
using System;

namespace aspnet_crm_dashboard.Data
{
    public class CrmDbContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; } = null!;

        public CrmDbContext()
        {
        }

        public CrmDbContext(DbContextOptions<CrmDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=crm_database.db");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed 10 Mock Leads
            modelBuilder.Entity<Lead>().HasData(
                new Lead
                {
                    Id = 1,
                    Name = "Jeroen (Dutch Personal Branding)",
                    Email = "jeroen@personalbrand.nl",
                    Niche = "Personal Branding Coach",
                    Status = "Booked",
                    Revenue = "$18,000 / month",
                    Bottleneck = "DM response time delay (DMs checked twice daily)",
                    Notes = "Interested in integrating Sarah AI DM Setter with official Meta API translation helper.",
                    FitScore = 10,
                    CreatedDate = DateTime.UtcNow.AddDays(-5)
                },
                new Lead
                {
                    Id = 2,
                    Name = "Studio Sync Agency",
                    Email = "hiring@studiosync.co",
                    Niche = "AI Automation & SaaS Agency",
                    Status = "Contacted",
                    Revenue = "Unknown",
                    Bottleneck = "Bandwidth limitations for cold SMS follow-ups",
                    Notes = "Wants to automate follow-up track so human reps can focus on cold dials.",
                    FitScore = 10,
                    CreatedDate = DateTime.UtcNow.AddDays(-4)
                },
                new Lead
                {
                    Id = 3,
                    Name = "Cult Media UGC",
                    Email = "hiring@cultmedia.co",
                    Niche = "UGC Performance Creative Agency",
                    Status = "New",
                    Revenue = "$40,000 / month",
                    Bottleneck = "Speed-to-lead for scaling ad inquiry volume",
                    Notes = "Hit $40k/mo in 5 months. Hiring their first appointment setter to scale calendar bookings.",
                    FitScore = 10,
                    CreatedDate = DateTime.UtcNow.AddDays(-3)
                },
                new Lead
                {
                    Id = 4,
                    Name = "Boston Medspa Clinic",
                    Email = "contact@bostonmedaesthetics.com",
                    Niche = "Medical Spa & Aesthetics",
                    Status = "Qualified",
                    Revenue = "$25,000 / month",
                    Bottleneck = "SMS follow-ups / Stripe deposit integrations",
                    Notes = "Needs GHL configuration to call leads within 60 seconds and coordinate deposit payments.",
                    FitScore = 9,
                    CreatedDate = DateTime.UtcNow.AddDays(-3)
                },
                new Lead
                {
                    Id = 5,
                    Name = "Contaktly AI SaaS",
                    Email = "founders@contaktly.io",
                    Niche = "AI SaaS for Booking Meetings",
                    Status = "Contacted",
                    Revenue = "Unknown",
                    Bottleneck = "Manual B2B list compiling & cold call setting",
                    Notes = "Outbound campaign to book agency founders for a 20-minute software demo.",
                    FitScore = 8,
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                },
                new Lead
                {
                    Id = 6,
                    Name = "Care Home Director",
                    Email = "director@ukcaregroup.co.uk",
                    Niche = "Elderly Care Services",
                    Status = "Contacted",
                    Revenue = "Unknown",
                    Bottleneck = "None",
                    Notes = "Pure phone outreach role for B2B sector. Not a fit for our conversational DM/SMS solution.",
                    FitScore = 2,
                    CreatedDate = DateTime.UtcNow.AddDays(-6)
                },
                new Lead
                {
                    Id = 7,
                    Name = "Alex FBA Store",
                    Email = "alex@fbaretailers.com",
                    Niche = "Amazon FBA Retail",
                    Status = "New",
                    Revenue = "$3,000 / month",
                    Bottleneck = "Low budget / basic web design needs",
                    Notes = "Requested custom web design instead of lead pipelines or DM setters.",
                    FitScore = 3,
                    CreatedDate = DateTime.UtcNow.AddDays(-1)
                },
                new Lead
                {
                    Id = 8,
                    Name = "E-Commerce Growth Coach",
                    Email = "support@ecomgrowth.com",
                    Niche = "E-com Coaching Brand",
                    Status = "Booked",
                    Revenue = "$12,000 / month",
                    Bottleneck = "Qualifying prospects inside DMs",
                    Notes = "Needs helper to ask standard qualification prompts before releasing calendar link.",
                    FitScore = 10,
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                },
                new Lead
                {
                    Id = 9,
                    Name = "Miami Real Estate Marketing",
                    Email = "leads@miamireads.com",
                    Niche = "Instagram Marketing Agency",
                    Status = "New",
                    Revenue = "Unknown",
                    Bottleneck = "Sourcing lead details and tracking pipelines",
                    Notes = "Commission only AE/BDR role closing luxury real estate packages.",
                    FitScore = 8,
                    CreatedDate = DateTime.UtcNow.AddDays(-1)
                },
                new Lead
                {
                    Id = 10,
                    Name = "Digital Marketer",
                    Email = "digitalmarketer@gmail.com",
                    Niche = "Unrelated / Freelance Contractor",
                    Status = "New",
                    Revenue = "Unknown",
                    Bottleneck = "None",
                    Notes = "Looking for a video editor/UGC creator. Auto-disqualified.",
                    FitScore = 1,
                    CreatedDate = DateTime.UtcNow.AddDays(-7)
                }
            );
        }
    }
}
