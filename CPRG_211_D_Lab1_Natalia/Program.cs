using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CPRG_211_D_Lab1_Natalia
{
    internal class Program
    {
        class Person 
        {
            public int personId;
            public string firstName;
            public string lastName;
            public string favoriteColor;
            public int age;
            public bool isWorking;

            public Person(int personId, string firstName, string lastName, string favoriteColor, int age, bool isWorking)
            {
                this.personId = personId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.favoriteColor = favoriteColor;
                this.age = age;
                this.isWorking = isWorking;
            }

            public void DisplayPersonInfo()
            {
                Console.WriteLine($"{personId}: {firstName} {lastName}'s favorite colour is {favoriteColor}.");
            }

            public void ChangeFavoriteColour()
            {
                favoriteColor = "White";
            }

            public void GetAgeInTenYears()
            {
                Console.WriteLine($"In 10 years, {firstName} will be {age + 10} years old.");
            }

            public override string ToString()
            {
                return $"PersonId: {personId} \nFirstName: {firstName}\nLastName: {lastName}\nFavoriteColour: {favoriteColor}\nAge: {age}\nIsWorking: {isWorking}";
            }

        }

        class Relationship
        {
            public List<string> relationshipType = new List<string>{"sister","brother","mother","father"};
            private Person p1;
            private Person p2;
            private string relationship;

            public Relationship(Person p1, Person p2, string relationship) 
            {
                this.p1 = p1;
                this.p2 = p2;
                this.relationship = relationship;

            }

            public void ShowRelationship()
            {
                if (relationshipType.Contains(relationship.ToLower()) == true)
                { 
                    switch(relationship.ToLower())
                    {
                        case "sister":
							Console.WriteLine($"Relationship between {p1.firstName} and {p2.firstName} is: Sisterhood");
                            break;
                        case "brother":
							Console.WriteLine($"Relationship between {p1.firstName} and {p2.firstName} is: Brotherhood");
                            break;
                        case "mother":
							Console.WriteLine($"Relationship between {p1.firstName} and {p2.firstName} is: Motherhood"); 
                            break;
                        case "father":
							Console.WriteLine($"Relationship between {p1.firstName} and {p2.firstName} is: Fatherhood"); 
                            break;
					}
                } else
                {
                    Console.WriteLine("The relationship type is invalid");
                }  
            }
        }

        static void Main(string[] args)
        {
            Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
            Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
            Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
            Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

            person2.DisplayPersonInfo();
            Console.WriteLine(person3.ToString());
            person1.ChangeFavoriteColour();
            person1.DisplayPersonInfo();
            person4.GetAgeInTenYears();

            Relationship relationship1 = new Relationship(person2, person4, "sister");
            Relationship relationship2 = new Relationship(person1, person3, "brother");
            relationship1.ShowRelationship();
            relationship2.ShowRelationship();

            List<Person> people = new List<Person> {person1, person2, person3, person4};
            double avgAge = 0;
            foreach (var person in people)
            {
                avgAge += person.age;
            }
            Console.WriteLine($"Average age is {avgAge /= people.Count}");

            int lowestAge = 99;
            string youngestName = "placeholder"; 
            foreach (var person in people)
            {
                if (person.age < lowestAge)
                {
                    lowestAge = person.age;
                    youngestName = person.firstName;
                }
            }
            Console.WriteLine($"The youngest person is: {youngestName}");

			int highestAge = 0;
			string oldestName = "placeholder";
			foreach (var person in people)
			{
				if (person.age > highestAge)
				{
					highestAge = person.age;
					oldestName = person.firstName;
				}
			}
			Console.WriteLine($"The oldest person is: {oldestName}");

			foreach (var person in people)
            {
                if (person.firstName.StartsWith("M") == true)
                {
                    Console.WriteLine(person.ToString());
                }
            }

			foreach (var person in people)
			{
				if (person.favoriteColor == "Blue")
				{
					Console.WriteLine(person.ToString());
				}
			}
		}
    }
}
