using System;
using System.Collections.Generic;

namespace OOP5
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.OutputHeader();

            bool isContinueCycle = true;

            while (isContinueCycle)
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "добавить":

                        menu.AddBook();

                        break;
                    case "удалить":

                        menu.DeleteBook();

                        break;
                    case "показать как":

                        menu.ShowBooksByParameters();

                        break;
                    case "показать":

                        menu.ShowBooks();

                        break;
                    default:

                        menu.OutputWarning();

                        break;
                }
            }
        }
    }

    class Menu
    {
        private DataBaseManagement _dataBaseManagement = new();

        internal void OutputHeader()
        {
            Console.Clear();
            Console.WriteLine("Присутствуют следующие команды");
            Console.WriteLine("Добавить книгу - добавить");
            Console.WriteLine("Удалить книгу - удалить");
            Console.WriteLine("Список книг по параметру - показать как");
            Console.WriteLine("Список всех книг - показать");
        }

        internal void OutputWarning()
        {
            Console.WriteLine("Введены не верные параметры попробуйте с начала");
        }

        internal void OutputWarning(int number)
        {
            Console.WriteLine("Введенный номер " + number + " книги отсутствует");
        }

        internal void OutputWarning(string text)
        {
            Console.WriteLine(text);
        }

        internal void AddBook()
        {
            Console.Write("Введите Автора книги - ");
            string autorBook = Console.ReadLine();
            Console.Write("Введите название книги - ");
            string titleBook = Console.ReadLine();
            Console.Write("Введите жанр книги - ");
            string genreBook = Console.ReadLine();
            Console.Write("Введите год выпуска книги - ");
            string yearPublikationBook = Console.ReadLine();
            int year = 0;

            if (_dataBaseManagement. IsNumber(yearPublikationBook, ref year))
            {
                _dataBaseManagement.AddBook(autorBook, titleBook, genreBook, year);
            }
            else
            {
                OutputWarning();
            }
        }

        internal void DeleteBook()
        {
            Console.Write("Выберите номер книги которую хотите удалить - ");
            string keyString = Console.ReadLine();
            int key = 0;

            if (_dataBaseManagement.IsNumber(keyString, ref key))
            {
                _dataBaseManagement.DeletePlayer(key);
            }
            else
            {
                OutputWarning();
            }
        }

        internal void ShowBooks()
        {
            _dataBaseManagement.ShowBooks();
        }

        internal void ShowBooksByParameters()
        {
            Console.WriteLine("Выберите параметр по которому выбрать книги");
            Console.WriteLine("По автору - автор");
            Console.WriteLine("По названию - название");
            Console.WriteLine("По году выпуска - год");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "автор":

                    _dataBaseManagement.ShowBooksAutor();

                    break;
                case "название":

                    _dataBaseManagement.ShowBooksTitle();

                    break;
                case "год":

                    _dataBaseManagement.ShowBooksYears();

                    break;
                default:

                    OutputWarning();

                    break;
            }
        }
    }

    class DataBaseManagement
    {
        private List<Book> _books = new List<Book>();

        internal void AddBook(string autorBook, string titleBook, string genreBook, int yearPublikationBook)
        {
            Book book = new Book(autorBook, titleBook, genreBook, yearPublikationBook);

            _books.Add(book);
            ShowBooks();
        }

        internal void ShowBooks()
        {
            Menu menu = new();

            Console.Clear();
            menu.OutputHeader();

            int length = _books.Count;

            for (int i = 0; i < length; i++)
            {
                Book book = _books[i];
                Console.WriteLine("Номер - " + i + " | " + book.Show());
            }
            Console.Write("\n");
        }

        internal void ShowBooks(List<Book> books)
        {
            Menu menu = new();

            Console.Clear();
            menu.OutputHeader();

            int length = books.Count;

            for (int i = 0; i < length; i++)
            {
                Book book = books[i];
                Console.WriteLine("Номер - " + i + " | " + book.Show());
            }
            Console.Write("\n");
        }

        internal void ShowBooksTitle()
        {
            Console.Write("Выберите название книги - ");
           string userInput = Console.ReadLine();

            List<Book> booksTitle = new();

            foreach (var item in _books)
            {
                if (item.Title == userInput)
                {
                    booksTitle.Add(item);
                }
            }

            if (booksTitle.Count > 0)
            {
                ShowBooks(booksTitle);
            }
            else
            {
                Menu menu = new();
                string message = "Книги с названием " + userInput+" Не существует.";
                menu.OutputWarning(message);
            }
        }

        internal void ShowBooksAutor()
        {
            Console.Write("Введите автора книги - ");
            string userInput = Console.ReadLine();

            List<Book> booksAutor = new();

            foreach (var item in _books)
            {
                if (item.Author == userInput)
                {
                    booksAutor.Add(item);
                }
            }

            if (booksAutor.Count > 0)
            {
                ShowBooks(booksAutor);
            }
            else
            {
                Menu menu = new();
                string message = "Книга с автором " + userInput+" отсутствует.";
                menu.OutputWarning(message);
            }
        }

        internal void ShowBooksYears()
        {
            Menu menu = new();
          
            Console.Write("Выберите год издания - ");

            string userInput = Console.ReadLine();
            int yearPublikation = 0;

            if (IsNumber(userInput, ref yearPublikation))
            {
                List<Book> booksTitle = new();

                foreach (var item in _books)
                {
                    if (item.YearPublikation == yearPublikation)
                    {
                        booksTitle.Add(item);
                    }
                }

                if (booksTitle.Count > 0)
                {
                    ShowBooks(booksTitle);
                }
                else
                {
                    string message = "Книга  c годом выпуска " + yearPublikation+" отсутствует.";
                    menu.OutputWarning(message);
                }
            }
            else
            {
                menu.OutputWarning();
            }
        }

        internal void DeletePlayer(int key)
        {
            if (_books.Count >= key)
            {
                _books.RemoveAt(key);
                ShowBooks();
            }
            else
            {
                Menu menu = new();
                menu.OutputWarning(key);
            }
        }

        internal bool IsNumber(string text, ref int number)
        {
            bool isNumber = int.TryParse(text, out number);

            return isNumber;
        }
    }

    class Book
    {
        private int _closingPageBook;
        private int _startPageBook = 1;

        internal string Author { get; private set; }
        internal string Title { get; private set; }
        internal string Genre { get; private set; }
        internal int YearPublikation { get; private set; }

        public Book(string author, string title, string genre, int yearPublikation)
        {
            Author = author;
            Title = title;
            Genre = genre;
            YearPublikation = yearPublikation;
            _closingPageBook = _startPageBook;
        }

        internal string Show()
        {
            string informationAboutBook = "Автор - " + Author + "  Название - " + Title + "  Жанр - " + Genre +
                                         "  Год публикации - " + YearPublikation + "  Закрыта на странице - " + _closingPageBook;
            return informationAboutBook;
        }
    }
}
