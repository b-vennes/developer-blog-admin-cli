using System;
using System.Net;
using CommandLine;
using DevBlog.AdminCli.Dtos;
using DevBlog.AdminCli.Options;
using DevBlog.AdminCli.Services;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;

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
                        var contentService = services.GetService<IAdminContentService>();

                        var publishRequest = new PublishContentDto() {
                            Id = publishOptions.Id,
                            Title = publishOptions.Title,
                            Url = publishOptions.Url,
                            Summary = publishOptions.Summary,
                            ImageUrl = publishOptions.ImageUrl,
                            Format = publishOptions.Format,
                            Hidden = publishOptions.Hidden
                        };

                        var result = contentService.Publish(publishRequest, publishOptions.Passcode);

                        if (result.StatusCode == HttpStatusCode.NoContent)
                        {
                            Console.WriteLine("Published content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error publishing content: Status Message -- {result.StatusDescription}, Message -- {result.Content}");
                        }

                        return 0;
                    },
                    (UpdateOptions updateOptions) => {
                        var contentService = services.GetService<IAdminContentService>();

                        var updateRequest = new UpdateContentDto() {
                            Title = updateOptions.Title,
                            Url = updateOptions.Url,
                            Summary = updateOptions.Summary,
                            ImageUrl = updateOptions.ImageUrl,
                            Format = updateOptions.Format,
                            Hidden = updateOptions.Hidden
                        };

                        var result = contentService.Update(updateOptions.Id, updateRequest, updateOptions.Passcode);

                        if (result.StatusCode == HttpStatusCode.NoContent)
                        {
                            Console.WriteLine("Updated content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error publishing content: Status Message -- {result.StatusDescription}, Message -- {result.Content}");
                        }

                        return 0;
                    },
                    (DeleteOptions deleteOptions) => {
                        var contentService = services.GetService<IAdminContentService>();

                        var result = contentService.Delete(deleteOptions.Id, deleteOptions.Passcode);

                        if (result.StatusCode == HttpStatusCode.NoContent)
                        {
                            Console.WriteLine("Deleted content successfully!");
                        }
                        else 
                        {
                            Console.WriteLine($"Error publishing content: Status Message -- {result.StatusDescription}, Message -- {result.Content}");
                        }

                        return 0;
                    },
                    err => 1
                );
        }

        private static ServiceProvider GetConfiguredServices()
        {
            return new ServiceCollection()
                .AddSingleton<IRestClient, RestClient>()
                .AddSingleton<IAdminContentService, AdminContentService>(s => {
                    var restClient = s.GetService<IRestClient>();
                    return new AdminContentService(restClient);
                })
                .BuildServiceProvider();
        }
    }
}
