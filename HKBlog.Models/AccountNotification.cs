using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.Models
{
    public class AccountNotification
    {
        public string Id { get; set; } = "";
        public string UserId { get; set; } = "";
        public string PaymentId { get; set; } = "";//This will be wallet / paystack Id
        public double PreviousBalance { get; set; }
        public double TransactionalAmount { get; set; }
        public double CurrentBalance { get; set; }
        public CreditType CreditType { get; set; } = CreditType.none;
        public PaymentOption PaymentOption { get; set; } = PaymentOption.none;
        public TransactionSection TransactionSection { get; set; } = TransactionSection.none;
        public string Message { get; set; } = "";
        public DateTime Date { get; set; }
        public bool IsViewed { get; set; } = false;
    }
    public enum CreditType
    {
        none, credit, debit
    }
    public enum PaymentOption
    {
        none, cash, wallet, paystack
    }
    public enum TransactionSection
    {
        none, order, account, admin
    }
}

