using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend1.Models;
using Backend1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend1.Controllers
{
    public class CalcController : Controller
    {
        private readonly ICalcService calcService;
        private readonly IRNGService rngService;

        public CalcController(ICalcService calcService, IRNGService rngService)
        {
            this.calcService = calcService;
            this.rngService = rngService;
        }

        public ActionResult PassUsingViewData()
        {
            var a = this.rngService.Number(-1000, 1001);
            var b = this.rngService.Number(-1000, 1001);

            this.ViewData["A"] = a;
            this.ViewData["B"] = b;
            this.ViewData["Add"] = calcService.Add(a, b);
            this.ViewData["Sub"] = calcService.Sub(a, b);
            this.ViewData["Mul"] = calcService.Mul(a, b);
            if (b == 0)
            {
                this.ViewData["Div"] = "Division by zero";
            }
            else
            {
                this.ViewData["Div"] = calcService.Div(a, b);
            }

            return this.View();
        }

        public ActionResult PassUsingViewBag()
        {
            var a = this.rngService.Number(-1000, 1001);
            var b = this.rngService.Number(-1000, 1001);

            this.ViewBag.A = a;
            this.ViewBag.B = b;
            this.ViewBag.Add = calcService.Add(a, b);
            this.ViewBag.Sub = calcService.Sub(a, b);
            this.ViewBag.Mul = calcService.Mul(a, b);
            if (b == 0)
            {
                this.ViewBag.Div = "Division by zero";
            }
            else
            {
                this.ViewBag.Div = calcService.Div(a, b);
            }

            return this.View();
        }

        public ActionResult PassUsingModel()
        {
            var a = this.rngService.Number(-1000, 1001);
            var b = this.rngService.Number(-1000, 1001);
            var model = new CalcViewModel
            {
                A = a,
                B = b,
                Add = this.calcService.Add(a, b),
                Sub = this.calcService.Sub(a, b),
                Mul = this.calcService.Mul(a, b),
            };

            if (b == 0)
            {
                model.Div = "Division by zero";
            }
            else
            {
                model.Div = this.calcService.Div(a, b);
            }

            return this.View(model);
        }

        public ActionResult AccessServiceDirectly()
        {
            return this.View();
        }
    }
}
