using LibraryWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWEB.Services
{
    public class RenderPageService
    {
        private LibraryContext db;
        public RenderPageService(LibraryContext db)
        {
            this.db = db;
        }

        public (IndexViewModel indexViewModel, Page renderPage, IEnumerable<Page> pages) Render(int page, string pageCode)
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

                var count = childrensPage.Count();
                var items = childrensPage.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
                IndexViewModel viewModel = new IndexViewModel
                {
                    PageViewModel = pageViewModel,
                    Pages = items
                };

                var result = (indexViewModel: viewModel, renderPage: mainPage, pages: new List<Page>());

                return result;
            }

            if (pageCode.Contains("article"))
            {
                var article = db.Pages.FirstOrDefault(a => a.PageCode == pageCode);

                var mainPage = db.Pages.Where(p => p.PageCode.Contains("article") && p.Tag == article.Tag && p.PageCode != article.PageCode).Take(4);

                var result = (indexViewModel: new IndexViewModel(), renderPage: article, pages: mainPage);

                return result;
            }


            var defaultResult = (indexViewModel: new IndexViewModel(), renderPage: new Page(), pages: new List<Page>());

            return defaultResult;
        }
    }
}
