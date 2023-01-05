using Management.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Management.Persistence {
    public static class DBInitializer {
        public static void Initialize(ManagementDbContext context) {
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if (!context.Services.Any())
            //{
            //    context.ServiceCategories.AddRange(
            //        new ServiceCategory
            //        {
            //            ServiceCategoryName = "Category 1",
            //            TimeSlotSize = new DateTime(2022, 11, 16, 0, 30, 0)
            //        },
            //        new ServiceCategory
            //        {
            //            ServiceCategoryName = "Category 12",
            //            TimeSlotSize = new DateTime(2022, 11, 16, 0, 45, 0)
            //        }
            //        );
            //}

            //if (!context.Specializations.Any())
            //{
            //    context.Specializations.AddRange(
            //        new Specialization
            //        {
            //            SpecializationName = "Specialization 1",
            //        },
            //        new Specialization
            //        {
            //            SpecializationName = "Specialization 2"
            //        }
            //        );
            //}

            //if (!context.Services.Any())
            //{
            //    context.Services.AddRange(
            //        new Service { 
            //            ServiceCategoryId = 1,
            //            ServiceName = "Service name 1",
            //            ServicePrice = 10.0,
            //            SpecializationId = 1
            //        },
            //        new Service
            //        {
            //            ServiceCategoryId = 2,
            //            ServiceName = "Service name 2",
            //            ServicePrice = 20.5,
            //            SpecializationId = 2
            //        }
            //        );
            //}
            //context.SaveChanges();
        }
    }
}
