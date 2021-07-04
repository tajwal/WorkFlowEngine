using System.Data.Entity.ModelConfiguration;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    class HierarchyExplorerFormMap : EntityTypeConfiguration<HierarchyExplorerForm>
    {
        public HierarchyExplorerFormMap()
        {
            ToTable("HierarchyExplorerForm");

            HasRequired(s => s.Task)
                   .WithMany(s => s.HierarchyExplorerFormList)
                   .HasForeignKey(x => x.TaskId)
                   .WillCascadeOnDelete(false);
        }
    }
}
