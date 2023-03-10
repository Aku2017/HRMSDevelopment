using HRMScore.Entities.Base;

namespace HRMScore.Entities
{
    public class Leave: BaseEntity
    {
        public string Name { get; set; }
        public int Days { get; set; }
        public decimal Allowance { get; set; }
        public List<ApplyLeave> applyLeaves { get; set; }
    }
}
