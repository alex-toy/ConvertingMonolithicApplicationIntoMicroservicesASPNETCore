using ReportService.Models;
using System.Collections.Generic;

namespace ReportService.Utils
{
    public interface IMemoryReportStorage
    {
        void Add(Report report);
        IEnumerable<Report> Get();
    }
}