using System;
using CommandLine;
using DevBlog.AdminCli.Options;
using DevBlog.AdminCli.Protos;
using DevBlog.AdminCli.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevBlog.AdminCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = GetConfiguredServices();

            Parser.Default.ParseArguments<PublishOptions, UpdateOptions, DeleteOptions>(args)
                .MapResult(
                    (PublishOptions publishOptions) => {
                        var contentService = services.GetService<IContentService>();

                        var publishRequest = new PublishRequest() {
                            Id = publishOptions.Id,
                            Title = publishOptions.Title,
                            Url = publishOptions.Url,
                            Summary = publishOptions.Summary,
                            ImageUrl = publishOptions.ImageUrl,
                            Format = publishOptions.Format,
                            Hidden = publishOptions.Hidden
                        };

                        var result = contentService.Publish(publishRequest);

                        if (result.Success)
                        {
                            Console.WriteLine("Published content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error publishing content: {result.Message}");
                        }

                        return 0;
                    },
                    (UpdateOptions updateOptions) => {
                        var contentService = services.GetService<IContentService>();

                        var updateRequest = new UpdateRequest() {
                            Id = updateOptions.Id,
                            Title = updateOptions.Title,
                            Url = updateOptions.Url,
                            Summary = updateOptions.Summary,
                            ImageUrl = updateOptions.ImageUrl,
                            Format = updateOptions.Format,
                            Hidden = updateOptions.Hidden
                        };

                        var result = contentService.Update(updateRequest);

                        if (result.Success)
                        {
                            Console.WriteLine("Updated content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error updating content: {result.Message}");
                        }

                        return 0;
                    },
                    (DeleteOptions deleteOptions) => {
                        var contentService = services.GetService<IContentService>();

                        var deleteRequest = new DeleteRequest() {
                            Id = deleteOptions.Id
                        };

                        var result = contentService.Delete(deleteRequest);

                        if (result.Success)
                        {
                            Console.WriteLine("Deleted content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error deleting content: {result.Message}");
                        }

                        return 0;
                    },
                    err => 1
                );
        }

        private static ServiceProvider GetConfiguredServices()
        {
            return new ServiceCollection()
                .AddSingleton<IContentService, ContentService>()
                .BuildServiceProvider();
        }
    }
}
