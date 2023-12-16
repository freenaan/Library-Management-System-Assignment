// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    public class Magazine : LibraryItem
    {
        private int issue;
        private string editorInChief;

        public int Issue { get => issue; set => issue = value; }
        public string EditorInChief { get => editorInChief; set => editorInChief = value; }

        public Magazine(string itemName, DateTime date, int totalQuantity, int issue, string editor) :
            base(itemName, date, totalQuantity)
        {
            Issue = issue;
            EditorInChief = editor;
        }

        public override string? ToString()
        {
            // automatically list parameters when object is typed without specifying operation
            return $"Item type: Book \n" + base.ToString() + $"Issue: {issue}, Editor in chief: {editorInChief}.";
        }
    }
}