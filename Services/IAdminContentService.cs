using DevBlog.AdminCli.Dtos;
using RestSharp;

namespace DevBlog.AdminCli.Services
{
    public interface IAdminContentService
    {
        IRestResponse Publish(PublishContentDto contentForPublish);

        IRestResponse Update(string id, UpdateContentDto contentForUpdate);

        IRestResponse Delete(string id);
    }
}