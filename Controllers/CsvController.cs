using CsvDataManager.Models;
using CsvDataManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CsvDataManager.Controllers
{
    [AllowAnonymous]
    public class CsvController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ILogger<CsvController> _logger;

        public CsvController(IPersonService personService, ILogger<CsvController> logger)
        {
            _personService = personService;
            _logger = logger;
        }
        // GET: /Csv/Index
        public async Task<ActionResult> Index()
        {
            try
            {
                var data = await _personService.GetAllAsync();
                return View(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching CSV data.");
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
        }

        // GET: /Csv/Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: /Csv/Import
        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if(file==null || file.Length == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select a valid CSV file.");
                return View();
            }
            try
            {
                var result = await _personService.ImportCsvAsync(file);
                if (!result)
                {
                    ModelState.AddModelError("File", "Error Processing file.");
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while importing CSV data.");
                ModelState.AddModelError(string.Empty, "An error occurred while importing the data. Please try again.");
                return View();
            }
        }
        // GET: /Csv/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var data = await _personService.GetByIdAsync(id);
                if (data == null) return NotFound();
                return View(data);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while fetching CSV data for edit.");
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
        }

        // POST: /Csv/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FirstName,LastName,Age,Gender,Mobile,IsActive")] Persons data)
        {
            if (!ModelState.IsValid) return View(data);

            try
            {
                var result = await _personService.UpdateAsync(data);
                if (!result) return View(data);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while editing CSV data.");
                ModelState.AddModelError(string.Empty, "An error occurred while saving the data. Please try again.");
            }
            return View(data);
        }

        // GET: /Csv/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _personService.GetByIdAsync(id);
                if (data == null) return NotFound();
                return View(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching CSV data for delete.");
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
            
        }
        
        // POST: /Csv/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _personService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Error occurred while deleting CSV data.");
                return View("Error", new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
            }
        }
    }
}
