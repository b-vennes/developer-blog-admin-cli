using System.Threading.Tasks;
using DevBlog.AdminCli.Protos;

namespace DevBlog.AdminCli.Services
{
    public interface IContentService
    {
        Result Publish(PublishRequest publishRequest);

        Result Update(UpdateRequest updateRequest);

        Result Delete(DeleteRequest deleteRequest);
    }
}