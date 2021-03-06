﻿using System;
using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;

namespace TMD.Models.ModelMapers.ReportsMappers
{
    public static class SalesReportMapper
    {
        public static SalesReport CreateReport(this OrderItem source)
        {
            SalesReport salesReport = new SalesReport();
            
            var itemPurchasePrice = source.Product.PurchasePrice;

            salesReport.Id = source.OrderItemId;
            salesReport.Date = source.RecCreatedDate;
            salesReport.ProductCode = source.ProductId;
            salesReport.ProductName = source.Product.Name;
            salesReport.Quantity = source.Quantity;
            salesReport.SalePrice = source.SalePrice;
            salesReport.SubTotalSale = source.Quantity * source.SalePrice;
            salesReport.Discount = source.Discount;
            salesReport.TotalSale = (source.Quantity * source.SalePrice) - source.Discount;
            salesReport.PurchasePrice = itemPurchasePrice;
            salesReport.TotalCost = source.Quantity * itemPurchasePrice;
            salesReport.TotalProfit = salesReport.TotalSale - salesReport.TotalCost;
            if (salesReport.TotalProfit > 0)
            {
                salesReport.ProfitPercentage = Math.Round(((salesReport.TotalProfit / salesReport.TotalCost) * 100), 2);    
            }
            else
            {
                salesReport.ProfitPercentage = 0;
            }
            
            salesReport.OrderId = source.OrderId;

            return salesReport;
        }
    }
}
