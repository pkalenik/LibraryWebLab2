using LibraryWEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWEB.Controllers
{
    public class CMSController : Controller
    {
        private LibraryContext db;

        public CMSController(LibraryContext db)
        {
            this.db = db;
        }

        public IActionResult CMSPage(int page = 1, string pageCode = "home", string lang = "eng")
        {
            int pageSize = 3;

            if (pageCode.Contains("home"))
            {
                var mainPage = db.Pages.First(p => p.PageCode == "home");

                IEnumerable<Page> childrensPage;

                if (mainPage.OrderType == "date")
                {
                    childrensPage = db.Pages.Where(p => p.ParentCode == mainPage.PageCode).OrderByDescending(p => p.DateCreate);
                }
                else
                {
                    childrensPage = db.Pages.Where(p => p.ParentCode == mainPage.PageCode).OrderBy(p => p.Id);
                }

                ViewBag.Lang = lang;

                var count = childrensPage.Count();
                var items = childrensPage.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    Pages = items
                };

                ViewBag.ViewModel = viewModel;

                return View(mainPage);
            }

            if (pageCode.Contains("article"))
            {
                var article = db.Pages.FirstOrDefault(a => a.PageCode == pageCode);

                var mainPage = db.Pages.Where(p => p.PageCode.Contains("article") && p.Tag == article.Tag && p.PageCode != article.PageCode).Take(4);

                ViewBag.MainPage = mainPage;

                ViewBag.Lang = lang;

                return View(article);
            }

            return View(new {});
        }
    }
}
