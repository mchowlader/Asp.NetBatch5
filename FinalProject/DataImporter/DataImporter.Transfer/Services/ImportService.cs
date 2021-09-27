using AutoMapper;
using DataImporter.Transfer.BusinessObjects;
using DataImporter.Transfer.UnitOfWorks;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Transfer.Services
{
    public class ImportService : IImportService
    {
        private readonly IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;
        private readonly ITransferUnitOfWork _transferUnitOfWork;


        public ImportService(IMapper mapper, ITransferUnitOfWork transferUnitOfWork)
        {
            _mapper = mapper;
            _transferUnitOfWork = transferUnitOfWork;
        }

        public (IList<Import> records, int total, int totalDisplay) GetImportsData(int pageIndex,
            int pageSize, string searchText, string sortText, Guid id)
        {
            var importsData = _transferUnitOfWork.Imports.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.GroupName.Contains(searchText),
               sortText, string.Empty, pageIndex, pageSize);

            var groupData = _transferUnitOfWork.Groups.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.UserId.ToString().Contains(searchText),
               sortText, string.Empty, pageIndex, pageSize);

            var resultData = new List<Import>();
            foreach(var  group in groupData.data)
            {
                foreach(var import in  importsData.data)
                {
                    if(group.UserId == id && import.GroupId == group.Id)
                    {
                        var importData = _mapper.Map<Import>(import);
                        resultData.Add(importData);
                    }
                }
            }

            //var groupData1 = _transferUnitOfWork.Groups.GetAll();
            //var resultData2 = (from import in importsData.data
            //                  join groups in groupData1 on import.GroupId equals groups.Id
            //                  where import.GroupId == groups.Id
            //                  select _mapper.Map<Group>(import)).ToList();

            return (resultData, importsData.total, importsData.totalDisplay);
        }

        public void UploadExcelFile(Import importsData)
        {
            var groupEntity = _transferUnitOfWork.Groups.GetById(importsData.GroupId);
            _transferUnitOfWork.Imports.Add(
                new Entities.Import()
                {
                    Status = importsData.Status,
                    GroupId = importsData.GroupId,
                    FilePath = importsData.FilePath,
                    GroupName = groupEntity.GroupName,
                    ImportDate = importsData.ImportDate,
                    ExcelFileName = importsData.ExcelFileName

                });
            _transferUnitOfWork.Save();
        }



        //public IList<Group> LoadGroupProperty(Guid id)
        //{
        //    var groupsList = new List<Group>();
        //    var groupEntity = _transferUnitOfWork.Groups.GetAll();

        //    groupsList = (from groups in groupEntity
        //                  where groups.UserId == id
        //                  select _mapper.Map<Group>(groups)).ToList();

        //    return groupsList;
        //}

    }
}
