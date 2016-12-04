using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    class DbInitializer : DropCreateDatabaseAlways<SmartParkContext>
    {

        protected override void Seed(SmartParkContext context)
        {

            //USERS
            User user = new User()
            {
                Id = 1,
                Pseudo = "SkyLi7h",
                Email = "SkyLi7h@gmail.com",
                Password = "123456789",
                PhoneNumber = "0496893327"                                             
            };
            context.Users.Add(user);
            User user2 = new User()
            {
                Id = 2,
                Pseudo = "Yolo",
                Email = "Yolo@gmail.com",
                Password = "987654321",
                PhoneNumber = "0496871236"
            };
            context.Users.Add(user2);

            //PLACES
            Place place = new Place()
            {
                Id = 1,
                Name = "Saint-Servais",              
            };
            context.Places.Add(place);

            Place place2 = new Place()
            {
                Id = 2,
                Name = "Bouge"
            };
            context.Places.Add(place2);

            //PARKINGS
            Parking parking = new Parking()
            {
                Id = 1,
                Name = "Mon parking 1",
                Street = "Chaussée de Waterloo",
                Number = "71",
                Picture = "***",
                Description = "Mon premier parking à louer",
                Longitude = 154,
                Latitude = 87,
                Place = place,
                User = user
            };
            context.Parkings.Add(parking);

            //Annoucement
            Announcement announcement = new Announcement()
            {
                Id = 1,
                Title = "Mon beau park",
                Price = 10,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                Parking = parking,
                User = user              
            };
            context.Annoucements.Add(announcement);

            //Reporting
            Reporting reporting = new Reporting()
            {
                Id = 1,
                Date = DateTime.Today,
                Announce = announcement,
                User = user2
            };
            context.Reportings.Add(reporting);


            context.SaveChanges();
        }
    }
}
