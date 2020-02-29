using DevBlog.AdminCli.Dtos;
using RestSharp;

namespace DevBlog.AdminCli.Services
{
    public class AdminContentService : IAdminContentService
    {
        private const string AdminContentApiUrl = "http://localhost:7777/api/admin/content"; //"https://brandenvennes.com:2443/api/admin/content";
        private readonly IRestClient _restClient;

        public AdminContentService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public IRestResponse Delete(string id, string passcode)
        {
            var request = new RestRequest($"{AdminContentApiUrl}/{id}");
            request.AddHeader("Authorization", passcode);

            return _restClient.Delete(request);
        }

        public IRestResponse Publish(PublishContentDto contentForPublish, string passcode)
        {
            var request = new RestRequest(AdminContentApiUrl);
            request.AddJsonBody(contentForPublish);
            request.AddHeader("Authorization", passcode);

            return _restClient.Post(request);
        }

        public IRestResponse Update(string id, UpdateContentDto contentForUpdate, string passcode)
        {
            var request = new RestRequest($"{AdminContentApiUrl}/{id}");
            request.AddJsonBody(contentForUpdate);
            request.AddHeader("Authorization", passcode);

            return _restClient.Put(request);
        }
    }
}