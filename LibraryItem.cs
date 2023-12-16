// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    public class LibraryItem
    {
        private string itemName;
        private DateTime publishDate;
        private int totalQuantity;
        private int quantityBorrowed;
        private int itemID;
        private bool deleted = false;
        private static int idGenerator = 1; // static so each item has a unique ID

        public string ItemName { get => itemName; set => itemName = value; }
        public DateTime PublishDate { get => publishDate; set => publishDate = value; }
        public int TotalQuantity { get => totalQuantity; set => totalQuantity = value; }
        public int QuantityBorrowed { get => quantityBorrowed; set => quantityBorrowed = value; }
        public int ItemID { get => itemID; } // ID cannot be changed once assigned
        public bool Deleted { get => deleted; set => deleted = value; }
        public static int IdGenerator { get => idGenerator; set => idGenerator = value; }

        public LibraryItem(string itemName, DateTime date, int quantity)
        {
            ItemName = itemName;
            PublishDate = date;
            TotalQuantity = quantity;
            itemID = idGenerator;
            idGenerator++; // incrememnts ID generator
        }

        public static void Add()
        {
            string userChoice;
            string itemName;
            int itemQuantity;
            DateTime publishDate = new DateTime();

            userChoice = UserInterface.AddMinorMenu();
            Console.Clear();

            if (userChoice != "1" && userChoice != "2" && userChoice != "3") { return; } // returns user to menu

            Console.WriteLine("What is the name of this item?");
            itemName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("How many of this item do you have?");
            itemQuantity = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            if (itemQuantity < 0) { Program.AutoErrorMessage(); return; }

            // adds date
            Console.WriteLine("What day was this published (yyyy/mm/dd)?");
            publishDate = Program.AutoConvertDate(Console.ReadLine());
            Console.Clear();

            // input validation
            if (publishDate == DateTime.MaxValue)
            {
                Program.AutoErrorMessage("Error! Impossible or future date! Press enter to return.");
                return;
            }

            // add a book
            if (userChoice == "1")
            {
                string[] authors;
                int numAuthors;
                string genre;

                Console.WriteLine("How many people authored this book?");
                numAuthors = Program.AutoTryParse(Console.ReadLine());
                Console.Clear();

                authors = new string[numAuthors]; // initializes authors array

                // input validation
                if (numAuthors <= 0) { Program.AutoErrorMessage(); return; }

                for (int i = 0; i < numAuthors; i++)
                {
                    Console.WriteLine($"What is the name of author {i + 1}?");
                    authors[i] = Console.ReadLine();
                    Console.Clear();
                }

                Console.WriteLine("What genre is this book?");
                genre = Console.ReadLine();
                Console.Clear();

                // use dummy variable to display ID
                Book newBook = new Book(itemName, publishDate, itemQuantity, authors, genre);
                Program.listItems.Add(newBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName}'s ID is {newBook.itemID}.");
                Program.AutoSuccessMessage();
            }

            // add a magazine
            else if (userChoice == "2")
            {
                int issue;
                string editor;
                Console.WriteLine("What issue is this magazine?");
                issue = Program.AutoTryParse(Console.ReadLine());
                Console.Clear();

                if (issue <= 0) { Program.AutoErrorMessage(); return; }

                Console.WriteLine("Who is the editor-in-chief of this magazine?");
                editor = Console.ReadLine();
                Console.Clear();

                // use dummy variable to display ID
                Magazine newMagazine = new Magazine(itemName, publishDate, itemQuantity, issue, editor);
                Program.listItems.Add(newMagazine);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName}'s ID is {newMagazine.itemID}.");
                Program.AutoSuccessMessage();
            }

            // add a DVD
            else
            {
                string publisher;
                string[] resolutionTemp;
                int[] resolution = new int[2];

                Console.WriteLine("Who is the publisher of this dvd?");
                publisher = Console.ReadLine();
                Console.Clear();

                Console.WriteLine("What is the resolution of this DVD? (1280x720, 1920x1080, 2560x1440, etc.)");
                resolutionTemp = (Console.ReadLine()).Split('x');
                Console.Clear();

                // input validation
                if (resolutionTemp.Length != 2)
                {
                    Program.AutoErrorMessage("Error! Invalid resolution! Press enter to return to main menu.");
                    return;
                }

                if (Program.AutoTryParse(resolutionTemp[0]) <= 0 || Program.AutoTryParse(resolutionTemp[1]) <= 0)
                {
                    Program.AutoErrorMessage();
                    return;
                }

                // converts to int after input validation
                resolution[0] = Convert.ToInt32(resolutionTemp[0]);
                resolution[1] = Convert.ToInt32(resolutionTemp[1]);

                // use Dummy variable to easily display ID
                Dvd newDvd = new Dvd(itemName, publishDate, itemQuantity, publisher, resolution);
                Program.listItems.Add(newDvd);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{itemName}'s ID is {newDvd.itemID}.");
                Program.AutoSuccessMessage();
            }
        }

        public static void Remove()
        {
            int idToRemove;
            bool itemFound = false;

            Console.WriteLine($"What is the ID of the item you would like to remove?");
            idToRemove = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // input validation
            if (idToRemove <= 0) { Program.AutoErrorMessage(); return; }

            foreach (LibraryItem item in Program.listItems)
            {
                if (item.ItemID == idToRemove)
                {
                    item.Deleted = true;
                    Program.listItems[Program.listItems.IndexOf(item)] = item;
                    itemFound = true;
                    break;
                }
            }

            if (itemFound == true)
            {
                Console.WriteLine($"Success! item still exists in database but has been marked as deleted. Press enter to return.");
                Console.ReadLine();
                Console.Clear();
            }

            else Program.AutoErrorMessage("Error! Item not found! Press enter to return to main menu");
        }

        public static void Update()
        {
            int idToFind;
            int itemIndex = -1;
            LibraryItem itemToEdit = null;

            Console.WriteLine("What is the ID of the item you want to find?");
            idToFind = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            if (idToFind <= 0) { Program.AutoErrorMessage(); return; } // input validation

            // finds item
            foreach (LibraryItem item in Program.listItems)
            {
                if (item.ItemID == idToFind)
                {
                    itemToEdit = item;
                    itemIndex = Program.listItems.IndexOf(item);
                    break;
                }

                // if itemID hasn't been found and this is the last entry
                if (Program.listItems.IndexOf(item) == Program.listItems.Count - 1)
                {
                    Program.AutoErrorMessage("Error! Item not found! Press enter to return to main menu.");
                    return;
                }
            }

            Console.WriteLine($"Item is found! Id is {itemToEdit.itemID}, name is {itemToEdit.itemName}.");
            Console.WriteLine("** If you don't wish to change a parameter, leave it blank. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();

            // not all parameters need to be changed
            // eg. name of a book will always remain the same

            // only updates if format is correct
            Console.WriteLine("How many of this item do you have now?");
            int itemQuantity = Program.AutoTryParse(Console.ReadLine());
            if (itemQuantity >= 0) itemToEdit.TotalQuantity = itemQuantity;
            Console.Clear();

            // checks if more books are checked out than quantity
            if (itemQuantity < itemToEdit.QuantityBorrowed)
            {
                Program.AutoErrorMessage("Value left unchanged due to no entry, invalid number/format, " +
                    "or out of stock. Press enter to return to main menu.");
                return;
            }

            // replace old entry with new one
            Program.listItems[itemIndex] = itemToEdit;
            Program.AutoSuccessMessage();
        }

        public override string? ToString()
        {
            // automatically list parameters when object is typed without specifying operation
            return $"ITEM ID: {itemID}, Item name: {itemName}, Publish date: {publishDate}, Quantity: {totalQuantity}, "; ;
        }
    }
}