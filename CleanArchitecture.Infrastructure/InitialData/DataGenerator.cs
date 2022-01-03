using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VehicleData.Domain.Models;
using VehicleData.Infrastructure.Context;

namespace VehicleData.Infrastructure.InitialData
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VehicleStoreDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<VehicleStoreDbContext>>()))
            {
                // Look for any board games.
                if (context.Vehicles.Any())
                {
                    return;   // Data was already seeded
                }

                context.Vehicles.AddRange(
                    new Vehicle
                    {
                        Id = 1,
                        Make = "Audi",
                        Model = "Q5",
                        Year = 2021
                    },
                    new Vehicle
                    {
                        Id = 2,
                        Make = "Audi",
                        Model = "Q7",
                        Year = 2017
                    },
                    new Vehicle
                    {
                        Id = 3,
                        Make = "BMW",
                        Model = "X1",
                        Year = 2019
                    },
                    new Vehicle
                    {
                        Id = 4,
                        Make = "Audi",
                        Model = "Q3",
                        Year = 2021
                    },
                    new Vehicle
                    {
                        Id = 5,
                        Make = "BMW",
                        Model = "X2",
                        Year = 2021
                    },
                    new Vehicle
                    {
                        Id = 6,
                        Make = "BMW",
                        Model = "X5",
                        Year = 2021
                    },
                    new Vehicle
                    {
                        Id = 7,
                        Make = "BMW",
                        Model = "X4",
                        Year = 2017
                    });

                context.SaveChanges();
            }
        }
    }
}
