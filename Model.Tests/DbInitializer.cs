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
                UserId = 1,
                Pseudo = "SkyLi7h",
                Email = "SkyLi7h@gmail.com",
                Password = "123456789",
                PhoneNumber = "0496893327"                                             
            };
            context.Users.Add(user);

            User user2 = new User()
            {
                UserId = 2,
                Pseudo = "Tom",
                Email = "Tom@gmail.com",
                Password = "987654321",
                PhoneNumber = "0496871236"
            };
            context.Users.Add(user2);

            User user3 = new User()
            {
                UserId = 3,
                Pseudo = "test",
                Email = "test@gmail.com",
                Password = "test",
                PhoneNumber = "0496871236"
            };
            context.Users.Add(user3);

            //PLACES
            Place place = new Place()
            {
                PlaceId = 1,
                Name = "Saint-Servais",              
            };
            context.Places.Add(place);

            Place place2 = new Place()
            {
                PlaceId = 2,
                Name = "Bouge"
            };
            context.Places.Add(place2);

            //PARKINGS
            Parking parking = new Parking()
            {
                ParkingId = 1,
                Name = "Mon parking 1",
                Street = "Rue marie henriette",
                Number = "13",
                Picture = "1",
                Description = "Grand parking privé à louer ! Idéalement situé ! Innocupé suite à la vente de notre voiture.",
                Longitude = 4.858328400000005,
                Latitude = 50.47062890000001,
                PlaceId = place.PlaceId,
                UserId = user.UserId
            };
            context.Parkings.Add(parking);

            Parking parking2 = new Parking()
            {
                ParkingId = 2,
                Name = "Parking 1",
                Street = "Chaussée de Waterloo",
                Number = "71",
                Picture = "2",
                Description = "Parking à louer à proximité de la mutuelle. Haut disponiblité. Contactez-moi pour plus d'infos !",
                Longitude = 4.848236300000053,
                Latitude = 50.4719308,
                PlaceId = place.PlaceId,
                UserId = user2.UserId
            };
            context.Parkings.Add(parking2);

            Parking parking3 = new Parking()
            {
                ParkingId = 3,
                Name = "Mon parking 21",
                Street = "Rue de bruxelles",
                Number = "10",
                Picture = "3",
                Description = "Beau grand parking situé près des facs. Seulement pour voiture. Plus d'infos ou de photo par mail.",
                Longitude = 4.863602600000036,
                Latitude = 50.46528010000001,
                PlaceId = place.PlaceId,
                UserId = user3.UserId
            };
            context.Parkings.Add(parking3);

            //Annoucement
            Announcement announcement = new Announcement()
            {
                AnnouncementId = 1,
                Title = "Grand parking à louer",
                Price = 10,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking.ParkingId     
            };
            context.Annoucements.Add(announcement);

            Announcement announcement2 = new Announcement()
            {
                AnnouncementId = 2,
                Title = "A ne pas rater !",
                Price = 12,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking2.ParkingId
            };
            context.Annoucements.Add(announcement2);

            Announcement announcement3 = new Announcement()
            {
                AnnouncementId = 3,
                Title = "A louer",
                Price = 25,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking3.ParkingId
            };
            context.Annoucements.Add(announcement3);

            Announcement announcement4 = new Announcement()
            {
                AnnouncementId = 4,
                Title = "Pour voiture uniquement",
                Price = 3,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking3.ParkingId
            };
            context.Annoucements.Add(announcement4);

            Announcement announcement5 = new Announcement()
            {
                AnnouncementId = 5,
                Title = "Venez-voir",
                Price = 8,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking2.ParkingId
            };
            context.Annoucements.Add(announcement5);

            Announcement announcement6 = new Announcement()
            {
                AnnouncementId = 6,
                Title = "Parking haute disponibilité",
                Price = 15,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking.ParkingId
            };
            context.Annoucements.Add(announcement6);

            Announcement announcement7 = new Announcement()
            {
                AnnouncementId = 7,
                Title = "Parking à louer",
                Price = 37,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking3.ParkingId
            };
            context.Annoucements.Add(announcement7);

            Announcement announcement8 = new Announcement()
            {
                AnnouncementId = 8,
                Title = "Jetez un coup d'oeuil",
                Price = 2,
                DateFrom = DateTime.Today.Date,
                DateTo = DateTime.Today.Date,
                Rented = false,
                ParkingId = parking.ParkingId
            };
            context.Annoucements.Add(announcement8);

            //Reporting
            Reporting reporting = new Reporting()
            {
                ReportingId = 1,
                Date = DateTime.Today,
                AnnouncementId = announcement.AnnouncementId
                
            };
            context.Reportings.Add(reporting);


            context.SaveChanges();
        }
    }
}
