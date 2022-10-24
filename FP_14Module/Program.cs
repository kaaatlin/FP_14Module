// Доработайте вашу телефонную книгу из задания 14.2.10 предыдущего юнита так,
// чтобы контакты телефонной книги были отсортированы сперва по имени, а затем по фамилии.

namespace FP_14Module
{
    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
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
    internal class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            // бесконечный цикл, ожидающий ввод с консоли
            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
                Console.Clear();  //  очистка консоли от ввода


                if (!Char.IsDigit(keyChar))
                {
                    Console.WriteLine("Ошибка ввода, введите число");
                }
                else
                {
                    //  переменная для хранения запроса в зависимости от введенного с консоли числа
                    IEnumerable<Contact> page = null;

                    //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
                    switch (keyChar)
                    {
                        case ('1'):
                            page = phoneBook.Take(2);
                            break;
                        case ('2'):
                            page = phoneBook.Skip(2).Take(2);
                            break;
                        case ('3'):
                            page = phoneBook.Skip(4).Take(2);
                            break;
                    }

                    //   проверим, что ввели существующий номер страницы
                    if (page == null)
                    {
                        Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                        continue;
                    }

                    // вывод результата на консоль
                    foreach (var contact in page.OrderBy(c => c.Name).ThenBy(c => c.LastName))
                        Console.WriteLine($"Имя: {contact.Name} \t  Фамилия: {contact.LastName}\t   Номер: {contact.PhoneNumber}\t    Адрес: {contact.Email}");
                }
            }
        }
    }
}