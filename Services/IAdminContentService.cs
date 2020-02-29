using DevBlog.AdminCli.Dtos;
using RestSharp;

namespace DevBlog.AdminCli.Services
{
    public interface IAdminContentService
    {
        IRestResponse Publish(PublishContentDto contentForPublish, string passcode);

        IRestResponse Update(string id, UpdateContentDto contentForUpdate, string passcode);

        IRestResponse Delete(string id, string passcode);
    }
}