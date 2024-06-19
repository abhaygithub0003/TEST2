﻿using CurrencyExchange.Models;
using CurrencyExchange.Service;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    public class CurrencyConverterController : Controller
    {
        private readonly CurrencyConverterService _currencyConverterService;

        public CurrencyConverterController(CurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
        }
        public IActionResult Index()
        {
            var model = new CurrencyConversionModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CurrencyConversionModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = await _currencyConverterService.ConvertCurrencyAsync(model.Amount, model.FromCurrency, model.ToCurrency);
            }
            return View(model);
        }
    }
}