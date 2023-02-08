using System;
using System.Linq;

namespace dziedziczenie_dziecko_i_rodzic
{
    public class Person
    {
        public Person(string firstName, string familyName, int age)
        {

            this.firstName = checkName(firstName);
            this.familyName = checkName(familyName);
            this.age = checkAge(age);           
        }

        public string firstName { get; private set; }
        public string familyName { get; private set; }
        public int age { get; private set; }

        public string checkName(string toCheck)
        {
            toCheck.Trim();
            toCheck = String.Concat(toCheck.Where(c => !Char.IsWhiteSpace(c)));
            char[] N1 = toCheck.ToCharArray();
            foreach (var item in N1)
            {
                if (char.IsDigit(item) || !char.IsLetterOrDigit(item)) throw new ArgumentException("Wrong name!");
            }
            toCheck = char.ToUpper(toCheck[0]) + toCheck.Substring(1).ToLower();
            return toCheck;
        }
        public int checkAge(int toAge)
        {
            if (toAge <= 0) throw new ArgumentException("Age must be positive!");
            return toAge;
        }

        public string modifyFirstName(string newFirstName)
        {
            return firstName = checkName(newFirstName);
        }

        public string modifyFamilyName(string newFamilyName)
        {
            return familyName = checkName(newFamilyName);
        }

        public int modifyAge(int newAge)
        {
            return age = checkAge(newAge);
        }

        public override string ToString() => string.Format("{0} {1} ({2})", firstName, familyName, age);  
    } 
}

