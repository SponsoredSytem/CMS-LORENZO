﻿using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IOrderItemService
    {
        IEnumerable<OrderItem> GetOrderItems(long orderId);

        OrderItem GetOrderItemById(long orderItemId);
        
        IEnumerable<OrderItem> GetAllOrderItems();

        long AddService(OrderItem order);
        bool UpdateService(OrderItem order);
        void AddUpdateService(Order order);
    }
}
