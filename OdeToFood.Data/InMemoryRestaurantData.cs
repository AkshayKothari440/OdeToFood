using OdeToFood.Core;
using System.Linq;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id=1, Name="Dominoze Pizza", Location="India", Cuisine=CuisineType.Indian},
                new Restaurant{Id=2, Name="DZ-Pizza", Location="America", Cuisine=CuisineType.Italian},
                new Restaurant{Id=3, Name="Studio Pizza", Location="Canada", Cuisine=CuisineType.Maxican}
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id); //id is incoming Id value
        }
        //using for Add new restaurant details v
        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;//only for using this line testing and devloping but not real time use this line
            return newRestaurant;
        }
        //using for Update restaurant details v
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant!= null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name=null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
        public Restaurant Delete(int Id)
        {
            int id = 0;
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant!=null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }

}
