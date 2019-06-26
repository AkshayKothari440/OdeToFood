using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData; // add for fetch Id
       [TempData]
        public string Message { get; set; } // add for show message "Restaurant Saved!" 
        public Restaurant Restaurant { get; set; }
        public DetailModel(IRestaurantData restaurantData) //add for fetch Id
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            //Restaurant = new Restaurant();
            //Restaurant.Id = restaurantId;
            if(Restaurant==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}