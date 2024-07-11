using Azure.Core;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ECommerce.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "user")]
    public class UserValidationTagHelper : TagHelper
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public UserValidationTagHelper(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public LoginViewModel LoginViewModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            LoginViewModel login = LoginViewModel;
            if(login != null)
            {
                AppUser user = userManager.FindByEmailAsync(LoginViewModel.Email).Result;
                if (user != null)
                {
                    var result = signInManager.PasswordSignInAsync(user,
                        login.Password, false, false);
                    if (!result.Result.Succeeded)
                    {
                        output.TagName = "span";
                        output.Attributes.SetAttribute("class", "text-danger");
                        output.Content.SetContent("Incorrect emaill or password");
                        output.Attributes.SetAttribute("onclick", "return stopSubmit(event);");

                        
                    }

                }
            }
           
        }
    }
}
