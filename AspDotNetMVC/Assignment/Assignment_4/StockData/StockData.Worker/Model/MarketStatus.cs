using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData.Worker.Model
{
    public class MarketStatus
    {
        public MarketStatus()
        {

        }
        public void StatusCheck()
        {
           


            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.dse.com.bd/latest_share_price_scroll_l.php");
            //var node = document.DocumentNode.SelectNodes("/html/body/div[2]/div[1]/div/header/div[1]/span[3]/span/b").First();
            var node = document.DocumentNode.SelectNodes("/html/body/div[2]/div[1]/div/header/div[1]/span[1]").First();
            HtmlNode[] nodes = node.SelectNodes(".//b").ToArray();
            foreach (HtmlNode item in nodes)
            {
                var x = item.InnerText;
            }

        }
    }
}
