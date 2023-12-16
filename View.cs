// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    public static class View
    {
        public static void Items()
        {
            int entryTracker = 1;

            Console.WriteLine("ALL ITEMS:\n");

            // displays all items in listItems list
            foreach (LibraryItem item in Program.listItems)
            {
                if (item.Deleted == false)
                {
                    Console.WriteLine($"{entryTracker}) \n{item}");
                    Console.WriteLine("\n----------------------\n");
                    entryTracker++; // iterates entryTracker
                }
            }

            Console.WriteLine("===========================================================\n" +
                "Please press enter to return.");
            Console.ReadLine();
            Console.Clear();

        }

        public static void Members()
        {
            Console.WriteLine("ALL MEMBERS:\n");

            // displays all members in listMembers list
            for (int i = 0; i < Program.listMembers.Count; i++)
            {
                Console.WriteLine($"{i + 1}) \n{Program.listMembers[i]}");
                Console.WriteLine("----------------------\n");
            }

            Console.WriteLine("\n===========================================================\n" +
                "Please press enter to return.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void BorrowRecords()
        {
            int entryTracker = 1;

            Console.WriteLine("CURRENT LOANS:\n");

            // displays all unreturned items
            foreach (Borrow loan in Program.borrowRecords)
            {
                if (loan.ItemReturned == false)
                {
                    Console.WriteLine($"{entryTracker}) \n{loan}");
                    Console.WriteLine("\n-------------------------\n");
                    entryTracker++;
                }
            }

            entryTracker = 1; // resets entryTracker
            Console.WriteLine("\n===========================================================\n");
            Console.WriteLine("PPREVIOUS LOANS:\n");

            // displays all returned items
            foreach (Borrow loan in Program.borrowRecords)
            {
                if (loan.ItemReturned == true)
                {
                    Console.WriteLine($"Entry {entryTracker}:{loan}");
                    Console.WriteLine("\n-------------------------\n");
                    entryTracker++;
                }
            }

            Console.WriteLine("\n===========================================================\n" +
                "Please press enter to return.");
            Console.ReadLine();
            Console.Clear();
        }

        public static void FindItem()
        {
            string itemName;
            bool found = false;

            Console.WriteLine("What is the name of the item you want to find?");
            itemName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Here's what we found:");
            // finds item(s) that match
            foreach (LibraryItem item in Program.listItems)
            {
                if (item.ItemName == itemName)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("\n==============================\n");
                    found = true;
                }
            }

            // error message if nothing found
            if (found == false)
            {
                Console.Clear();
                Program.AutoErrorMessage("Error! Item not found! Press enter to return to main menu.");
            }
            else
            {
                Console.WriteLine("Press enter to return to main menu.");
                Console.ReadLine(); // allows user to read entries found}
            }
        }

        public static void FindMember()
        {
            string memberName;
            bool found = false;

            Console.WriteLine("What is the name of the member you want to find?");
            memberName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Here's what we found:");
            // finds item(s) that match
            foreach (Member member in Program.listMembers)
            {
                if (member.Name == memberName)
                {
                    Console.WriteLine(member);
                    Console.WriteLine("\n==============================\n");
                    found = true;
                }
            }

            // error message if nothing found
            if (found == false)
            {
                Console.Clear();
                Program.AutoErrorMessage("Error! Member not found! Press enter to return to main menu.");
            }

            else
            {
                Console.WriteLine("Press enter to return to main menu.");
                Console.ReadLine(); // allows user to read entries found}
            }
        }

    }
}