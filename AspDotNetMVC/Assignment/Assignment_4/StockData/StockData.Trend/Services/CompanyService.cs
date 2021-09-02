using AutoMapper;
using StockData.Trend.BusinessObject;
using StockData.Trend.UnitIfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ITrendUnitOfWork _trendUnitOfWork;

        public CompanyService(ITrendUnitOfWork trendUnitOfWork)
        {
            _trendUnitOfWork = trendUnitOfWork;
        }

        public void DataSet(Company company)
        {
            _trendUnitOfWork.Companys.Add(
                new Entities.Company()
                {
                    TradeCode = company.TradeCode
                });
            _trendUnitOfWork.Save();
        }

        //public void CreateCompany(Company company)
        //{
        //    if (company == null)
        //        throw new InvalidOperationException("Company was not provided");

        //    _trendUnitOfWork.Companys.Add(
        //        _mapper.Map<Entities.Company>(company));

        //    _trendUnitOfWork.Save();
        //}

        //public void DeleteCompany(int id)
        //{
        //    _trendUnitOfWork.Companys.Remove(id);
        //    _trendUnitOfWork.Save();
        //}

        //public Company GetCompany(int id)
        //{
        //    var company = _trendUnitOfWork.Companys.GetById(id);
        //    if (company == null) return null;

        //    return _mapper.Map<Company>(company);
        //}

        //public (IList<Company> records, int total, int totalDisplay) GetCompanyData(int pageIndex, 
        //    int pageSize, string searchText, string sortText)
        //{
        //    var resultData = _trendUnitOfWork.Companys.GetDynamic(
        //        string.IsNullOrWhiteSpace(searchText) ? null : x => x.TradeCode.Contains(searchText),
        //        sortText, string.Empty, pageIndex, pageSize);

        //    var resultCompany = (from data in resultData.data
        //                        select _mapper.Map<Company>(data)).ToList();

        //    return (resultCompany, resultData.total, resultData.totalDisplay);
        //}

        //public void UpdateCompany(Company company)
        //{
        //    if (company == null)
        //        throw new InvalidOperationException("Company is missing");

        //    var companyEntity = _trendUnitOfWork.Companys.GetById(company.Id);

        //    if (companyEntity != null)
        //    {
        //        _mapper.Map(company, companyEntity);
        //        _trendUnitOfWork.Save();
        //    }
        //    else
        //        throw new InvalidOperationException("Couldn't find company");
        //}
    }
}
