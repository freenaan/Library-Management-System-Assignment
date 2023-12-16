// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    internal class UserInterface
    {
        static void Main(string[] args)
        {
            // loads items from previous save
            Program.LoadItems();

            // Main loop
            Console.WriteLine("Welcome to DataWiz, where we make data easy!");
            Console.WriteLine("\n======================================\n");
            while (true)
            {
                string userChoice = MainMenu();
                Console.Clear();

                if (userChoice == "1") ItemMenu();
                else if (userChoice == "2") MemberMenu();
                else if (userChoice == "3") ViewMenu();
                else if (userChoice == "4") BorrowMenu();
                else if (userChoice == "5") Program.SaveItems();
                else
                {
                    Program.SaveItems();
                    Console.WriteLine("Thank you for using DataWiz!");
                    Console.WriteLine("Copyright K-Labs 2023. All rights reserved.");
                    Console.WriteLine("\n=======================================\n");
                    break;
                }

                Program.SaveItems(); // autosaves after each operation
            }
        }

        static string MainMenu()
        {
            Console.WriteLine("MAIN MENU: Please select one of the following actions:");
            Console.WriteLine("1: Item menu");
            Console.WriteLine("2: Member menu");
            Console.WriteLine("3: View Menu");
            Console.WriteLine("4: Borrow Menu");
            Console.WriteLine("5: Save items");
            Console.WriteLine("Anything else - save and exit");

            return Console.ReadLine();
        }

        static void ItemMenu()
        {
            string userChoice;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("ITEM MENU: Please select one of the following actions:");
            Console.WriteLine("1: Add an entry");
            Console.WriteLine("2: Remove an entry");
            Console.WriteLine("3: Update an entry");
            Console.WriteLine("4: See all entries");
            Console.WriteLine("Anything else - save and exit");
            Console.ForegroundColor= ConsoleColor.White;

            userChoice = Console.ReadLine();
            Console.Clear();

            // calls method based on user choice
            if (userChoice == "1") LibraryItem.Add();
            else if (userChoice == "2") LibraryItem.Remove();
            else if (userChoice == "3") LibraryItem.Update();
            else if (userChoice == "4") View.Items();
            else return;
        }

        static void MemberMenu()
        {
            string userChoice;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("MEMBER MENU: How would you like to manage our lovely members:");
            Console.WriteLine("1: Add a member");
            Console.WriteLine("2: Remove a member");
            Console.WriteLine("3: Update a member");
            Console.WriteLine("4: See all members");
            Console.WriteLine("Anything else - save and exit");
            Console.ForegroundColor = ConsoleColor.White;

            userChoice = Console.ReadLine();
            Console.Clear();

            // calls method based on user choice
            if (userChoice == "1") Member.Add();
            else if (userChoice == "2") Member.Remove();
            else if (userChoice == "3") Member.Update();
            else if (userChoice == "4") View.Members();
            else return;
        }
        public static void ViewMenu()
        {
            int userResponse;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("VIEW MENU: What would you like to view?");
            Console.WriteLine("1 - List of all items");
            Console.WriteLine("2 - List of all members");
            Console.WriteLine("3 - All loan records");
            Console.WriteLine("4 - Find an item");
            Console.WriteLine("5 - Find a member");
            Console.WriteLine("Anyting else - return to main menu");
            Console.ForegroundColor = ConsoleColor.White;

            userResponse = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // calls method based on user choice
            if (userResponse == 1) View.Items();
            else if (userResponse == 2) View.Members();
            else if (userResponse == 3) View.BorrowRecords();
            else if (userResponse == 4) View.FindItem();
            else if (userResponse == 5) View.FindMember();
            else return;
        }

        public static void BorrowMenu()
        {
            int userResponse;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("BORROW MENU: How would you like to manage borrowing records?");
            Console.WriteLine("1 - Record a loan");
            Console.WriteLine("2 - Record a return");
            Console.WriteLine("3 - All loan records");
            Console.WriteLine("Anyting else - return to main menu");
            Console.ForegroundColor = ConsoleColor.White;

            userResponse = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // calls method based on user choice
            if (userResponse == 1) Borrow.Log(1);
            else if (userResponse == 2) Borrow.Log(2);
            else if (userResponse == 3) View.BorrowRecords();
            else return;
        }

        public static string AddMinorMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What would you like to add to the database?");
            Console.WriteLine("1 - Book");
            Console.WriteLine("2 - Magazine");
            Console.WriteLine("3 - DVD");
            Console.WriteLine("Anything else - return to menu");
            Console.ForegroundColor = ConsoleColor.White;


            return Console.ReadLine();
        }
    }
}
