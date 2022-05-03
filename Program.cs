using System;
using System.Collections.Generic;

namespace OOP5
{
    //    Создать хранилище книг.
    //Каждая книга имеет название, автора и год выпуска(можно добавить еще параметры).
    //В хранилище можно добавить книгу, убрать книгу, показать все книги и
    //показать книги по указанному параметру(по названию, по автору, по году выпуска).



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
                    case "д":

                        menu.AddBook();

                        break;
                    case "у":

                      //  databaseManagement.DeletePlayer();

                        break;
                    case "пр":

                     //   databaseManagement.UnBanPlaer();

                        break;
                    case "п":

                      //  databaseManagement.ShowBasePlayer();

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
        private DataBaseManagement _dataBaseManagement = new DataBaseManagement();

        internal void OutputHeader()
        {
            Console.WriteLine("Присутствуют следующие команды");
            Console.WriteLine("Добавить книгу - д");
            Console.WriteLine("Удалить книгу - у");
            Console.WriteLine("Список книг по параметру - пр");
            Console.WriteLine("Список всех книг - п");
        }

        internal void OutputWarning()
        {
            Console.WriteLine("Введены не верные параметры");
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
            int year=0;

            if(IsNumber(yearPublikationBook,ref year))
            {
                _dataBaseManagement.AddBook(autorBook, titleBook, genreBook, year);
            }else
            {
                OutputWarning();
            }
        }

        internal bool IsNumber(string text,ref int number)
        {
            bool isNumber = int.TryParse(text, out number);

            return isNumber;
        }
    }

    class DataBaseManagement
    {

        private List<Book> _books = new List<Book>();
        private Menu _menu = new Menu();

        //public void UnBanPlaer()
        //{
        //    Console.WriteLine("Введите номер разблокированного игрока ");

        //    string keyString = Console.ReadLine();

        //    if (int.TryParse(keyString, out int key))
        //    {
        //        if (_dataBase.UnBannedPlayer(key) == false)
        //        {
        //            Console.WriteLine("Введенный номер игрока отсутствует");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Введенный номер не является числом");
        //    }

        //    ShowBasePlayer();
        //}

        //public void BanPlaer()
        //{
        //    Console.WriteLine("Введите номер заблокированного игрока ");

        //    string keyString = Console.ReadLine();

        //    if (int.TryParse(keyString, out int key))
        //    {
        //        if (_dataBase.IsBannedPlayer(key) == false)
        //        {
        //            Console.WriteLine("Введенный номер игрока отсутствует");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Введенный номер не является числом");
        //    }

        //    ShowBasePlayer();
        //}

        

        //public void DeletePlayer()
        //{
        //    Console.WriteLine("Введите номер удаляемого игрока");

        //    string keyString = Console.ReadLine();

        //    if (int.TryParse(keyString, out int key))
        //    {
        //        _dataBase.DeletePlayer(key);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Введенный номер не является числом");
        //    }

        //    ShowBasePlayer();
        //}

        internal void AddBook(string autorBook, string titleBook, string genreBook, int yearPublikationBook)
        {
            Book book = new Book(autorBook,titleBook,genreBook,yearPublikationBook);

            _books.Add(book);
            ShowBooks();
        }
        internal void ShowBooks()
        {
            Console.Clear();
            _menu.OutputHeader();

            int length = _books.Count;

            for (int i = 0; i < length; i++)
            {
                Book book = _books[i];
                Console.WriteLine("Номер - " + i + " | " + book.Show());
            }
            //Console.WriteLine("");

        }

    }

    class Book
    {
        private string _author;
        private string _title;
        private string _genre;
        private int _yearPublikation;
        private int _closingPageBook;
        private int _startPageBook = 1;

        
        public Book(string author, string title, string genre, int yearPublikation)
        {
            _author = author;
            _title = title;
            _genre = genre;
            _yearPublikation = yearPublikation;
            _closingPageBook = _startPageBook;
        }

        internal string Show()
        {
            string informationAboutBook = "Автор - " + _author + "  Название - " + _title + "  Жанр - " + _genre +
                                         "  Год публикации - " + _yearPublikation + "  Закрыта на странице - " + _closingPageBook;
            return informationAboutBook;
        }

    }
}
