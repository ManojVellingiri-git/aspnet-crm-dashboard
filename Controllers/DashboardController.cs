using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnet_crm_dashboard.Data;
using aspnet_crm_dashboard.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_crm_dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly CrmDbContext _context;

        public DashboardController(CrmDbContext context)
        {
            _context = context;
        }

        // GET: /Dashboard or /
        [Route("")]
        [Route("Dashboard")]
        public async Task<IActionResult> Index()
        {
            var leads = await _context.Leads.OrderByDescending(l => l.FitScore).ToListAsync();
            return View(leads);
        }

        // POST: /Dashboard/UpdateStatus
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead == null)
            {
                return Json(new { success = false, message = "Lead not found" });
            }

            // Clean status parameter
            status = status.Trim();
            if (status == "New" || status == "Contacted" || status == "Qualified" || status == "Booked")
            {
                lead.Status = status;
                _context.Update(lead);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Invalid status" });
        }

        // POST: /Dashboard/CreateLead
        [HttpPost]
        public async Task<IActionResult> CreateLead([FromForm] Lead lead)
        {
            if (ModelState.IsValid)
            {
                lead.CreatedDate = DateTime.UtcNow;
                _context.Add(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Dashboard/GetChartData
        [HttpGet]
        public async Task<IActionResult> GetChartData()
        {
            var leads = await _context.Leads.ToListAsync();

            // 1. Pipeline Stage Distribution
            var stages = new[] { "New", "Contacted", "Qualified", "Booked" };
            var pipelineData = stages.Select(s => leads.Count(l => l.Status == s)).ToArray();

            // 2. High Fit vs Low Fit Distribution
            var fitHigh = leads.Count(l => l.FitScore >= 8);
            var fitMedium = leads.Count(l => l.FitScore >= 5 && l.FitScore <= 7);
            var fitLow = leads.Count(l => l.FitScore < 5);
            var fitData = new[] { fitHigh, fitMedium, fitLow };

            return Json(new
            {
                pipelineLabels = stages,
                pipelineCounts = pipelineData,
                fitLabels = new[] { "High Fit (8-10)", "Medium Fit (5-7)", "Poor Fit (1-4)" },
                fitCounts = fitData
            });
        }
    }
}
