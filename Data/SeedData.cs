using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public static class SeedData
    {
        private const string password = "Secret123$";

        private const string adminUser = "Admin";
        private const string adminEmail = "admin@hoodkid.com";
        private const string adminRole = "Admin";

        private const string customerUser = "Customer";
        private const string customerEmail = "customer@hoodkid.com";
        private const string customerRole = "Customer";


        public static async void EnsureIdentityPopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<AppUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            if (await userManager.FindByNameAsync(adminUser) == null)
            {
                if (await roleManager.FindByNameAsync(adminRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(adminRole));
                }
                

                AppUser user = new AppUser
                {
                    UserName = adminUser,
                    Email = adminEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
                }

            }
            if (await userManager.FindByNameAsync(customerUser) == null)
            {
                if (await roleManager.FindByNameAsync(customerRole) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(customerRole));
                }


                AppUser user = new AppUser
                {
                    UserName = customerUser,
                    Email = customerEmail
                };

                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, customerRole);
                }

            }
        }
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            Category category = new Category
            {
                CategoryName = "Hoodies"
            };
            Category category1 = new Category
            {
                CategoryName = "Pants"
            };
            Category category2 = new Category
            {
                CategoryName = "Men"
            };
            Category category3 = new Category
            {
                CategoryName = "Women"
            };
            if (!context.Categories.Any())
            {
                context.AddRange(
                    category,
                    category1,
                    category2,
                    category3
                    );
                context.SaveChanges();


            }
            Product product = new Product
            {
                Name = "Hoodkid Hoodie",
                Description = "Winter hoodie made out of cotton.",
                Size = 28,
                Price = 350,
                QOH = 50,
                Color = "White",
                DateAdded = DateTime.Now
            };
            Product product1 = new Product
            {
                Name = "Hoodkid Hoodie",
                Description = "Winter hoodie made out of cotton.",
                Size = 28,
                Price = 350,
                QOH = 50,
                Color = "Blue",
                DateAdded = DateTime.Now
            };
            Product product2 = new Product
            {
                Name = "Hoodkid Sweapants",
                Description = "Winter pants made out of cotton.",
                Size = 28,
                Price = 550,
                QOH = 50,
                Color = "Black",
                DateAdded = DateTime.Now
            };
            Product product3 = new Product
            {
                Name = "Hoodkid Sweapants",
                Description = "Winter pants made out of cotton.",
                Size = 28,
                Price = 550,
                QOH = 50,
                Color = "Green",
                DateAdded = DateTime.Now
            };
            Product product4 = new Product
            {
                Name = "Hoodkid Bag",
                Description = "Bag to rock any occasion",
                Size = 28,
                Price = 550,
                QOH = 50,
                Color = "Brown",
                DateAdded = DateTime.Now
            };
            if (!context.Products.Any())
            {
                context.AddRange(
                    product,
                    product1,
                    product2,
                    product3,
                    product4
                );
                context.SaveChanges();
            }
            SlideShow slideShow = new SlideShow
            {
                Name = "HomeSlideShow"
            };
            SlideShow slideShow1 = new SlideShow
            {
                Name = "Adverts"
            };
            if (!context.SlideShows.Any())

            {
                context.AddRange(
                    slideShow,
                    slideShow1
                    );
                context.SaveChanges();
                    

            }
            if (!context.Photos.Any())
            {
                context.AddRange(
                    new Photo
                    {
                        SlideShowId = slideShow.SlideShowId,
                        Path = "FB_IMG_1716039153686.jpg"
                       
                    },
                    new Photo
                    {
                        SlideShowId = slideShow.SlideShowId,
                        Path = "FB_IMG_1716039369006.jpg"
                    },
                    new Photo
                    {
                        SlideShowId = slideShow.SlideShowId,
                        Path = "FB_IMG_1716039344372.jpg"
                    },
                    new Photo
                    {
                        SlideShowId = slideShow.SlideShowId,
                        Path = "FB_IMG_1716039184854.jpg"
                    }
                    );
                context.SaveChanges();
            }


            context.SaveChanges();
        }
    }
}
