using Dataverse.XrmTools.Deployer.Enums;
using System;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class SolutionHistory
    {
        public string LogicalName { get; set; }
        public HistoryOperation Operation { get; set; }
        public HistoryStatus Status { get; set; }
        public HistoryResult Result { get; set; }
        public DateTime StartTime { get; set; }
        public string Message { get; set; }
    }
}