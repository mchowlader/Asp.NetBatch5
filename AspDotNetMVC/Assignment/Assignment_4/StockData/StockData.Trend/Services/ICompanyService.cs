using StockData.Trend.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Trend.Services
{
    public interface ICompanyService
    {
        //void CreateCompany(Company company);
        //(IList<Company> records, int total, int totalDisplay) GetCompanyData(int pageIndex, int pageSize, 
        //    string searchText, string sortText);
        //Company GetCompany(int id);
        //void UpdateCompany(Company company);
        //void DeleteCompany(int id);
        void DataSet(Company company);
    }
}
