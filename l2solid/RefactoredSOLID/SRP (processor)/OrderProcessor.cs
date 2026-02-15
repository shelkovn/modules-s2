
using ConsoleApp1.RefactoredSOLID.SRP__processor_;
using SOLID_Fundamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.RefactoredSOLID
{
    internal class OrderProcessor
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly IInventoryService _inventoryService;
        private readonly INotificationService _notificationService;
        private readonly ILoggingService _loggingService;
        private readonly IReceiptGenerator _receiptGenerator;

        public OrderProcessor(
            IOrderRepository orderRepository,
            IPaymentProcessor paymentProcessor,
            IInventoryService inventoryService,
            INotificationService notificationService,
            ILoggingService loggingService,
            IReceiptGenerator receiptGenerator)
        {
            _orderRepository = orderRepository;
            _paymentProcessor = paymentProcessor;
            _inventoryService = inventoryService;
            _notificationService = notificationService;
            _loggingService = loggingService;
            _receiptGenerator = receiptGenerator;
        }

        public void ProcessOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);
            if (order != null)
            {
                Console.WriteLine($"Processing order {orderId}");

                if (order.TotalAmount <= 0)
                    throw new Exception("Invalid order amount");
                _paymentProcessor.ProcessPayment(order.PaymentMethod, order.TotalAmount);
                _inventoryService.UpdateInventory(order.Items);
                _notificationService.SendEmail(order.CustomerEmail, $"Order {orderId} processed");
                _loggingService.LogToDatabase($"Order {orderId} processed at {DateTime.Now}");
                _receiptGenerator.GenerateReceipt(order);
            }
                
        }
    }
}
