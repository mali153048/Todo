using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using ToDo.Application.Contracts.Services;
using ToDo.Application.DTO;
using ToDo.Application.Responses;
using ToDo.WEB.Models;

namespace ToDo.WEB.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITodoService _todoService;

        public HomeController(ILogger<HomeController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var id = GetCurrentUserID();

            if (!id.HasValue)
                return RedirectToAction("login", "auth");

            var response = await _todoService.GetAllByUserIDAsync(id.Value).ConfigureAwait(false);

            return View(response.Todos);
        }


        [HttpPost]
        public async Task<IActionResult> UpsertTodo(NewTodoDTO model)
        {
            TempData.Clear();

            var userID = GetCurrentUserID();

            if (!userID.HasValue)
                return RedirectToAction("login", "auth");

            model.UserID = userID.Value;

            var response = new BaseResponse();

            if (!model.ID.HasValue)
            {
                //New todo
                response = await _todoService.NewTodoAsync(model).ConfigureAwait(false);
            }
            else
            {
                //Edit todo
                response = await _todoService.UpdateTodoAsync(model).ConfigureAwait(false);
            }


            if (response.Success)
            {
                TempData["NewtodoSuccessStatus"] = model.ID.HasValue ? "TODO edited successfully." : "New TODO created, Good luck.";
            }
            else
            {
                TempData["NewtodoErrorStatus"] = "Oops! An error ocurred.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> Edit(int? id)
        {
            if (!id.HasValue)
                return Json(new { success = false });

            var response = await _todoService.GetTodoAsync(id.Value).ConfigureAwait(false);

            return Json(new { success = response.Success, data = response.Todo });
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException(nameof(id));

            var response = await _todoService.DeleteTodoAsync(id.Value).ConfigureAwait(false);

            return Json(new { success = response.Success, data = id });
        }

        [HttpGet]
        public async Task<JsonResult> Details(int? id)
        {
            if (!id.HasValue)
                throw new ArgumentNullException(nameof(id));

            var response = await _todoService.TodoDetailsAsync(id.Value).ConfigureAwait(false);

            return Json(new { success = response.Success, data = response });
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(NewTodoDTO model)
        {
            return await UpsertTodo(model);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}