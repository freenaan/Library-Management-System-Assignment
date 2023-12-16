// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    internal class Borrow
    {
        private Member borrower;
        private LibraryItem itemBorrowed;
        private DateTime dateBorrowed;
        private DateTime dateReturned;
        private bool itemReturned;
        private int borrowId;
        static int idGenerator = 1;

        public Member Borrower { get => borrower; set => borrower = value; }
        public LibraryItem ItemBorrowed { get => itemBorrowed; set => itemBorrowed = value; }
        public DateTime DateBorrowed { get => dateBorrowed; set => dateBorrowed = value; }
        public DateTime DateReturned { get => dateReturned; set => dateReturned = value; }
        public bool ItemReturned { get => itemReturned; set => itemReturned = value; }
        public int BorrowId { get => borrowId; set => borrowId = value; }
        public static int IdGenerator { get => idGenerator; set => idGenerator = value; }

        public Borrow(Member borrower, LibraryItem itemBorrowed)
        {
            Borrower = borrower;
            ItemBorrowed = itemBorrowed;
            ItemReturned = false;
            BorrowId = IdGenerator;
            IdGenerator++;

            // automize date borrowed
            DateBorrowed = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public Borrow()
        {
            BorrowId = IdGenerator;
            IdGenerator++;

            // automize date borrowed
            DateBorrowed = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public static void Log(int caseN)
        {
            LibraryItem itemBorrowed = null;
            Member borrower = null;
            int itemBorrowedID;
            int borrowerID;

            Console.WriteLine("What is the ID of the item?");
            itemBorrowedID = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // input validation
            if (itemBorrowedID <= 0) { Program.AutoErrorMessage(); return; }

            // locates the item they want to borrow
            foreach (LibraryItem item in Program.listItems)
            {
                if (item.ItemID == itemBorrowedID)
                {
                    itemBorrowed = item;
                    break;
                }
            }

            // if item was not found
            if (itemBorrowed == null)
            {
                Program.AutoErrorMessage("Error! Item not found! Press enter to return to main menu.");
                return;
            }

            // checks if the item is in stock (no need if returning item)
            if (caseN == 1)
            {
                if (itemBorrowed.TotalQuantity <= itemBorrowed.QuantityBorrowed || itemBorrowed.Deleted)
                {
                    Program.AutoErrorMessage("Error! Item not in stock! Press enter to return to the main menu.");
                    return;
                }
            }

            Console.WriteLine("What is the ID of the person?");
            borrowerID = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // input validation
            if (borrowerID <= 0) { Program.AutoErrorMessage(); return; }

            // locates the borrower and adds them to the borrow list
            foreach (Member member in Program.listMembers)
            {
                if (member.UserId == borrowerID) borrower = member;
            }

            // if borrower was not found
            if (itemBorrowed == null)
            {
                Program.AutoErrorMessage("Error! Item not found! Press enter to return to main menu.");
                return;
            }

            // checks if user is still a member
            if (borrower.Deleted == true)
            {
                Program.AutoErrorMessage("Error! User is no longer a member! Press enter to return.");
                return;
            }

            // if borrowing item
            if (caseN == 1)
            {
                // add record if both inputs are logical
                Program.borrowRecords.Add(new Borrow(borrower, itemBorrowed));

                // update QuantityBorrowed on original item in ArrayList
                itemBorrowed.QuantityBorrowed += 1;
                int itemIndex = Program.listItems.IndexOf(itemBorrowed);
                Program.listItems[itemIndex] = itemBorrowed;

                Program.AutoSuccessMessage();
            }

            // if returning item
            else
            {
                Borrow newBorrowRecord = null;

                // iterates through each record to find record referenced
                foreach (Borrow borrow in Program.borrowRecords)
                {
                    if (borrow.Borrower == borrower &&
                        borrow.ItemBorrowed == itemBorrowed &&
                        !borrow.ItemReturned)
                    {
                        // creates a temporary record to replace the current one
                        newBorrowRecord = borrow;
                        newBorrowRecord.ItemReturned = true;
                        itemBorrowed.QuantityBorrowed -= 1;

                        // replaces the old record
                        int borrowIndex = Program.borrowRecords.IndexOf(borrow);
                        int itemIndex = Program.listItems.IndexOf(itemBorrowed);
                        Program.borrowRecords[borrowIndex] = newBorrowRecord;
                        Program.listItems[itemIndex] = itemBorrowed;

                        Program.AutoSuccessMessage();
                        return;
                    }
                }
            }
        }

        public override string? ToString()
        {
            // automatically list parameters when object is typed without specifying operation
            if (ItemReturned == false)
            {
                string result =
                    $"{ItemBorrowed}\n" +
                    $"Borrower:\n" +
                    $"{Borrower}\n" +
                    $"Date Borrowed:{DateBorrowed.Year}/{DateBorrowed.Month}/{DateBorrowed.Day}" +
                    $"Borrow ID: {BorrowId}.";

                return result;
            }

            else // if (ItemReturned == true)
            {
                string result =
                    $"{ItemBorrowed}\n" +
                    $"Borrower:\n" +
                    $"{Borrower}\n" +
                    $"Date Borrowed: {DateBorrowed.Year}/{DateBorrowed.Month}/{DateBorrowed.Day}\n" +
                    $"Date Returned: {DateReturned.Year}/{DateReturned.Month}/{DateReturned.Day}" +
                    $"Borrow ID: {BorrowId}.";

                return result;
            }
        }
    }
}