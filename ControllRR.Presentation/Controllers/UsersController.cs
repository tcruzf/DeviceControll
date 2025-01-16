using ControllRR.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ControllRR.Application.DTOs;

namespace ControllRR.Presentation.Controllers;


public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }



    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        //return user != null ? Ok(user) : NotFound();
        return View(user);
    }


    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return View(users);

    }

}