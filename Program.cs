using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_managment_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isOpen = true;
            // "полки с книгами"
            string[,] books = {
                { "Джордж Мартин", "Эдгар По", "Нил Гейман" },
                {"Джесси Шелл", "Роберт Мартин", "Сергей Тепляков" },
                {"Грэм Макниллл", "Чак Паланик", "Макс Фрай" },
                
            };

            while ( isOpen )
            {
                Console.SetCursorPosition( 0, 20 );
                Console.WriteLine("Весь список авторов:");
                Console.WriteLine();

                // внешний цикл обращается к "полке"
                for (int i = 0; i < books.GetLength(0); i++)
                {
                    // внутренний цикл обращается к "книге"
                    for (int g = 0; g < books.GetLength(1); g++)
                    {
                        Console.Write(books[i, g] + " | ");
                    }
                    
                    Console.WriteLine();
                }

                // оформление библиотеки 
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Библиотека");
                Console.WriteLine();

                // возможные команды 
                Console.Write("\n1 - узнать автора по индексу книги.\n\n2 - найти книгу по автору.\n\n3 - выход.");
                Console.WriteLine();
                Console.Write("Выберите пункт меню:  ");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1: int line, column;
                        Console.Write("Введите номер полки: ");
                        line = Convert.ToInt32(Console.ReadLine()) -1; // -1 конвертирует ввод, т.к. столбцы и строки начинаются с 0
                        Console.Write("Введите номер столбца: ");
                        column = Convert.ToInt32(Console.ReadLine()) -1;
                        Console.WriteLine("Этот автор " + books[line, column]);
                        break;
                    case 2: string author;
                        bool authorIsFound = false;
                        Console.Write("Введите автора: ");
                        author = Console.ReadLine();
                        for (int i = 0; i < books.GetLength(0); i++)
                        {
                            for (int g = 0; g < books.GetLength(1); g++)
                            {
                                if (author.ToLower() == books[i, g].ToLower())
                                {
                                    Console.WriteLine($"Автор {books[i, g]} находится на полке {i + 1}, место {g + 1}."); // +1 является обратной конвертацией
                                    authorIsFound = true;
                                }
                            }
                        }
                        if (authorIsFound == false)
                        {
                            Console.WriteLine("Такого автора нет.");
                        }
                        break;
                    case 3: isOpen = false;
                        break;
                    default: Console.Write("Введена неверная команда.");
                        break;
                }

                if (isOpen)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                }

                Console.ReadKey();
                Console.Clear();

                
            }
        }
    }
}
