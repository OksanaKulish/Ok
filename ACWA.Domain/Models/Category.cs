using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACWA.Domain.Models
{
    public class Category
    {
        private ICollection<Product> _products;

        public Category()
        { }

        private Category(Action<object, string> lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private Action<object, string> LazyLoader { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Product> Products
        {
            get => LazyLoader.Load(this, ref _products);
            set => _products = value;
        }
    }

    public static class LoadingExtensions
    {
        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            loader?.Invoke(entity, navigationName);

            return navigationField;
        }
    }
}
