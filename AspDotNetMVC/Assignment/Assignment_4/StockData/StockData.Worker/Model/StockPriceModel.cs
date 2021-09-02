using HtmlAgilityPack;
using StockData.Trend.BusinessObject;
using StockData.Trend.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockData.Worker.Model
{
    public class StockPriceModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public double LastTradingPrice { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double ClosePrice { get; set; }
        public double YesterdayClosePrice { get; set; }
        public double Change { get; set; }
        public int Trade { get; set; }
        public double Value { get; set; }
        public double Volume { get; set; }

        private readonly IStockPriceService  _stockPriceService;
        public StockPriceModel()
        {
        }
        public StockPriceModel(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

       
        public void GetStockPrice()
        {
            var StockPriceList = new ArrayList();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");

            HtmlNode node = document.DocumentNode.SelectNodes("//*[@id='RightBody']/div[1]").First();

            HtmlNode[] aNodes = node.SelectNodes(".//tr").ToArray();

            foreach (HtmlNode item in aNodes)
            {
                var innerData = item.InnerText;

                var value = innerData.Replace(" <.*?> ", " ");

                StockPriceList.Add(value);
            }

            //_stockPriceService.GetCompanyId
        }

    }
}
