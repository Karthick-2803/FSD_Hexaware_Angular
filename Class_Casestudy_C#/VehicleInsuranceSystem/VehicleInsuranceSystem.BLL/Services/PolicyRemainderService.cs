using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VehicleInsuranceSystem.BLL.Interfaces;
using VehicleInsuranceSystem.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
namespace VehicleInsuranceSystem.BLL.Services
{
    public class PolicyReminderService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PolicyReminderService> _logger;

        public PolicyReminderService(IServiceProvider serviceProvider, ILogger<PolicyReminderService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await SendRemindersAsync();
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // runs daily
            }
        }

        private async Task SendRemindersAsync()
        {
            using var scope = _serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<VehicleInsuranceDbContext>();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

            var today = DateTime.UtcNow.Date;
            var reminderDate = today.AddDays(7); // 7 days before expiry

            var policiesExpiringSoon = await context.Policies
                .Include(p => p.PolicyProposal)
                    .ThenInclude(pp => pp.User)
                .Where(p => p.EndDate.Date == reminderDate && p.Status == "Active")
                .ToListAsync();

            foreach (var policy in policiesExpiringSoon)
            {
                var user = policy.PolicyProposal.User;

                string body = $"""
                Dear {user.FullName},

                Your policy with ID {policy.PolicyId} is set to expire on {policy.EndDate:dd-MMM-yyyy}.

                Please renew it before expiry to continue enjoying coverage.

                Regards,
                Vehicle Insurance Team
                """;

                try
                {
                    await emailService.SendEmailWithAttachmentAsync(
                        user.Email,
                        "Policy Renewal Reminder",
                        body,
                        null, null
                    );
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Reminder failed for policy {policy.PolicyId}: {ex.Message}");
                }
            }
        }
    }

}
