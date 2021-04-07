using System;
using System.Collections.Generic;
using ElectronicStore.Models;

namespace ElectronicStore.ViewModel
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize); // всего страниц
    }
}