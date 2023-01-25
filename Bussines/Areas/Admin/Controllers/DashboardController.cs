using DataAccess_bs.Context;
using Microsoft.AspNetCore.Mvc;

namespace Bussines.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _appDbContext;

    public DashboardController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IActionResult Index()
    {
        return View(_appDbContext.member);
    }
}
