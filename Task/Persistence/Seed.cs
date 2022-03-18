using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class Seed
{
    public static async Task SeedData(DataContext context)
    {
        // Doing this manually as the entities will create the Guid values
        if(!context.Categories.Any())
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Plumbing",
                    ParentCategoryId =  default(Guid)
                },
                new Category
                {
                    Name = "Electrical",
                    ParentCategoryId = default(Guid)
                },
                new Category
                {
                    Name = "Carpentry",
                    ParentCategoryId = default(Guid)
                },
                new Category
                {
                    Name = "Handyman",
                    ParentCategoryId = default(Guid)
                },
                new Category
                {
                    Name = "Building",
                    ParentCategoryId = default(Guid)
                }
            };

            categories.Add(new Category{
                    Name = "Bathroom Renovation",
                    ParentCategoryId =  categories.Find(category => category.Name == "Building").Id
            });

            await context.Categories.AddRangeAsync(categories);

            await context.SaveChangesAsync();
        }

        if(!context.Suburbs.Any())
        {
            var suburbs = new List<Suburb>
            {
                new Suburb
                {
                    Name = "Sydney",
                    PostCode = "2000"
                },
                new Suburb
                {
                    Name = "Bondi",
                    PostCode = "2026"
                },
                new Suburb
                {
                    Name = "Manly",
                    PostCode = "2095"
                },
                new Suburb
                {
                    Name = "Surry Hills",
                    PostCode = "2010"
                },
                new Suburb
                {
                    Name = "Newtown",
                    PostCode = "2042"
                }
            };

            await context.Suburbs.AddRangeAsync(suburbs);

            await context.SaveChangesAsync();
        }

        if(!context.Jobs.Any())
        {
            var jobs = new List<Job>
            {
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Sydney").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Plumbing").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Luke Skywalker",
                    ContactPhone = "0412345678",
                    ContactEmail = "luke@mailinator.com",
                    Price = 20,
                    Description = "Integer aliquam pulvinar odio et convallis. Integer id tristique ex. Aenean scelerisque massa vel est sollicitudin vulputate. Suspendisse quis ex eu ligula elementum suscipit nec a est. Aliquam a gravida diam. Donec placerat magna posuere massa maximus vehicula. Cras nisl ipsum, fermentum nec odio in, ultricies dapibus risus. Vivamus neque."
                },
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Bondi").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Electrical").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Darth Vader",
                    ContactPhone = "0422223333",
                    ContactEmail = "darth@mailinator.com",
                    Price = 30,
                    Description = "Praesent elit dui, blandit eget nisl sed, ornare pharetra urna. In cursus auctor tellus. Quisque ligula metus, viverra nec nibh ut, sagittis luctus tellus. Nulla egestas nibh ut diam vehicula, ut auctor lectus pharetra. Aliquam condimentum, erat eget vehicula eleifend, nulla risus consequat augue, quis convallis mi diam et dui."
                },
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Manly").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Carpentry").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Han Solo",
                    ContactPhone = "0498765432",
                    ContactEmail = "han@mailinator.com",
                    Price = 45,
                    Description = "Aliquam posuere est sit amet libero egestas tempus. Donec ut efficitur sapien. Sed molestie nec lacus malesuada suscipit. Aliquam suscipit nibh at posuere tempor. Etiam a sollicitudin felis. In et enim leo. Morbi vel imperdiet purus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam posuere auctor elit, id venenatis."
                },
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Surry Hills").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Handyman").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Kylo Ren",
                    ContactPhone = "0488770066",
                    ContactEmail = "kylo@mailinator.com",
                    Price = 15,
                    Description = "Proin semper consectetur mauris id commodo. In accumsan est ligula, id posuere libero placerat ac. Nunc non volutpat sem. Mauris gravida dictum eleifend. Praesent quis mattis arcu, rutrum sagittis diam. Nullam tempus sagittis diam, vel viverra nunc ultricies non. Sed at orci sem. Phasellus eget arcu hendrerit, congue metus ut, mollis tellus. Quisque gravida metus ut libero porta, sit amet rutrum odio porta. Fusce interdum est sed quam venenatis dictum. Integer ultrices est in odio semper dictum. Proin nec urna vel quam finibus maximus. "
                                + "Sed accumsan urna vitae libero luctus volutpat. Nulla eu sodales enim, vitae blandit ligula. Suspendisse at magna pellentesque, rhoncus orci quis, consequat diam. Donec pulvinar accumsan erat, quis hendrerit est ultricies vel. Vivamus felis justo, vulputate non urna sed, finibus semper ipsum. Cras mattis, est vel posuere mattis, turpis augue elementum massa, vitae accumsan nibh nisl nec lectus. Maecenas porta sagittis erat at consequat. Suspendisse fermentum rutrum bibendum. Donec tempor mollis massa vel egestas."
                                + "Morbi rutrum felis lacinia eros tincidunt scelerisque. Morbi aliquam porttitor sapien. Phasellus eu odio ac neque faucibus suscipit in at lectus. Maecenas et blandit arcu. Nullam sed sem neque. Nulla sit amet tristique nisl. Ut et pretium velit. Fusce consequat tincidunt fringilla. Nunc gravida libero sit amet augue viverra, a imperdiet odio dictum. Sed iaculis, metus vel rutrum convallis, quam ex commodo nibh, eget ultrices nisi eros eu massa. Ut iaculis maximus ligula, sed efficitur mauris bibendum sagittis. Curabitur et dolor mi. Proin lorem urna, porttitor quis lacus pharetra, ornare porta nulla. Sed ultricies feugiat nibh, et semper tellus aliquet sit amet. Cras faucibus scelerisque nisi, at vestibulum massa pharetra et."
                },
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Newtown").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Building").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Lando Calrissian",
                    ContactPhone = "0433335555",
                    ContactEmail = "lando@mailinator.com",
                    Price = 62,
                    Description = "Quisque blandit erat id mi tincidunt porta. Vivamus eleifend sagittis neque id maximus. Etiam molestie, massa ut tempus fermentum, augue nisi pulvinar nunc, id malesuada ipsum ipsum nec odio. Etiam et nisl facilisis, egestas massa eget, sagittis sapien. Curabitur eget consequat diam. Proin auctor rhoncus est, vitae imperdiet sem mollis."
                },
                new Job
                {
                    SuburbId = (await context.Suburbs.Where(suburb => suburb.Name == "Sydney").AsNoTracking().SingleOrDefaultAsync()).Id,
                    CategoryId = (await context.Categories.Where(category => category.Name == "Bathroom Renovation").AsNoTracking().SingleOrDefaultAsync()).Id,
                    ContactName = "Jabba TheHutt",
                    ContactPhone = "0411443322",
                    ContactEmail = "jabba@mailinator.com",
                    Price = 55,
                    Description = "Quisque blandit erat id mi tincidunt porta. Vivamus eleifend sagittis neque id maximus. Etiam molestie, massa ut tempus fermentum, augue nisi pulvinar nunc, id malesuada ipsum ipsum nec odio. Etiam et nisl facilisis, egestas massa eget, sagittis sapien. Curabitur eget consequat diam. Proin auctor rhoncus est, vitae imperdiet sem mollis."
                }
            };

            await context.Jobs.AddRangeAsync(jobs);

            await context.SaveChangesAsync();
        }
    }
}