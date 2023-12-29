using APISample.UI.ApiBaglanti;
using APISample.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.UI.Controllers
{
    public class KargoIslemleriController : Controller
    {
        //KargoBaglantiServis _api;
        //GenelSayfaBaglantiServis _genelapi;

        //public KargoIslemleriController(KargoBaglantiServis api, GenelSayfaBaglantiServis genelapi)
        //{
        //    _api = api;
        //    _genelapi = genelapi;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    // tum ciroyu gosteren bir data daha cekelim
        //    //var datas = _api.KargoGetir();
        //    //var ciroShipper = await _genelapi.KargoIslemleriAnasayfaIcınKargoVeTumCiroGetir();

        //    //ViewBag.liste = ciroShipper.KargoListe;
        //    //ViewBag.ciro = ciroShipper.Ciro;

        //    return View();
        //}

        //[HttpGet]
        //public void KargoSil(int id)
        //{


        //    //return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> YeniKargoEkle()
        //{


        //    return  View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> VeriEkle(ShipperDTO dto)
        //{

        //    var donendeger = await _api.KargoEkle(dto);
        //    TempData["sonuc"] = donendeger;
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> KargoDuzenle(int id)
        //{
        //    var sonuc = await _api.IdGoreKargoCek(id);

        //    return View(sonuc);
        //}

        //[HttpPost]
        //public async Task<IActionResult> KargoDuzenle(ShipperDTO dto)
        //{
        //    // var sonuc = await _api.(dto);

        //    // return View(sonuc);
        //    // kargo düzenleme apisini cagir
        //    TempData["sonuc"] = "veriler düzenlendi.";
        //    return RedirectToAction("Index");

        //}


    }
}
