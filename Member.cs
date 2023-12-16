// Author: Farhaan Khan
// Date: Fri, Dec 1, 2023
// Professor: Hesam Akbari
// Course: IBL4T
// College: George Brown College

namespace IBL4T_Major_Assignment_2
{
    [Serializable]
    public class Member
    {
        private string name;
        private DateTime dateOfBirth;
        private string gender;
        private string email;
        private int userId;
        private bool deleted;
        static int idGenerator = 1;

        public string Name { get => name; set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public int UserId { get => userId; } // userID should not be changed once assigned
        public bool Deleted { get => deleted; set => deleted = value; }
        public static int IdGenerator { get => idGenerator; set => idGenerator = value; }

        public Member(string name, DateTime dateOfBirth, string gender, string email)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            userId = idGenerator;
            idGenerator++;
        }

        public Member()
        {
            userId = idGenerator;
            idGenerator++;
        }

        public static void Add()
        {

            Member newMember;
            string name;
            DateTime dob;
            string gender;
            string email;

            Console.WriteLine("What is the member's name?");
            name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"When was {name} born? (yyyy/mm/dd)");
            dob = Program.AutoConvertDate(Console.ReadLine());
            Console.Clear();

            // input validation
            if (dob == DateTime.MaxValue) { Program.AutoErrorMessage(); return; }

            Console.WriteLine($"What is {name}'s gender?");
            gender = Console.ReadLine();
            Console.Clear();

            Console.WriteLine($"What is {name}'s email address?");
            email = Console.ReadLine();
            Console.Clear();

            // use dummy variable to easily display userID
            newMember = new Member(name, dob, gender, email);
            Program.listMembers.Add(newMember);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{name}'s user ID is {newMember.UserId}");
            Program.AutoSuccessMessage();
        }

        public static void Remove()
        {
            int idToRemove;
            bool itemFound = false;

            Console.WriteLine($"What is the ID of the member you would like to remove?");
            idToRemove = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            // input validation
            if (idToRemove <= 0) { Program.AutoErrorMessage(); return; }

            foreach (Member member in Program.listMembers)
            {
                if (member.UserId == idToRemove)
                {
                    member.Deleted = true;
                    Program.listMembers[Program.listMembers.IndexOf(member)] = member;
                    itemFound = true;
                    break;
                }
            }

            if (itemFound == true)
            {
                Console.WriteLine($"Success! Member still exists in database but has been marked as deleted. Press enter to return.");
                Console.ReadLine();
                Console.Clear();
            }

            else Program.AutoErrorMessage("Error! Member not found! Press enter to return to main menu");
        }

        public static void Update()
        {
            int idToFind;
            int memberIndex = -1;
            Member memberToEdit = null;

            Console.WriteLine("What is the ID of the member you want to find?");
            idToFind = Program.AutoTryParse(Console.ReadLine());
            Console.Clear();

            if (idToFind <= 0) return; // input validatoin

            // finds item
            foreach (Member member in Program.listMembers)
            {
                if (member.UserId == idToFind)
                {
                    memberToEdit = member;
                    memberIndex = Program.listMembers.IndexOf(member);
                    break;
                }

                // if itemID hasn't been found and this is the last entry
                if (Program.listMembers.IndexOf(member) == Program.listMembers.Count - 1)
                {
                    Program.AutoErrorMessage("Error! Member not found! Press enter to return to main menu.");
                    return;
                }
            }

            Console.WriteLine($"Member found! Id is {memberToEdit.UserId}, name is {memberToEdit.Name}.");
            Console.WriteLine("** If you don't wish to change a parameter, leave it blank. Press enter to continue.");
            Console.ReadLine();
            Console.Clear();

            // date of birth never changes, so no need to include it

            // only updates if not left empty and format is correct
            Console.WriteLine("What is the member's new name?");
            string name = Console.ReadLine();
            if (name != null) memberToEdit.Name = name;
            Console.Clear();

            Console.WriteLine($"When was {name} born?");
            DateTime dob = Program.AutoConvertDate(Console.ReadLine());
            if (dob != DateTime.MaxValue) memberToEdit.DateOfBirth = dob;
            Console.Clear();

            Console.WriteLine($"What is {name}'s new gender?");
            string gender = Console.ReadLine();
            if (name != null) memberToEdit.Gender = gender;
            Console.Clear();

            Console.WriteLine($"What is {name}'s new email address?");
            string email = Console.ReadLine();
            if (name != null) memberToEdit.Email = email;
            Console.Clear();

            // replace old entry with new one
            Program.listMembers[memberIndex] = memberToEdit;
            Program.AutoSuccessMessage();
        }

        public override string? ToString()
        {
            return $"{Name}. UserID: {userId},  Date of Birth: {dateOfBirth},  Gender: {gender},  Email: {email}.";
        }
    }
}
