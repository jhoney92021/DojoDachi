using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Dojodachi.Models;


namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Dachi>("Billy") == null)
            {
                HttpContext.Session.SetObjectAsJson("Billy", new Dachi());
            }
            ViewBag.Billy = HttpContext.Session.GetObjectFromJson<Dachi>("Billy");            
            ViewBag.interactionResult = HttpContext.Session.GetString("interactionResult");

            return View("Index");
        }
        [HttpGet("Dachi/Interaction/{id}")]
        public IActionResult Interaction(string id)
        {
            string interaction = id;
            string interactionResult = null;
            Dachi Billy = HttpContext.Session.GetObjectFromJson<Dachi>("Billy");
            if(interaction == "Feed"){interactionResult = Billy.Feed();}
            if(interaction == "Play"){interactionResult = Billy.Play();}
            if(interaction == "Sleep"){interactionResult = Billy.Sleep();}
            if(interaction == "Work"){interactionResult = Billy.Work();}
            if(interaction == "Restart"){HttpContext.Session.Clear(); return RedirectToAction("Index");}
            HttpContext.Session.SetString("interactionResult", interactionResult); 
            HttpContext.Session.SetObjectAsJson("Billy",Billy);
            ViewBag.interactionResult = interactionResult;
            ViewBag.Billy = Billy;
            return View("Index");
        }
        [HttpGet("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }//CONTROLLER
    //INITIALIZING JSON 'OBJECTS'
    //INITIALIZING JSON 'OBJECTS'
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes the object to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    //INITIALIZING JSON 'OBJECTS'
    //INITIALIZING JSON 'OBJECTS'
}//NAMESPACE
