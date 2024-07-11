using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace ECommerce.Data
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category {  get; }
        IProductRepository Product { get; }
        ISlideShowRepository SlideShow { get; }
        IPhotoReposiory Photo { get; }
        IProductCategoryRepository ProductCategory { get; }
        ICartItemsRepository CartItem { get; }
        ICartRepository Cart { get; }
        IDbContextTransaction BeginTransaction();
        void RollbackTransaction();
        void SaveChanges();
    }
}
