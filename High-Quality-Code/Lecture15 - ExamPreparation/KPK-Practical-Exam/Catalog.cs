namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    /// <summary>
    /// Represents a catalog the project "FreeContentCatalog",
    /// which can contain multiple items: books, movies
    /// songs and software applications.
    /// </summary>
    public class Catalog : ICatalog
    {
        /// <summary>
        /// Object from type <see cref="MultiDictionary"/>, with key - url
        /// and value <see cref="IContent"/>
        /// </summary>
        private readonly MultiDictionary<string, IContent> url;

        /// <summary>
        /// Object from type <see cref="OrderedMultiDictionary"/>, with key - title
        /// and value <see cref="IContent"/>
        /// </summary>
        private readonly OrderedMultiDictionary<string, IContent> title;

        /// <summary>
        /// Initializes a new instance of the <see cref="Catalog" /> class.
        /// The catalog will have boolean variable 
        /// <paramref name="allowDuplicateValues"/> allowDuplicateValues,
        /// <paramref name="title"/> title and <paramref name="url"/> url.
        /// </summary>
        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        /// <summary>
        /// Method for adding new content item in the catalog.
        /// </summary>
        /// <param name="content">The content that the item contain.</param>
        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        /// <summary>
        /// Returns list of items by given item title and number of items needed.
        /// If the count of needed items exceeds the count of the items in the list, 
        /// that match the given title, the method returns all items which are currently in the list.
        /// If the count of needed items is less than the count of the items in the list,
        /// that match the given title, the method returns the first items 
        /// which count equals to the needed one. 
        /// </summary>
        /// <param name="title">The search word for titles in the catalog.</param>
        /// <param name="numberOfContentElements">Number of items to show with such title.</param>
        /// <returns>List of items that match the needed title and count.</returns>
        public IEnumerable<IContent> GetListContent(
            string title, int numberOfContentElements)
        {
            IEnumerable<IContent> contentToList =
                from content in this.title[title]
                select content;

            return contentToList.Take(numberOfContentElements);
        }

        /// <summary>
        /// Sets new url in the pointed item if exists.
        /// </summary>
        /// <param name="oldUrl">The url which will be changed.</param>
        /// <param name="newUrl">The url which will take the place of the old url</param>
        /// <returns>The number of the updated items</returns>
        public int UpdateContent(string oldUrl, string newUrl)
        {
            int updatedElements = 0;

            List<IContent> contentToList = this.url[oldUrl].ToList();

            foreach (Content content in contentToList)
            {
                this.title.Remove(content.Title, content);
                updatedElements++;
            }

            this.url.Remove(oldUrl);

            foreach (IContent content in contentToList)
            {
                content.Url = newUrl;
                this.title.Add(content.Title, content);
                this.url.Add(content.Url, content);
            }

            return updatedElements;
        }
    }
}
