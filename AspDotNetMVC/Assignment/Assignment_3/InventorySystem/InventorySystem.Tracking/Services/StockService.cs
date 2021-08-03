using InventorySystem.Tracking.UnitOfWorks;
using nventorySystem.Tracking.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Tracking.Services
{
    public class StockService : IStockService
    {
        private readonly ITrackingUnitOfWork _trackingUnitOfWork;
        public StockService(ITrackingUnitOfWork trackingUnitOfWork)
        {
            _trackingUnitOfWork = trackingUnitOfWork;
        }

        public void CreateStock(Stock stock)
        {
            if (!IsValidProduct(stock.ProductId))
                throw new InvalidOperationException("Invalid Product Id");
            _trackingUnitOfWork.Stocks.Add(
                new Entities.Stock()
                { 
                   ProductId = stock.ProductId,
                   Quantity = stock.Quantity
                });

            _trackingUnitOfWork.Save();
        }

        public void DeleteStock(int id)
        {
            _trackingUnitOfWork.Stocks.Remove(id);
            _trackingUnitOfWork.Save();
        }

        public (IList<Stock> records, int total, int totalDisplay) GetStocks(int pageIndex, 
            int pageSize, string searchText, string sortText)
        {
            var stockData = _trackingUnitOfWork.Stocks.GetDynamic(
                string.IsNullOrWhiteSpace(searchText)? null: x => x.ProductId.ToString().Contains(searchText),
                sortText, string.Empty, pageIndex, pageSize);

            var resultData = (from stock in stockData.data
                             select new Stock()
                             {
                                 ProductId = stock.ProductId,
                                 Quantity = stock.Quantity,
                                 Id = stock.Id
                             }).ToList();

            return (resultData, stockData.total, stockData.totalDisplay);
        }

        public Stock GetStocks(int id)
        {
            var stock = _trackingUnitOfWork.Stocks.GetById(id);

            return new Stock()
            {
                Id = stock.Id,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }

        public void UpdateStock(Stock stock)
        {
            if (stock == null)
                throw new InvalidOperationException();

            var stockEnitty= _trackingUnitOfWork.Stocks.GetById(stock.Id);

            if(stockEnitty != null)
            {
                stockEnitty.ProductId = stock.ProductId;
                stockEnitty.Quantity = stock.Quantity;

                _trackingUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException();


        }

        private bool IsValidProduct(int productId) =>
            _trackingUnitOfWork.Products.GetCount(x => x.Id == productId) > 0;
    }
}
