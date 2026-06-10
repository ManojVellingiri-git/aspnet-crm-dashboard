using System;
using System.ComponentModel.DataAnnotations;

namespace aspnet_crm_dashboard.Models
{
    public class Lead
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Niche { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "New"; // New, Contacted, Qualified, Booked

        [Required]
        [StringLength(50)]
        public string Revenue { get; set; } = "Unknown";

        [Required]
        [StringLength(200)]
        public string Bottleneck { get; set; } = "None";

        public string Notes { get; set; } = string.Empty;

        [Range(1, 10)]
        public int FitScore { get; set; } = 5;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
