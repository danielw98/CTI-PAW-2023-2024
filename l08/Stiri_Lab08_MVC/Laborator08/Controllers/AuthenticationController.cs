using Laborator08.ContextModels;
using Laborator08.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Laborator08.Controllers;

public class AuthenticationController : Controller
{
    private readonly StiriContext context;

    public AuthenticationController(StiriContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UserModel model)
    {
        if (ModelState.IsValid) 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Username))
                    ModelState.AddModelError(string.Empty, "The username is empty!");
                else if (string.IsNullOrWhiteSpace(model.Password))
                    ModelState.AddModelError(string.Empty, "The password is empty!");
                else if (string.IsNullOrWhiteSpace(model.PasswordConfirm))
                    ModelState.AddModelError(string.Empty, "The password confirmation is empty!");
                else if (model.Password != model.PasswordConfirm)
                    ModelState.AddModelError(string.Empty, "The password and password confirmation don't match!");
                else if (context.User.Where(user => user.Username!.ToLower() == model.Username.ToLower()).Count() > 0)
                    ModelState.AddModelError(string.Empty, "The username is already taken!");
                else
                {
                    try
                    {
                        context.User.Add(model);
                        context.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex) {
                        ModelState.AddModelError(string.Empty, "Error creating account: " + ex.Message);
                    }
                }
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserModel model)
    {
        if(ModelState.IsValid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Username))
                    ModelState.AddModelError(string.Empty, "The username is empty!");
                else if (string.IsNullOrWhiteSpace(model.Password))
                    ModelState.AddModelError(string.Empty, "The password is empty!");
                if (context.User.Where(user => user.Username.ToLower() == model.Username.ToLower() && user.Password == model.Password).Count() > 0)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim("Role", model.Role.ToString())
                    };
                    var claimIdentity = new ClaimsIdentity(claims, "AuthenticationCookie");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity));
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(string.Empty, "Invalid username or password!");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error logging in: " + ex.Message);
            }
            
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        if (User.Identity.IsAuthenticated == false)
            return RedirectToAction("Index", "Home");
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }
}
