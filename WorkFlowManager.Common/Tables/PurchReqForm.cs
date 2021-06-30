namespace WorkFlowManager.Common.Tables
{
    public class PurchReqForm : BaseTable
    {
        public int OwnerId { get; set; }
        public BaseTable Owner { get; set; }
        public int Amount { get; set; }
        public bool Budgeted { get; set; }
    }
}
