using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext appDbContext;
        private ICategoryRepository _category;
        private IProductRepository _product;
        private ISlideShowRepository _slideShow;
        private IPhotoReposiory _photo;
        private IProductCategoryRepository _productCategory;
        private ICartRepository _cart;
        private ICartItemsRepository _cartItem;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public ICartItemsRepository CartItem 
        {
            get
            {
                if (_cartItem == null)
                {
                    _cartItem = new CartItemsRepository(appDbContext);
                }
                return _cartItem;
            }
        }
        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(appDbContext);
                }
                return _cart;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if(_category == null)
                {
                    _category = new CategoryRepository(appDbContext);
                }
                return _category;
            }
        }
        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                { 
                    _product = new ProductRepository(appDbContext);
                }
                return _product;
            }
        }

        public ISlideShowRepository SlideShow 
        {
            get
            {
                if (_slideShow == null)
                    _slideShow = new SlideShowRepository(appDbContext);
                return _slideShow;
            }
        }

        public IPhotoReposiory Photo 
        { 
            get
            {
                if (_photo == null)
                    _photo = new PhotoRepository(appDbContext);
                return _photo;
            } 
        }

        public IProductCategoryRepository ProductCategory 
        {
            get
            {
                if (_productCategory == null)
                    _productCategory = new ProductCategoryRepository(appDbContext);
                return _productCategory;
            }
        }


        public void SaveChanges()
        {
            appDbContext.SaveChanges();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return appDbContext.Database.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            appDbContext.Database.RollbackTransaction();
        }
    }
}
