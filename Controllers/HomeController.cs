using CalcWeb.Models;
using CalcWeb.Services;
using CalcWeb.Parser;
using Microsoft.AspNetCore.Mvc;


namespace CalcWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalcService _calcService;
        private readonly IParser _parser;
        public HomeController(ICalcService calcService, IParser parser)
        {
            _calcService = calcService;
            _parser = parser;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalcModel());
        }

        [HttpGet("add")]
        public IActionResult Add(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _calcService.Add(model.FirstVal, model.SecondVal);
            }
            return View("Index", model);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _calcService.Subtract(model.FirstVal, model.SecondVal);
            }
            return View("Index", model);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _calcService.Multiply(model.FirstVal, model.SecondVal);
            }
            return View("Index", model);
        }

        [HttpGet("divide")]
        public IActionResult Divide(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SecondVal == 0)
                {
                    ModelState.AddModelError("SecondVal", "Division by zero is not allowed.");
                }
                else
                {
                    model.Result = _calcService.Divide(model.FirstVal, model.SecondVal);
                }
            }
            return View("Index", model);
        }
        [HttpPost("pow")]
        public IActionResult Pow(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = _calcService.Pow(model.FirstVal, model.SecondVal);
            }
            return View("Index", model);
        }


        [HttpPost("root")]
        public IActionResult Root(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.FirstVal > 0)
                {
                    model.Result = _calcService.Root(model.FirstVal, model.SecondVal);
                }
                else
                {
                    ModelState.AddModelError("Eval", "Invalid expression.");
                }
            }
            return View("Index", model);
        }

        [HttpGet("evaluate")]
        public IActionResult Evaluate(CalcModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Result = _calcService.Evaluate(model.Eval, _parser);
                }
                catch
                {
                    ModelState.AddModelError("Eval", "Invalid expression.");
                }
            }
            return View("Index", model);
        }
    }
}
