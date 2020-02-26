using BlazorGrpcInheritanceTest.Shared;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using ProtoBuf.Grpc.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorGrpcInheritanceTest.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        protected async Task TestGrpc()
        {
            var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
            using (var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient }))
            {
                var textClient = channel.CreateGrpcService<ITextService>();
                var textResponse = await textClient.GetItemAsync();
                Console.WriteLine($"Client: {typeof(ITextService).Name}, Message: {textResponse.Message}, ServiceName: {textResponse.ServiceName}");

                var numberClient = channel.CreateGrpcService<INumberService>();
                var numberResponse = await numberClient.GetItemAsync();
                Console.WriteLine($"Client: {typeof(INumberService).Name}, Message: {numberResponse.Message}, ServiceName: {numberResponse.ServiceName}");
            }
        }
    }
}
