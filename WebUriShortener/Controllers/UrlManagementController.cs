using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.Models.ViewModels;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUriShortener.Controllers
{
    [Authorize]
    public class UrlManagementController : Controller
    {
        private readonly IUrlService _urlService;
        private IUnitOfWork _unitOfWork;

        public UrlManagementController(IUrlService urlService, IUnitOfWork unitOfWork)
        {
            _urlService = urlService;
            _unitOfWork = unitOfWork;
        }

        [Route("UrlManagement/Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var urls = await _urlService.GetByUserIdAsync(userId);
            var result = new
            {
                data = urls
            };
            return Ok(result);
        }

        [Route("UrlManagement/Create")]
        public IActionResult Create()
        {
            return View(new UrlVM());
        }

        [HttpPost]
        [Route("UrlManagement/Create")]
        public async Task<IActionResult> Create(UrlVM url)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = new UrlModel(url.OriginalUrl, userId);
            result.ShortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/" + result.ShortUrl;
            if (ModelState.IsValid)
            {
                await _urlService.AddAsync(result);
                return RedirectToAction("Index");
            }
            else
            {
                return View(result);
            }
        }
        [Route("UrlManagement/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var url = await _urlService.GetByIdAsync(id);
            if (url == null)
            {
                return NotFound();
            }
            return View(url);
        }

        [HttpPost, ActionName("Delete")]
        [Route("UrlManagement/Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _urlService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Route("UrlManagement/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var url = await _urlService.GetByIdAsync(id);

            if (url == null)
            {
                return NotFound();
            }

            var uri = new Uri(url.OriginalUrl);

            var urlDetailsViewModel = new UrlDetailsViewModel
            {
                Id = url.Id,
                LongUrl = url.OriginalUrl,
                ShortUrl = url.ShortUrl,
                CreationDate = url.CreatedAt,
                AbsolutePath = uri.AbsolutePath,
                AbsoluteUri = uri.AbsoluteUri,
                DnsSafeHost = uri.DnsSafeHost,
                Fragment = uri.Fragment,
                Host = uri.Host,
                HostNameType = uri.HostNameType,
                IdnHost = uri.IdnHost,
                IsAbsoluteUri = uri.IsAbsoluteUri,
                IsDefaultPort = uri.IsDefaultPort,
                IsFile = uri.IsFile,
                IsLoopback = uri.IsLoopback,
                IsUnc = uri.IsUnc,
                LocalPath = uri.LocalPath,
                OriginalString = uri.OriginalString,
                PathAndQuery = uri.PathAndQuery,
                Port = uri.Port,
                Query = uri.Query,
                Scheme = uri.Scheme,
                Segments = uri.Segments,
                UserEscaped = uri.UserEscaped,
                UserInfo = uri.UserInfo
            };

            return View(urlDetailsViewModel);
        }

        [Route("/{shortUrl}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortUrl)
        {
            shortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/" + shortUrl;
            var url = await _urlService.GetByShortUrlAsync(shortUrl);

            if (url == null)
            {
                return NotFound();
            }

            // Збільшення лічильника кліків для аналітики
            url.IncrementClicks();
            var urlDTO = new UrlModel
            {
                Id = url.Id,
                OriginalUrl = url.OriginalUrl,
                ShortUrl = url.ShortUrl,
                Clicks = url.Clicks,
                CreatedAt = url.CreatedAt,
                UserId = url.UserId
            };

            // Оновлення в базі даних
            await _urlService.UpdateAsync(urlDTO);
            // Перенаправлення на оригінальний URL
            return Redirect(url.OriginalUrl);
        }
    }
}
