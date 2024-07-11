using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public static class SeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        private const string adminEmail = "admin@contoso.com";
        private const string adminRole = "Admin";

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

                IdentityResult result = await userManager.CreateAsync(user, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, adminRole);
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
            if(!context.Products.Any())
            {
                context.AddRange(
                    
                    new Product
                    {
                        Name = "Hoodkid Hoodie",
                        Description = "Winter hoodie made out of cotton.",
                        Size = 28,
                        Price = 350,
                        QOH = 50,
                        Color = "White"
                    },
                    new Product
                    {
                        Name = "Hoodkid Hoodie",
                        Description = "Winter hoodie made out of cotton.",
                        Size = 28,
                        Price = 350,
                        QOH = 50,
                        Color = "Blue"
                    },
                    new Product
                    {
                        Name = "Hoodkid Sweapants",
                        Description = "Winter pants made out of cotton.",
                        Size = 28,
                        Price = 550,
                        QOH = 50,
                        Color = "Black"
                    },
                    new Product
                    {
                        Name = "Hoodkid Sweapants",
                        Description = "Winter pants made out of cotton.",
                        Size = 28,
                        Price = 550,
                        QOH = 50,
                        Color = "Green"
                    },
                    new Product
                    {
                        Name = "Hoodkid Bag",
                        Description = "Bag to rock any occasion",
                        Size = 28,
                        Price = 550,
                        QOH = 50,
                        Color = "Brown"
                    }
                );

            }
            if(!context.SlideShows.Any())
            {
                context.AddRange(
                    new SlideShow
                    {
                        Name = "HomeSlideShow"
                    },
                    new SlideShow
                    {
                        Name = "Adverts"
                    });
            }
            if (!context.Photos.Any())
            {
                context.AddRange(
                    new Photo
                    {
                        SlideShowId = 1,
                        Path = "FB_IMG_1716039153686.jpg"
                       
                    },
                    new Photo
                    {
                        SlideShowId = 1,
                        Path = "FB_IMG_1716039369006.jpg"
                    },
                    new Photo
                    {
                        SlideShowId = 1,
                        Path = "FB_IMG_1716039344372.jpg"
                    },
                    new Photo
                    {
                        SlideShowId = 1,
                        Path = "FB_IMG_1716039184854.jpg"
                    }
                    );
            }


            context.SaveChanges();
        }
    }
}
