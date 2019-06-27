using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<ListModel> logger;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)] 
        public string SearchTerm { get; set; } //Add 1
        public ListModel(IConfiguration config,IRestaurantData restaurantData,
            ILogger<ListModel> logger) /*Fetch the restorent(Iresturantdata restaurantdata)*/
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
      
        public void OnGet()
       //public void OnGet(searchTerm)
        {
            logger.LogError("Executing ListModel"); 
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            //Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}