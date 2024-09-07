using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    // Model class
    internal class Transaction
    {
        // Transaction ID to uniquely record the transaction
        public int TransactionID { get; set; }
        // Balance Due for the transaction
        public decimal BalanceDue { get; set; }
        // Cash presented by customer to satisfy the sale
        public decimal CashGiven { get; set; }
        // Change refunded to customer, if any. 0 if none.

        public decimal Change { get; set; }

        // Drawer Balance at completion of this specific transaction.
        public decimal DrawerBalance { get; set; }

    }
}
