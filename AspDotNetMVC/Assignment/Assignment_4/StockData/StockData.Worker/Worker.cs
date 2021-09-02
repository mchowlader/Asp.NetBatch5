using Autofac;
using HtmlAgilityPack;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StockData.Trend.Services;
using StockData.Worker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StockData.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly CompanyModel _companyModel;
        private readonly StockPriceModel  _stockPriceModel;

        public Worker(ILogger<Worker> logger, CompanyModel model, StockPriceModel priceModel)
        {
            _logger = logger;
            _companyModel = model;
            _stockPriceModel = priceModel;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                //_companyModel.GetCompanyData();
                _stockPriceModel.GetStockData();


                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
