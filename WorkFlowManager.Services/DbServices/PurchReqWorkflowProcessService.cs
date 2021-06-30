using AutoMapper;
using Hangfire;
using System.Web.Mvc;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.IServices;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{
    public class PurchReqWorkflowProcessService : WorkFlowProcessService, IWorkFlow
    {
        private readonly WorkFlowDataService workFlowDataService;
        private readonly IUnitOfWork unitOfWork;

        public PurchReqWorkflowProcessService(
            IUnitOfWork unitOfWork,
            WorkFlowDataService workFlowDataService
            ) : base(unitOfWork, workFlowDataService)
        {
            this.workFlowDataService = workFlowDataService;
            this.unitOfWork = unitOfWork;
        }


        #region Decission Methods
        public char IsCompleted(string id, string amount)
        {
            var rslt = 'N';
            int ownerId = GetOwnerIdFromId(int.Parse(id));
            var purchreqForm = unitOfWork.Repository<PurchReqForm>().Get(
                x => x.OwnerId == ownerId);

            if (purchreqForm != null)
            {
                if (purchreqForm.Amount < int.Parse(amount))
                {
                    rslt = 'Y';
                }
            }
            return rslt;
        }

        public char IsBudgeted(string id)
        {
            var rslt = 'N';
            int ownerId = GetOwnerIdFromId(int.Parse(id));
            var testForm = unitOfWork.Repository<PurchReqForm>().Get(x => x.OwnerId == ownerId);
            if (testForm != null)
            {
                if (testForm.Budgeted)
                {
                    rslt = 'Y';
                }
            }
            return rslt;
        }

        #endregion

        #region Workflow

        private new int GetOwnerIdFromId(int id)
        {
            var workFlowTrace = unitOfWork.Repository<WorkFlowTrace>().Get(x => x.Id == id);
            int rslt = -1;
            if (workFlowTrace != null)
            {
                rslt = workFlowTrace.OwnerId;
            }
            return rslt;
        }

        public bool FormValidate(
            WorkFlowFormViewModel formData,
            ModelStateDictionary modelState)
        {
            return base.CustomFormValidate(formData, modelState);
        }


        public void FormSave(WorkFlowFormViewModel formData)
        {
            base.CustomFormSave(formData);
        }

        public override void WorkFlowFormSave<TClass, TVM>(
            WorkFlowFormViewModel workFlowFormViewModel)
        {
            base.WorkFlowFormSave<TClass, TVM>(workFlowFormViewModel);
            WorkFlowTrace torSatinAlmaIslem = Mapper.Map<WorkFlowFormViewModel, WorkFlowTrace>(workFlowFormViewModel);
            AddOrUpdate(torSatinAlmaIslem);
        }

        public override void WorkFlowProcessCancel(int workFlowTraceId)
        {
            base.WorkFlowProcessCancel(workFlowTraceId);
        }

        public override void CancelWorkFlowTrace(int workFlowTraceId, int targetProcessId)
        {
            base.CancelWorkFlowTrace(workFlowTraceId, targetProcessId);
        }

        public override void GoToWorkFlowNextProcess(int ownerId)
        {
            base.GoToWorkFlowNextProcess(ownerId);
        }

        public string DecisionPointJobCall(string id, string jobId, string hourInterval)
        {
            base.DecisionPointJobCallBase(id, jobId, hourInterval);

            RecurringJob.AddOrUpdate<PurchasingWorkFlowProcessService>(
                jobId, x => x.DecisionPointTakeTheNextStep(int.Parse(id)),
                Cron.HourInterval(int.Parse(hourInterval)));

            return "OK";
        }
        #endregion
    }
}
