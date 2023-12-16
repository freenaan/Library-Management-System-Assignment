// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace IBL4T_Major_Assignment_2
{
    public class Program
    {
        public static ArrayList listItems = new ArrayList();
        public static ArrayList listMembers = new ArrayList();
        public static ArrayList borrowRecords = new ArrayList();

       
        // ======================================================= SAVE OPERATIONS =======================================================
        public static void SaveItems()
        {
            BinaryFormatter bf = new BinaryFormatter();

            // create seperate files for each ArrayList to save to
            using (var streamItems = File.Open($@"listItems.txt", FileMode.OpenOrCreate, FileAccess.Write))
                bf.Serialize(streamItems, listItems);

            using (var streamMembers = File.Open($@"listMembers.txt", FileMode.OpenOrCreate, FileAccess.Write))
                bf.Serialize(streamMembers, listMembers);

            using (var streamBorrow = File.Open($@"borrowRecords.txt", FileMode.OpenOrCreate, FileAccess.Write))
                bf.Serialize(streamBorrow, borrowRecords);

            // save file for idGenerators
            using (StreamWriter sw = new StreamWriter($@"idGenerators.txt"))
            {
                // Saves idGenerators into seperate lines
                sw.WriteLine(LibraryItem.IdGenerator);
                sw.WriteLine(Member.IdGenerator);
                sw.WriteLine(Borrow.IdGenerator);
            }
        }

        public static void LoadItems()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (var streamItems = File.Open($@"listItems.txt", FileMode.Open))
                    listItems = (ArrayList)bf.Deserialize(streamItems);

                using (var streamMembers = File.Open($@"listMembers.txt", FileMode.Open))
                    listMembers = (ArrayList)bf.Deserialize(streamMembers);

                using (var streamBorrow = File.Open($@"borrowRecords.txt", FileMode.Open))
                    borrowRecords = (ArrayList)bf.Deserialize(streamBorrow);

                // loads idGenerators
                using (StreamReader sw = new StreamReader($@"idGenerators.txt"))
                {
                    // Saves idGenerators into seperate lines
                    LibraryItem.IdGenerator = Convert.ToInt32(sw.ReadLine());
                    Member.IdGenerator = Convert.ToInt32(sw.ReadLine());
                    Borrow.IdGenerator = Convert.ToInt32(sw.ReadLine());
                }

                Console.WriteLine("Save file loaded!");

            }
            catch (FileNotFoundException) // if file not found
            {
                Console.WriteLine("Failed to load save files since one or more save file(s) not found!");
                return;
            }
            catch (System.Runtime.Serialization.SerializationException) // if files found but empty
            {
                Console.WriteLine("Failed to load save files since one or more save file(s) were empty!");
                return;
            }

        }

        // =================================================== HELPER METHODS ===================================================

        public static int AutoTryParse(string numToConvert)
        {
            if (numToConvert == null) return -1;
            
            if (int.TryParse(numToConvert, out int result))
            {
                return result;
            }
            return -1; // flags failure
        }

        
        public static void AutoErrorMessage(string errorMessage)
        {
            // error message with custom string as input
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return;
        }

        public static void AutoErrorMessage()
        {
            // Generic version of error message if text not specified
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error! Improper format or impossible value! Press enter to return to main menu.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return;
        }

        public static void AutoSuccessMessage()
        {
            // Sends user error message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success! Press enter to return to main menu.");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            return;
        }

        public static DateTime AutoConvertDate(string input)
        {
            // converts string into date type
            string[] dateRaw = input.Split("/");
            int year, month, day;

            try
            {
                year = AutoTryParse(dateRaw[0]);
                month = AutoTryParse(dateRaw[1]);
                day = AutoTryParse(dateRaw[2]);

                return new DateTime(year, month, day);
            }

            catch (Exception) { return DateTime.MaxValue; } // flag for invalid date
        }
    }
}