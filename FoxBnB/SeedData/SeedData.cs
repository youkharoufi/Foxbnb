using FoxBnB.Data;
using FoxBnB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FoxBnB.SeedData
{
    public static class SeedData
    {

        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<string>() { "Client", "Owner" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role});
                }
            }
        }

        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager, DatabaseContext context)
        {
            Uri uri = new Uri("https://localhost:7187");
            var allUsers = await context.ApplicationUsers.ToListAsync();


            if (allUsers.Count == 0)
            {
                var users = new List<(ApplicationUser, string password)>
            {
                (new ApplicationUser {UserName="ykharoufi", Firstname="Youssef", Lastname="Kharoufi", PhoneNumber="0615482619", RoleName="Client", Email="youssef@foxbnb.com", ProfilePicUrl=$"{uri}images/youssef.avif"}, "Foxbnb123!"),
                (new ApplicationUser {UserName="emaurin", Firstname="Estelle", Lastname="Maurin", PhoneNumber="0776198423", RoleName="Owner", Email="estelle@foxbnb.com", ProfilePicUrl=$"{uri}images/estelle.jpg"}, "Foxbnb123!"),
                (new ApplicationUser {UserName="ldavidoff", Firstname="Lorenzo", Lastname="Davidoff", PhoneNumber="0537412563", RoleName="Owner", Email="lorenzo@foxbnb.com", ProfilePicUrl=$"{uri}images/lorenzo.avif"}, "Foxbnb123!"),

            };

                foreach (var (user, password) in users)
                {
                    var result = await userManager.CreateAsync(user, password);
                    if (result.Succeeded)
                    {
                        await userManager.FindByEmailAsync(user.Email);
                        await userManager.AddToRoleAsync(user, user.RoleName);
                    }

                }
            }
        }

        public static async Task SeedProperties(DatabaseContext context)
        {
            var allProperties = await context.Properties.ToListAsync();

            if (!allProperties.Any())
            { 
            var properties = new List<Property>()
                {
                    (new Property{ Id= Guid.NewGuid().ToString(), OwnerId="fff89ee6-4fef-44ac-a477-99030f4eb0a9", Type="Appartment", InfoParagraph=
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                        "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                        " Erat nam at lectus urna duis convallis. Ornare lectus sit amet est" +
                        " placerat in. Sit amet tellus cras adipiscing enim eu turpis egestas" +
                        " pretium. Tempor orci dapibus ultrices in iaculis nunc sed. Orci porta" +
                        " non pulvinar neque laoreet suspendisse. Donec ultrices tincidunt arcu" +
                        " non sodales neque. Cursus eget nunc scelerisque viverra mauris in." +
                        " Mauris a diam maecenas sed enim ut sem. Mattis pellentesque id nibh" +
                        " tortor id aliquet lectus. Bibendum at varius vel pharetra vel turpis" +
                        " nunc eget. Risus pretium quam vulputate dignissim suspendisse in est" +
                        " ante. Non enim praesent elementum facilisis leo. Nunc mi ipsum faucibus" +
                        " vitae aliquet. Vulputate mi sit amet mauris commodo. Ut placerat orci" +
                        " nulla pellentesque dignissim enim sit.", Price=2264.00, TotalSpace=140, FloorNumber=38,
                        NumberOfRooms=8, ParkingAvailable=true, Address="24 New Street Miami, OR 24560"}),

                    (new Property{Id= Guid.NewGuid().ToString(), OwnerId="436bcb1a-8463-49e2-b909-7c9a575be0fd", Type="Villa House", InfoParagraph=
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                        "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                        " Erat nam at lectus urna duis convallis. Ornare lectus sit amet est" +
                        " placerat in. Sit amet tellus cras adipiscing enim eu turpis egestas" +
                        " pretium. Tempor orci dapibus ultrices in iaculis nunc sed. Orci porta" +
                        " non pulvinar neque laoreet suspendisse. Donec ultrices tincidunt arcu" +
                        " non sodales neque. Cursus eget nunc scelerisque viverra mauris in." +
                        " Mauris a diam maecenas sed enim ut sem. Mattis pellentesque id nibh" +
                        " tortor id aliquet lectus. Bibendum at varius vel pharetra vel turpis" +
                        " nunc eget. Risus pretium quam vulputate dignissim suspendisse in est" +
                        " ante. Non enim praesent elementum facilisis leo. Nunc mi ipsum faucibus" +
                        " vitae aliquet. Vulputate mi sit amet mauris commodo. Ut placerat orci" +
                        " nulla pellentesque dignissim enim sit.", Price=1180.00, TotalSpace=540, FloorNumber=45,
                        NumberOfRooms=10, ParkingAvailable=true, Address="157 Swaggy Street Miami, OR 369852"}),

                    (new Property{Id= Guid.NewGuid().ToString(), OwnerId="0020216b-7473-491c-b131-2d6d5040c09a", Type="Penthouse", InfoParagraph=
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                        "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
                        " Erat nam at lectus urna duis convallis. Ornare lectus sit amet est" +
                        " placerat in. Sit amet tellus cras adipiscing enim eu turpis egestas" +
                        " pretium. Tempor orci dapibus ultrices in iaculis nunc sed. Orci porta" +
                        " non pulvinar neque laoreet suspendisse. Donec ultrices tincidunt arcu" +
                        " non sodales neque. Cursus eget nunc scelerisque viverra mauris in." +
                        " Mauris a diam maecenas sed enim ut sem. Mattis pellentesque id nibh" +
                        " tortor id aliquet lectus. Bibendum at varius vel pharetra vel turpis" +
                        " nunc eget. Risus pretium quam vulputate dignissim suspendisse in est" +
                        " ante. Non enim praesent elementum facilisis leo. Nunc mi ipsum faucibus" +
                        " vitae aliquet. Vulputate mi sit amet mauris commodo. Ut placerat orci" +
                        " nulla pellentesque dignissim enim sit.", Price=1460.00, TotalSpace=1200, FloorNumber=13,
                        NumberOfRooms=15, ParkingAvailable=true, Address="326 Ezeiy Street Miami, OR 369852"}),

                };

                await context.Properties.AddRangeAsync(properties);
                await context.SaveChangesAsync();
            }
        }

    }
}
