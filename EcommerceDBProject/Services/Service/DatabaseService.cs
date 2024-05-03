using EcommerceDBProject.EcomDbContext;
using EcommerceDBProject.Services.Interface;

namespace EcommerceDBProject.Services.Service
{
    public class DatabaseService : IDatabaseInterfae
    {
        public void ConvertExcelToSQL(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length == 4)
                    {
                        using(var db = new EcommerceDbprojectContext())
                        {
                            db.ProductCategories.Add(new ProductCategory
                            {
                                CategoryName = fields[1],
                                CategoryDescription = fields[2],
                                DateCreated = DateTime.Parse(fields[3])
                            });
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data format: {line}");
                    }
                }
            }
        }
    }
}
