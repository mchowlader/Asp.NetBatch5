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
        public string LastTradingPrice { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string ClosePrice { get; set; }
        public string YesterdayClosePrice { get; set; }
        public string Change { get; set; }
        public string Trade { get; set; }
        public string Value { get; set; }
        public string Volume { get; set; }
        public string TradeCode { get; set; }

        private readonly IStockPriceService  _stockPriceService;
        public StockPriceModel()
        {

        }
        public StockPriceModel(IStockPriceService stockPriceService)
        {
            _stockPriceService = stockPriceService;
        }

        public void GetStockData()
        {
            var html = @"https://www.dse.com.bd/latest_share_price_scroll_l.php";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectNodes("//*[@id='RightBody']/div[1]").First();
            HtmlNode[] nodes = node.SelectNodes(".//td").ToArray();
            var list = new string[nodes.Length];
            var i = 0;
            var a = 0;

            foreach (HtmlNode item in nodes)
            {
                var data = item.InnerText;
                var itemValue = System.Text.RegularExpressions.Regex.Replace(data, "(<[a|A][^>]*>|[<>]|['\t']|['\n']|['\r'])", "");
                list[a] = Convert.ToString(itemValue);

                a++;
            }

            foreach (HtmlNode item in nodes)
            {
                TradeCode = list[i = i + 1];
                LastTradingPrice = list[i = i + 1];
                High = list[i = i + 1];
                Low = list[i = i + 1];
                ClosePrice = list[i = i + 1];
                YesterdayClosePrice = list[i = i + 1];
                Change = list[i = i + 1];
                Trade = list[i = i + 1];
                Value = list[i = i + 1];
                Volume = list[i = i + 1];
                i = i + 1;

                var stockBusiness = new StockPrice()
                {
                    TradeCode = TradeCode,
                    LastTradingPrice = LastTradingPrice,
                    High = High,
                    Low = Low,
                    ClosePrice = ClosePrice,
                    YesterdayClosePrice = YesterdayClosePrice,
                    Change = Change,
                    Trade = Trade,
                    Value = Value,
                    Volume = Volume,
                };

                _stockPriceService.SetStockData(stockBusiness);
            }
        }

    }
}
