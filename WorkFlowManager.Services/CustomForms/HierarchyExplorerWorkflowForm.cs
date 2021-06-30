using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.CustomForms
{
    public class HierarchyExplorerWorkflowForm : IWorkFlowForm
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper mapper;

        public HierarchyExplorerWorkflowForm(
            IUnitOfWork unitOfWork,
            Mapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public string FindLM(string empId)
        {

            return string.Empty;
        }

        public string FindSubDirector(string empId)
        {

            return string.Empty;
        }

        public string FindDirector(string empId)
        {

            return string.Empty;
        }


        private string IsEmployeeActive()
        {

            return string.Empty;
        }

        private string IsEmployeeInHierarchy()
        {

            return string.Empty;
        }

        public void Save(WorkFlowFormViewModel formData)
        {
            throw new System.NotImplementedException();
        }

        public bool Validate(WorkFlowFormViewModel formData, ModelStateDictionary modelState)
        {
            throw new System.NotImplementedException();
        }

        public WorkFlowFormViewModel Load(WorkFlowFormViewModel workFlowFormViewModel)
        {
            var healthInformationFormList =
                _unitOfWork.Repository<BusinessProcess>().GetList
                (
                    x => x.OwnerId == workFlowFormViewModel.OwnerId
                ).ToList();

            if (healthInformationFormList.Count() == 0)
            {
                var physicalExamination = new BusinessProcess()
                {
                    Name = "Physical Examination",
                    OwnerId = workFlowFormViewModel.OwnerId
                };
                var psychotechniqueResult = new BusinessProcess()
                {
                    Name = "Psychotechnique Result",
                    OwnerId = workFlowFormViewModel.OwnerId
                };

                _unitOfWork.Repository<BusinessProcess>().Add(physicalExamination);
                _unitOfWork.Repository<BusinessProcess>().Add(psychotechniqueResult);
                _unitOfWork.Complete();
                healthInformationFormList.Add(physicalExamination);
                healthInformationFormList.Add(psychotechniqueResult);
            }
            SubBusinessProcessViewModel healthInformationForm =
                new SubBusinessProcessViewModel
                {
                    SubBusinessProcessList = healthInformationFormList
                };

            Mapper.Map(workFlowFormViewModel, healthInformationForm);

            return healthInformationForm;
        }
    }
}
