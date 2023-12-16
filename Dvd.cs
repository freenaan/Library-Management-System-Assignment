// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    public class Dvd : LibraryItem
    {
        private string publisher;
        private int[] resolution = new int[2];

        public string Publisher { get => publisher; set => publisher = value; }
        public int[] Resolution { get => resolution; set => resolution = value; }

        // complex constructor
        public Dvd(string itemName, DateTime date, int quantity, string publisher, int[] resolution) :
            base(itemName, date, quantity)
        {
            Publisher = publisher;
            Resolution = resolution;
        }

        public override string? ToString()
        {
            // automatically list parameters when object is typed without specifying operation
            return $"Item type: Magazine \n" + base.ToString() + $"Publisher: {publisher}, Resolution: {resolution[0]}x{resolution[1]}.";
        }
    }
}
