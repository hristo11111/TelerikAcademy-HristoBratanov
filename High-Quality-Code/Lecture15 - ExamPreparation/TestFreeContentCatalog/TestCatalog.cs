namespace TestFreeContentCatalog
{
    using System;
    using System.Linq;
    using FreeContentCatalog;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCatalog
    {
        [TestMethod]
        public void TestCatalogAddMethod_When1BookAdded()
        {
            Catalog catalog = new Catalog();
            string[] bookContent = { "C++", "Nakov", "874563892", "http://www.c++.info" };
            catalog.Add(new Content(ContentType.Book, bookContent));

            var result = catalog.GetListContent("C++", 1);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestCatalogAddMethod_When1BookAdded_CheckContent()
        {
            Catalog catalog = new Catalog();
            string[] bookContent = { "C++", "Nakov", "874563892", "http://www.c++.info" };
            Content book = new Content(ContentType.Book, bookContent);

            catalog.Add(book);

            var result = catalog.GetListContent("C++", 1);

            Assert.AreSame(book, result.First());
        }

        [TestMethod]
        public void TestCatalogAddMethod_WhenMultipleItemsAdded()
        {
            Catalog catalog = new Catalog();

            string[] bookContent = { "C++", "Nakov", "874563892", "http://www.c++.info" };
            Content book = new Content(ContentType.Book, bookContent);
            catalog.Add(book);

            string[] movieContent = { "Black cat", "Petko P.", "121563892", "http://www.blackCat.info" };
            Content movie = new Content(ContentType.Movie, movieContent);
            catalog.Add(movie);

            string[] songContent = { "Black cat", "Alex", "1563892", "http://www.alexsong.info" };
            Content song = new Content(ContentType.Song, songContent);
            catalog.Add(song);

            var result = catalog.GetListContent("Black cat", 2);

            Assert.AreEqual(2, result.Count());
        }
    }
}
