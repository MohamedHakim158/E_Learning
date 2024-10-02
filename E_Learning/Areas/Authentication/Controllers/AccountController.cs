using E_Learning.Areas.Authentication.Models;
using E_Learning.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;

namespace E_Learning.Areas.Authentication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authService;

        public AccountController(IAuthService authService)
        {
            this.authService = authService;
        }
        #region Register
        public async Task<IActionResult> Register()
        {
            return View("Register" , new RegisterRequest());
        }
        
        public async Task<IActionResult> SaveRegister(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                if(await authService.CheckEmailExist(model.Email))
                {
                    ModelState.AddModelError("Email", "There is already an account with this email");
                    goto returning;
                }
                if (await authService.CheckUserNameTaken(model.UserName))
                {
                    ModelState.AddModelError("UserName", $"UserName: {model.UserName} is already taken");
                    goto returning;
                } 
                var result = await authService.RegisterAsync(model);
                if (!result.IsSucceded)
                {
                    ModelState.AddModelError(string.Empty, result.Message);
                    goto returning;
                }

                TempData["ConfirmEmailCode"] = await GenerateCode();
                var model1 = new ConfrimEmailRequest
                {
                    Email = model.Email,
                    Code = Convert.ToInt32(TempData.Peek("ConfirmEmailCode"))
                };
                await authService.SendConfirmationEmailAsync(model1);
                model1.Code = null;
                return View("ConfirmEmail", model1);

            }
            returning: return View("Register", model);
        }



        #endregion

        #region Confirm Email
       
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail( ConfrimEmailRequest model)
        {
            //may make a counter
            var correctCode = Convert.ToInt32(TempData.Peek("ConfirmEmailCode"));
            if (model.Code == correctCode)
            {
                await authService.ConfirmEmailAsync(model.Email);
                TempData.Remove("ConfirmEmailCode");
                return RedirectToAction("Login");

            }
            ModelState.AddModelError("Code", "Error code entered");
            return View(model);
            }
        
        public async Task<IActionResult> ResendConfirmEmail(ConfrimEmailRequest model)
        {
            if (TempData.ContainsKey("ConfirmEmailCode"))
            {
                ModelState.AddModelError("","you can request another code after 5 minutes");
                return View("ConfirmEmail", model);
            }
            else
            {
                return RedirectToAction("SendConfirmEmail", model.Email);
            }
            
        }
        #endregion

        #region Password Reset & change
        public async Task<IActionResult> EnterEmailForForget()
        {
            return View("AuthEmail");
        }
        
        public async Task<IActionResult> SendResetPasswordEmail(string email)
        {
            
            if (!await authService.CheckEmailExist(email))
            {
                ModelState.AddModelError("", $"There is no Account with email: {email} "  );
                return View("AuthEmail", email);
            }
            var model = new ConfrimEmailRequest
            {
                Email = email,
                Code = await GenerateCode()
            };
            TempData["ResetPasswordCode"] = model.Code;
            var result = await authService.SendResetPassowrdEmail(model);
            if(result.IsSucceded)
                return View("ResetPassword");
            return View("AuthEmail", email);
        }
        public async Task<IActionResult> ResendResetPasswordEmail(ResetPasswordRequest model)
        {
            if (TempData.ContainsKey("ResetPasswordCode"))
            {
                ModelState.AddModelError("Code", "you can request another code after 5 minutes");
                return View("ResetPassword", model);
            }
            return RedirectToAction("EnterEmailForForget");
        }
        
        public async Task<IActionResult> CompleteResetPassword(ResetPasswordRequest model)
        {
            if (ModelState.IsValid)
            {
                var correctCode = Convert.ToInt32(TempData.Peek("ResetPasswordCode"));
                if (model.Code == correctCode)
                {
                    TempData.Remove("ResetPasswordCode");
                    await authService.ResetPasswordAsync(model);
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("Code", "Error Code Entered");
                
            }
            return View("ResetPassword", model);
            
        }
        
        [Authorize]
        public async Task<IActionResult> ChangePassword()
        {
            return View("ChangePassword");
        }
        public async Task<IActionResult> SaveChangePassword(ChangePasswordRequest model)
        {
            model.Email = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email)!.Value;
            return Ok();
        }
        #endregion

        #region Login & Logout
        public async Task<IActionResult> Login()
        {
            return View("login",new LoginRequest());
        }
        public async Task<IActionResult> CheckLogin(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                if (!await authService.CheckEmailExist(model.Email))
                {
                    ModelState.AddModelError("Email", "There is no account with this email");
                    goto returning;
                }
                if (!await authService.EmailConfirmed(model.Email))
                {
                    return RedirectToAction("ConfirmEmail" , new ConfrimEmailRequest { Email = model.Email });
                }
                var result = await authService.LoginAsync(model);
                if (result.IsSucceded)
                {
                        return Content("Login Successfully");  
                }
                else
                {
                    ModelState.AddModelError("Password", "Wrong Password");
                }
            }
          returning:  return View("Login",model);
        }
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return Ok();
        }
        #endregion




        private async Task<int> GenerateCode()
        {
            Random code = new Random();
            return code.Next(100000, 999999);
        }
    }
}
