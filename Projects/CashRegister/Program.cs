using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    internal class Program
    {
        //Global variables, need to be here if used in more than one method

        static bool exit;
        static decimal runningBalance;
        static decimal startingBalance;
        static List<Transaction> transactionList;
        static int transactionIdCounter; // To compute the transactionId for the transaction list.

        static void Main(string[] args)
        {
            runningBalance = 0.00m;

            Console.WriteLine("Cash Register");
            Console.WriteLine($"-------------{Environment.NewLine}"); //Environment.NewLine adds appropriate new line character depending on running operating system.

            Console.Write("Enter a starting balance from the bank: ");
            runningBalance = decimal.Parse(Console.ReadLine()); // Capture the starting balance
            startingBalance = runningBalance; // Save the initial drawer balance for the report
            transactionList = new List<Transaction>(); // Create Transaction list once for duration of program
            transactionIdCounter = 0; // Start transaction ID counter for Transaction list at 0


            //Menu

            exit = false; // Set default exit behavior to false, i.e. application continues to run

            while (!exit) // ! operator which negates or flips a boolean, changes false to true or true to false
            {
                Console.WriteLine($"{Environment.NewLine}Select an option: {Environment.NewLine}");
                Console.WriteLine("1. Make A Sale");
                Console.WriteLine("2. Display Report");
                Console.WriteLine("3. Exit");

                int choice = int.Parse(Console.ReadLine()); // Capture the choice and turn it into an integer for the switch-case block

                // Evaluate the menu choice

                switch(choice)
                {
                    case 1:
                        MakeSale();
                        break;
                    case 2:
                        DisplayReport();
                        break;
                    case 3:
                        Exit();
                        break;
                    default:
                        break;
                }
            }
            // To setup a cash register, you'll need to determine what the register needs to operate.

            // Drawer Balance, this is a decimal type.

            // You'll need a method to start your balance at the beginning of the day, this will be $50.
            // This $50 will come from the bank (You don't need to measure the bank balance, this is just to help you
            // on how to instantiate the beginning day's drawer balance.

            // You will need a method to make a sale. This method will ask for a charge and save that.
            // This method will then ask for the customer's cash, and compute the difference.
            // The difference will be the customer's change.


            // You will then need to keep track of the drawer balance and keep track of each sale.
            // So, you will need a separate method to do a sale report at the end of the day showing each transaction

            // After this report is printed, the application will close.

            // To make sales continuously, you'll need to do a menu for the sale using the switch-case block
            // This will need to be in a Menu method, and the menu will have to be continuously called until you are done
            // making sales for the day. Use the example Menu Code in the Github under Week1/MenuCode to do this.

            // ALL SALES FINAL
        }

        static void MakeSale()
        {
            /*
             1. Charge the customer their balance
             2. Customer must then present at least the balance due, if customer present more, difference will be refunded in change
             3. Depending on how the customer satisfies the balance, they may be due change
             4. In any case, the drawer balance must increase by the amount of the sale.
             5. All sales final, no refunds.
             */


            // Have placeholders for transaction counter, balance due, cash given by customer, 
            // the change, and the transaction list

            
            decimal balanceDue = 0.00m;
            decimal cashGiven = 0.00m;
            decimal change = 0.00m;
            

            // Make sure the customer is satisfying the balance, keep asking the customer for the balance due if not given
            
            // While cashGiven is less than balance due OR (||) cashGiven AND (&&) balanceDue are both 0.
            while (cashGiven < balanceDue || (cashGiven == 0.00m && balanceDue == 0.00m))
            {
                Console.Write($"{Environment.NewLine}Enter the balance due for the customer. ");
                balanceDue = decimal.Parse(Console.ReadLine());

                // Since we cannot accept more than $100 for payment, it stands to reason that we also
                // cannot charge more than $100 for any given sale.

                while (balanceDue > 100)
                {
                    // ExcessChargeException
                    Console.WriteLine($"{Environment.NewLine}Cannot charge more than $100 for an item!");
                    Console.Write($"{Environment.NewLine}Enter the balance due for the customer. ");
                    balanceDue = decimal.Parse(Console.ReadLine());
                }

                Console.Write("How much cash is the customer giving to complete the sale? ");
                cashGiven = decimal.Parse(Console.ReadLine());

                // Ensure more than 100 is not given for the sale

                while (cashGiven > 100)
                {
                    // ExcessFundsException
                    Console.WriteLine($"Cashier cannot accept more than $100!{Environment.NewLine}");
                    Console.Write("How much cash is the customer giving to complete the sale? ");
                    cashGiven = decimal.Parse(Console.ReadLine());
                }

                if (cashGiven < balanceDue)
                {
                    //InsufficientFundsException
                    Console.WriteLine($"Insufficient funds paid! {Environment.NewLine}");
                }

                // If the balance is satisfied, then compute any change, if any
                else
                {
                    change = cashGiven - balanceDue;

                    // If there is change, then print to screen change due to customer.
                    if (change > 0)
                    {
                        Console.WriteLine($"{Environment.NewLine}Change due to customer: ${change}");
                    }
                }
            }

            // Add to the drawer balance the amount of the sale and add the transaction to the list.
            runningBalance += balanceDue;

            // Add the transaction, create the Transaction inside the Add method
            // so that the Transaction is created and added at the same time.

            //To learn more about Lists in C#, see: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0

            transactionList.Add
            (
                new Transaction
                {
                    TransactionID = ++transactionIdCounter, // Increment counter by 1 and set to TransactionID
                    BalanceDue = balanceDue,
                    CashGiven = cashGiven,
                    Change = change,
                    DrawerBalance = runningBalance
                }
            );
        }

        static void DisplayReport()
        {
            // Print the initial drawer balance
            Console.WriteLine($"{Environment.NewLine}Starting Drawer Balance: ${startingBalance}");

            // Foreach loop through the transaction list to list all the transaction details

            foreach (Transaction transaction in transactionList)
            {
                Console.WriteLine($"Transaction {transaction.TransactionID}, Balance Due: ${transaction.BalanceDue}, Cash Paid By Customer: ${transaction.CashGiven}, Change: ${transaction.Change}, Ending Drawer Balance: ${transaction.DrawerBalance}");
            }
        }

        static void Exit()
        {
            exit = true; // Set exit behavior to true to terminate the application at the user's request.
            Console.WriteLine($"{Environment.NewLine}Good Bye! Press any key to exit.");
            Console.ReadKey(); // Read any key from the keyboard
        }
    }
}
