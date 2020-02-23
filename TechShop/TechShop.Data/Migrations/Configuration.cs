namespace TechShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TechShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TechShop.Data.TechShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechShop.Data.TechShopDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            CreateUser(context);// seed data user admin

            CreateProductCategorySample(context);//seed data productcategory
        }

        private void CreateUser(TechShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TechShopDbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TechShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "duongtuc",
                Email = "duongtuc@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "Duong Tuc"

            };
            if (manager.Users.Count(x => x.UserName == "duongtuc") == 0)
            {
                manager.Create(user, "123456$");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("duongtuc@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }

        }


        private void CreateProductCategorySample(TechShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
            {
                new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh",Status=true },
                 new ProductCategory() { Name="Viễn thông",Alias="vien-thong",Status=true },
                  new ProductCategory() { Name="Máy Tính",Alias="may-tinh",Status=true },
                   new ProductCategory() { Name="Điện Thoại",Alias="dien-thoai",Status=true }
            };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}
