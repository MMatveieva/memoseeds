﻿using System.Collections.Generic;
using System.IO;
using memoseeds.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace memoseeds.Controllers
{
    [Route("purchase")]
    [ApiController]
    public class PaymentController : Controller
    {
        private static PurchaseConfig purchaseConfig; 
        private static Dictionary<string, List<Purchase>> countryToPurchases = null;
        static PaymentController()
        {
            string configJSON = null;
            string dataJSON = null;
            string purchaseRepoPath = System.Environment.CurrentDirectory;
            using (
                StreamReader
                configFile = new StreamReader(purchaseRepoPath + "\\Repositories\\Purchase\\config.json"),
                dataFile = new StreamReader(purchaseRepoPath + "\\Repositories\\Purchase\\data.json"))
            {
                configJSON = configFile.ReadToEnd();
                dataJSON = dataFile.ReadToEnd();
            }
            PaymentController.purchaseConfig = JsonConvert.DeserializeObject<PurchaseConfig>(configJSON);
            PaymentController.countryToPurchases = JsonConvert.DeserializeObject<Dictionary<string, List<Purchase>>>(dataJSON);
            setupIds(PaymentController.countryToPurchases);
        }
        private static void setupIds(Dictionary<string, List<Purchase>> d)
        {
            foreach (string key in d.Keys)
            {
                int i = -1;
                foreach (Purchase p in d[key])
                {
                    p.Id = key + (++i);
                }
            }
        }

        [HttpPost("/options")]
        public string allPurchases(UserInfo info)
        {
            return info.country;
        }

        [HttpGet("/foo")]
        public string foo()
        {
            return "foo";
        }

        [HttpGet("/login")]
        public JsonResult Login()
        {
            //User u = new User()
            //{ 
            //    Username = "kovalenko",
            //    Password = "12345",
            //    Money = 32,
            //    Email = "ruskov004@gmail.com"

            //};

            //db.Users.Add(u);
            //db.SaveChanges();
            return Json("hello");
        }
    }

    
}