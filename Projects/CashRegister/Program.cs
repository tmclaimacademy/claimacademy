using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // To setup a cash register, you'll need to determine what the register needs to operate.

            // Drawer Balance, this is a decimal type.

            // You'll need a method to start your balance at the beginning of the day, this will be $50.
            // This $50 will come from the bank (You don't need to measure the bank balance, this is just to help you
            // on how to instantiate the beginning day's drawer balance.

            // You will need a method to make a sale. This method will ask for a charge and save that.
            // This method will then ask for the customer's cash, and compute the difference.
            // The difference will be the customer's change.

            // You will also need a boolean for if the customer presents a bill larger than $100 and you need to be able to
            // reject that cash if that boolean is true.

            // You will then need to keep track of the drawer balance and keep track of each sale.
            // So, you will need a separate method to do a sale report at the end of the day showing each transaction

            // After this report is printed, the application will close.

            // To make sales continuously, you'll need to do a menu for the sale using the switch-case block
            // This will need to be in a Menu method, and the menu will have to be continuously called until you are done
            // making sales for the day.
        }
    }
}
