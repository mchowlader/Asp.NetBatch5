using StockData.Trend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using StockData.Trend.BusinessObject;
using HtmlAgilityPack;

namespace StockData.Worker.Model
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string TradeCode { get; set; }

        private readonly ICompanyService _companyService;
        public CompanyModel()
        {
        }
        public CompanyModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        List<string> tradeCode = new List<string>();
        public void GetCompanyData()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");

            HtmlNode node = document.DocumentNode.SelectNodes("//*[@id='RightBody']/div[1]").First();

            HtmlNode[] aNodes = node.SelectNodes(".//a").ToArray();
            foreach (HtmlNode item in aNodes)
            {
                var company = new Company()
                {
                    TradeCode = item.InnerText
                };

                _companyService.DataSet(company);
            }
        }
    }
}
