using System;
namespace dziedziczenie_dziecko_i_rodzic
{
    public class Child : Person
    {
        public Child(string firstName, string familyName, int age, Person mother = null, Person father = null) : base(firstName, familyName, age)
        {
            this.age = checkAge(age);

            if (mother != null)
            {
                mom.modifyFirstName(mother.firstName);
                mom.modifyFamilyName(mother.familyName);
                mom.modifyAge(mother.age);
            }
            if (father != null)
            {
                dad.modifyFirstName(father.firstName);
                dad.modifyFamilyName(father.familyName);
                dad.modifyAge(father.age);
            }
        }

        public new int age { get; private set; }
        Person mom = new Person("firstName", "familyName", 40);
        Person dad = new Person("firstName", "familyName", 40);


        public new int checkAge(int toAge)
        {
            if (toAge >= 15) throw new ArgumentException("Child’s age must be less than 15!");
            return toAge;
        }

        public new int modifyAge(int newAge)
        {
            return this.age = checkAge(newAge);
        }

        public override string ToString() => string.Format("{0} {1} ({2})\nmother: {3}\nfather: {4}", firstName, familyName, age, mom.firstName == "Firstname" ? "No data" : mom.ToString(), dad.firstName == "Firstname" ? "No data" : dad.ToString());
    }


    class ProgramTests
    {
        static void Main()
        {
            /* Test: poprawne tworzenie obiektu Person, błędne imię lub nazwisko, pierwsza duża pozostałe małe */
            try
            {
                Person p = new Person(familyName: "MOlenda", firstName: "krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            /* Test: tworzenie obiektu Child brak jednego z rodziców */
            try
            {
                Person o = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 30);
                Person m = new Person(familyName: "Molenda", firstName: "Ewa", age: 29);
                Child d = new Child(familyName: "Molenda", firstName: "Anna", age: 14, father: o);
                Console.WriteLine(d);
                d = new Child(familyName: "Molenda", firstName: "Anna", age: 14, mother: m);
                Console.WriteLine(d);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            /* Test: tworzenie obiektu Child */
            try
            {
                Person o2 = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 30);
                Person m2 = new Person(familyName: "Molenda", firstName: "Ewa", age: 29);
                Child d2 = new Child(familyName: "Molenda", firstName: "Anna", age: 10, mother: m2, father: o2);
                Console.WriteLine(d2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

