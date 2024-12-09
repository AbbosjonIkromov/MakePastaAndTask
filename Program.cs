using System.Net.Http.Headers;

namespace asinxronniy_programirovaniya
{

    class Program
    {
        static async Task Main(string[] args)
        {
            string basePath = @"C:\Users\Lenovo 5i Pro\source\repos\asinxronniy_programmirovaniya";
            string sourcePath = Path.Combine(basePath, "data.txt");
            string destinationPath = Path.Combine(basePath, "dataCopy.txt");

            await ExecuteTask(sourcePath, destinationPath);

        }
        #region MakePasta
        static async Task MakePasta()
        {
            var chickenTask = MakeChickenAsync();
            var boilChicken = BoilChickenAsync();

            await DrinkCoffee();

            await chickenTask;
            await boilChicken;

            var design = MakeDesign();
            await ListenMusic();

            await design;

            await TasteMeal();

        }
        static async Task MakeChickenAsync()
        {
            Console.WriteLine("Started make chicken:");
            await Task.Delay(2000);
            Console.WriteLine("Finished make chicken");
        }
        static async Task BoilChickenAsync()
        {
            Console.WriteLine("Started boiling chicken:");
            await Task.Delay(2500);
            Console.WriteLine("Finished boiling chicken");

        }
        static async Task DrinkCoffee()
        {
            Console.WriteLine("Started dringking coffee");
            await Task.Delay(1500);
            Console.WriteLine("Finished dringking coffee");
        }

        static async Task MakeDesign()
        {
            Console.WriteLine("Started make design:");
            await Task.Delay(2000);
            Console.WriteLine("Finished make design");
        }
        static async Task ListenMusic()
        {
            Console.WriteLine("Started listen music:");
            await Task.Delay(1500);
            Console.WriteLine("Finished listen music");
        }
        static async Task TasteMeal()
        {
            Console.WriteLine("Started taste meal:");
            await Task.Delay(2000);
            Console.WriteLine("Finished taste meal");
        }
        #endregion

        #region ExucuteTask
        static async Task ExecuteTask(string sourcePath, string destinationPath)
        {
            var task1 = ReadFileAsync(sourcePath);
            var task2 = CreateNewFile(destinationPath);

            await Task.WhenAll(task1, task2);
            var task3 = CopyFileAndCountAAsync(sourcePath, destinationPath);

            int countA = await task3;
            Console.WriteLine($"destionatonPath: {destinationPath}\nKo'chirilgan text da a lar soni: {countA}");

        }
        static async Task<string> ReadFileAsync(string sourcePath)
        {
            Console.WriteLine("READFILEASYNC ISHGA TUSHDI");
            try
            {
                using (var reader = new StreamReader(sourcePath))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message );
                return "fileni topa oladi";
            }
            


        }
        static async Task CreateNewFile(string dectinationPath)
        {
            Console.WriteLine("CREATENEWFILE ISHGA TUSHDI");
            if (!File.Exists(dectinationPath))
            {
                File.Create(dectinationPath).Close()    ;
                Console.WriteLine("Yangi file yaratildi!");
            }
            else
            {
                Console.WriteLine("File Mavjud!");
            }
        }
        static async Task<int> CopyFileAndCountAAsync(string sourcePath, string destinationPath)
        {
            Console.WriteLine("COPYFILEANDCOUNTAASYNC ISHGA TUSHDI");
            int countA = 0;
            using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                using (var destinationStream = new FileStream(destinationPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var reader = new StreamReader(sourceStream))
                    using (var writer = new StreamWriter(destinationStream))
                    {
                        string content = await reader.ReadToEndAsync();

                        foreach (char c in content)
                        {
                            if (c == 'a' || c == 'A')
                            {
                                ++countA;
                            }
                        }

                        await writer.WriteAsync(content);
                    }

                }
            }

            return countA;
        }
        #endregion

    }
}