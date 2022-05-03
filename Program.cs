using System;

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






        }
    }


    class DataBase
    {


    }

    class Book
    {
        private string _author;
        private string _title;
        private string _genre;
        private int _yearPublikation;
        private int _closingPageBook;

        Book(string author, string title, string, string genre, int yearPublikation, int closingPageBook)
        {
            _author = author;
            _title = title;
            _genre = genre;
            _yearPublikation = yearPublikation;
            _closingPageBook = closingPageBook;
        }

        internal string Show()
        {
            string informationAboutBook = "Автор - " + _author + "  Название - " + _title + "  Жанр - " + _genre +
                                         "  Год публикации - " + _yearPublikation + "  Закрыта на странице - " + _closingPageBook;
            return informationAboutBook;
        }

    }
}
