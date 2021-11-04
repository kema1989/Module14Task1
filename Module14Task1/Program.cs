using System;
using System.Collections.Generic;
using System.Linq;

namespace Module14Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var newPhoneBook = phoneBook.OrderBy(c => c.Name).ThenBy(c => c.LastName);

            while (true)
            {
                Console.WriteLine("---------------");
                Console.Write("Введите номер страницы: ");
                var input = Console.ReadKey().KeyChar;

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                Console.WriteLine();
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine("Страницы не существует...");
                }
                else
                {
                    var contacts = newPhoneBook.Skip((pageNumber - 1) * 2).Take(2);

                    foreach (var contact in contacts)
                        Console.WriteLine($"{contact.Name} {contact.LastName}, {contact.PhoneNumber}");
                }
            }
        }
    }
    public class Contact
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}
