using System.Web.Mvc;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.IServices;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{
    public class HierarchExplorerService : WorkFlowProcessService, IWorkFlow
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly WorkFlowDataService workFlowDataService;
        public HierarchExplorerService(
            IUnitOfWork unitOfWork, 
            WorkFlowDataService workFlowDataService) :
            base(unitOfWork, workFlowDataService)
        {
            this.unitOfWork = unitOfWork;
            this.workFlowDataService = workFlowDataService;
        }

        public string DecisionPointJobCall(string id, string jobId, string hourInterval)
        {
            throw new System.NotImplementedException();
        }

        public void FormSave(WorkFlowFormViewModel formData)
        {
            throw new System.NotImplementedException();
        }

        public bool FormValidate(WorkFlowFormViewModel formData, ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }
    }
}
