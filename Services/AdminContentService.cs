using DevBlog.AdminCli.Dtos;
using RestSharp;

namespace DevBlog.AdminCli.Services
{
    public class AdminContentService : IAdminContentService
    {
        private const string AdminContentApiUrl = "http://localhost:7777/api/admin/content";
        private readonly IRestClient _restClient;

        public AdminContentService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IRestResponse Delete(string id)
        {
            var request = new RestRequest($"{AdminContentApiUrl}/{id}");

            return _restClient.Delete(request);
        }

        public IRestResponse Publish(PublishContentDto contentForPublish)
        {
            var request = new RestRequest(AdminContentApiUrl);
            request.AddJsonBody(contentForPublish);

            return _restClient.Post(request);
        }

        public IRestResponse Update(string id, UpdateContentDto contentForUpdate)
        {
            var request = new RestRequest($"{AdminContentApiUrl}/{id}");
            request.AddJsonBody(contentForUpdate);

            return _restClient.Put(request);
        }
    }
}