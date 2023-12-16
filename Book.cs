// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    public class Book : LibraryItem
    {
        private string[] authors;
        private string genre;

        public string[] Authors { get => authors; set => authors = value; }
        public string Genre { get => genre; set => genre = value; }

        public Book(string itemName, DateTime date, int quantity, string[] author, string genre) :
            base(itemName, date, quantity)
        {
            Authors = author;
            this.Genre = genre;
        }

        public override string? ToString()
        {
            // automatically list parameters when object is typed without specifying operation
            string result = $"Item type: Book \n" + base.ToString() + $"Authors: ";
            foreach (var item in Authors)
            {
                result += $"{item},";
            }
            result += $" Genre: {genre}.";

            return result;
        }
    }
}