namespace WorkFlowManager.Common.Tables
{
    public class HierarchyExplorerForm : BaseTable
    {
        public HierarchyExplorerForm()
        {

        }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        public string OfficerId { get; set; }

        public string LineManagerId { get; set; }

        public string SubDirectorId { get; set; }

        public string DirectorId { get; set; }
    }
}
