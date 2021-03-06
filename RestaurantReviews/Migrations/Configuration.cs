using RestaurantReviews.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestaurantReviews.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantReviewsDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RestaurantReviewsDb context)
        {
            Restaurant[] restaurants = new Restaurant[]
            {
                new Restaurant { Name = "Cinnamon Club", Country = "UK", City = "London"},
                new Restaurant { Name = "Marrakesh", Country = "USA", City = "D.C."},
                new Restaurant { Name = "The House of Eliot", Country = "Belgium", City = "Ghent",
                                 Reviews = new RestaurantReview[] {
                                    new RestaurantReview { Body = "Wonderful Service",Rating = 10,
                                                           Name = "Ted" } } }
            };
            context.Restaurants.AddOrUpdate( r => r.Name ,restaurants);
            for (int i = 1; i <= 200; i++)
            {
                context.Restaurants.AddOrUpdate( r => r.Name, new Restaurant
                {
                    Name = i.ToString(),
                    Country = "None",
                    City = "None"
                });
            }
        }
    }
}
