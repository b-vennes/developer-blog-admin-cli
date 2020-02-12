using System;
using System.Net.Http;
using System.Threading.Tasks;
using DevBlog.AdminCli.Protos;
using Grpc.Core;
using Grpc.Net.Client;

namespace DevBlog.AdminCli.Services
{
    public class ContentService : IContentService
    {
        private const string GrpcServer = "http://localhost:7777";

        private Content.ContentClient _client;

        public Result Delete(DeleteRequest deleteRequest)
        {
            try
            {
                var client = GetClient();
                var result = client.Delete(deleteRequest);

                return result;
            }
            catch (RpcException rpcException)
            {
                return new Result() {
                    Success = false,
                    Message = $"RPC failure: {rpcException.Message}"
                };
            }
            catch (Exception ex)
            {
                return new Result() {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public Result Publish(PublishRequest publishRequest)
        {
            try
            {
                var client = GetClient();
                var result = client.Publish(publishRequest);

                return result;
            }
            catch (RpcException rpcException)
            {
                return new Result() {
                    Success = false,
                    Message = $"RPC failure: {rpcException.Message}"
                };
            }
            catch (Exception ex)
            {
                return new Result() {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public Result Update(UpdateRequest updateRequest)
        {
            try
            {
                var client = GetClient();
                var result = client.Update(updateRequest);

                return result;
            }
            catch (RpcException rpcException)
            {
                return new Result() {
                    Success = false,
                    Message = $"RPC failure: {rpcException.Message}"
                };
            }
            catch (Exception ex)
            {
                return new Result() {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        private Content.ContentClient GetClient()
        {
            if (_client == null)
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

                var channel = GrpcChannel.ForAddress(GrpcServer);
                _client = new Content.ContentClient(channel);
            }
            
            return _client;
        }
    }
}