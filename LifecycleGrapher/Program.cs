using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using LifecycleGrapher.Services;
using LifecycleGrapher.Parsers;
using LifecycleGrapher.Utilities;
using LifecycleGrapher.Models;

namespace LifecycleGrapher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var cmdArgs = new CommandLineArguments(args);

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();

                var apiSettings = new ApiSettings();
                configuration.GetSection("ApiSettings").Bind(apiSettings);

                var apiService = new ApiService(cmdArgs.Url, apiSettings.ApiUser, apiSettings.ApiPasswd, cmdArgs.ObjectName);
                var xmlParser = new XmlParser();
                var dotFileGenerator = new DotFileGenerator();

                // Retrieve XML data from API
                string xmlData = apiService.GetData();

                // Parse XML data
                var parsedData = xmlParser.ParseData(xmlData);

                // Generate DOT file content
                string dotContent = dotFileGenerator.GenerateDotFile(parsedData, cmdArgs.ObjectName);

                // Write DOT content to file
                FileHelper.WriteToFile($"{cmdArgs.ObjectName}.dot", dotContent);

                Console.WriteLine("DOT file generated successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
