using System.Collections.Generic;
using Rus_Andreea_lab2.Models;

namespace Rus_Andreea_lab2.ViewModels
{
    public class PublisherIndexData
    {
        public IList<Publisher> Publishers { get; set; }
        public IList<Book> Books { get; set; }
    }
}