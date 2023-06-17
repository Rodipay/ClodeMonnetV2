using System;

namespace ClodeMonnetV2.Model;

public sealed class Report
{
    public Report(User user)
    {
        User = user;
    }
    public Report() { }

    public int ReportId { get; set; }
    public int UserId { get; set; }
    public DateTime ReportTime { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public User? User { get; set; }
}