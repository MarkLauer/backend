using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend2.Models;
using Backend2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend2.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalcService calcService;

        public CalcController(ICalcService calcService)
        {
            this.calcService = calcService;
        }

        public ActionResult Manual()
        {
            if (this.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {
                String first = this.Request.Form["First"];
                String second = this.Request.Form["Second"];
                
                if (!Int32.TryParse(first, out int number))
                {
                    this.ViewBag.FirstError = true;
                    return this.View();
                }
                
                if (!Int32.TryParse(second, out number))
                {
                    this.ViewBag.SecondError = true;
                    return this.View();
                }

                String action = this.Request.Form["Action"];
                var calc = new Int32();

                if (action.Equals("Add", StringComparison.OrdinalIgnoreCase))
                {
                    calc = this.calcService.Add(Convert.ToInt32(first), Convert.ToInt32(second));
                }

                if (action.Equals("Sub", StringComparison.OrdinalIgnoreCase))
                {
                    calc = this.calcService.Sub(Convert.ToInt32(first), Convert.ToInt32(second));
                }

                if (action.Equals("Mul", StringComparison.OrdinalIgnoreCase))
                {
                    calc = this.calcService.Mul(Convert.ToInt32(first), Convert.ToInt32(second));
                }

                if (action.Equals("Div", StringComparison.OrdinalIgnoreCase))
                {
                    if (second.Equals("0", StringComparison.OrdinalIgnoreCase))
                    {
                        this.ViewBag.DivisionError = true;
                        return this.View();
                    }
                    calc = this.calcService.Div(Convert.ToInt32(first), Convert.ToInt32(second));
                }

                var model = new CalcViewModel()
                {
                    First = first,
                    Second = second,
                    Operator = action,
                    Result = calc.ToString()
                };
                                
                return this.View(model);
            }

            return this.View();
        }

        public ActionResult ManualWithSeparateHandlers()
        {
            return this.View();
        }

        [HttpPost, ActionName("ManualWithSeparateHandlers")]
        [ValidateAntiForgeryToken]
        public ActionResult ManualWithSeparateHandlersConfirm()
        {
            
            String first = this.Request.Form["First"];
            String second = this.Request.Form["Second"];
                
            if (!Int32.TryParse(first, out int number))
            {
                this.ViewBag.FirstError = true;
                return this.View();
            }

            if (!Int32.TryParse(second, out number))
            {
                this.ViewBag.SecondError = true;
                return this.View();
            }

            String action = this.Request.Form["Action"];
            var calc = new Int32();

            if (action.Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Add(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Sub", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Sub(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Mul", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Mul(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Div", StringComparison.OrdinalIgnoreCase))
            {
                if (second.Equals("0", StringComparison.OrdinalIgnoreCase))
                {
                    this.ViewBag.DivisionError = true;
                    return this.View();
                }
                calc = this.calcService.Div(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            var model = new CalcViewModel()
            {
                First = first,
                Second = second,
                Operator = action,
                Result = calc.ToString()
            };

            return this.View(model);
            
        }

        public ActionResult ModelBindingInParameters()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModelBindingInParameters(String first, String second, String action)
        {
            if (!Int32.TryParse(first, out int number))
            {
                this.ViewBag.FirstError = true;
                return this.View();
            }

            if (!Int32.TryParse(second, out number))
            {
                this.ViewBag.SecondError = true;
                return this.View();
            }

            var calc = new Int32();

            if (action.Equals("Add", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Add(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Sub", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Sub(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Mul", StringComparison.OrdinalIgnoreCase))
            {
                calc = this.calcService.Mul(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            if (action.Equals("Div", StringComparison.OrdinalIgnoreCase))
            {
                if (second.Equals("0", StringComparison.OrdinalIgnoreCase))
                {
                    this.ViewBag.DivisionError = true;
                    return this.View();
                }
                calc = this.calcService.Div(Convert.ToInt32(first), Convert.ToInt32(second));
            }

            var model = new CalcViewModel()
            {
                First = first,
                Second = second,
                Operator = action,
                Result = calc.ToString()
            };

            return this.View(model);
        }

        public ActionResult ModelBindingInSeparateModel()
        {
            return this.View(new CalcViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModelBindingInSeparateModel(CalcViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (model.Operator.Equals("Add", StringComparison.OrdinalIgnoreCase))
                {
                    model.Result = this.calcService.Add(Convert.ToInt32(model.First), Convert.ToInt32(model.Second)).ToString();
                }

                if (model.Operator.Equals("Sub", StringComparison.OrdinalIgnoreCase))
                {
                    model.Result = this.calcService.Sub(Convert.ToInt32(model.First), Convert.ToInt32(model.Second)).ToString();
                }

                if (model.Operator.Equals("Mul", StringComparison.OrdinalIgnoreCase))
                {
                    model.Result = this.calcService.Mul(Convert.ToInt32(model.First), Convert.ToInt32(model.Second)).ToString();
                }

                if (model.Operator.Equals("Div", StringComparison.OrdinalIgnoreCase))
                {
                    if (model.Second.Equals("0", StringComparison.OrdinalIgnoreCase))
                    {
                        this.ModelState.AddModelError("Second", "Division by zero is forbidden");
                        return this.View(model);
                    }
                    model.Result = this.calcService.Div(Convert.ToInt32(model.First), Convert.ToInt32(model.Second)).ToString();
                }
                
                return this.View(model);
            }

            return this.View(model);
        }
    }
}
