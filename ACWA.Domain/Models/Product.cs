using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ACWA.Domain.Models
{
    public class Product
    {
        private Category _category;

        public Product()
        { }

        private Product(Action<object, string> lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private Action<object, string> LazyLoader { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Category Category
        {
            get => LazyLoader.Load(this, ref _category);
            set => _category = value;
        }
    }
}
