using Core_bs.Entities;
using DataAccess_bs.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bussines.Areas.Admin.Controllers;
[Area("Admin")]
public class MemberController : Controller
{
    private readonly AppDbContext _appcontext;

    public MemberController(AppDbContext appcontext)
    {
        _appcontext = appcontext;
    }

    public IActionResult Index()
    {
        return View(_appcontext.member);
    }
    //[HttpGet]
    //public async Task<IActionResult> Getproduct()
    //{
    //    var product = await _appcontext.member.FindAsync();
    //    return Json(product);
    //}
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult>Create(TeamMember person)
    {
        if(!ModelState.IsValid)return View(person);
        await _appcontext.member.FindAsync(person);
        await _appcontext.SaveChangesAsync();
        return View(RedirectToAction(nameof(person)));
    }
    public async Task<IActionResult> Detail(int? id)
    {
        var product = await _appcontext.member.FindAsync(id);
        if (product == null) return BadRequest();
        return View(product);
    }



}
