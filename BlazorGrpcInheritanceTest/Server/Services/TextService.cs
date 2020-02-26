using BlazorGrpcInheritanceTest.Shared;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGrpcInheritanceTest.Server.Services
{
    public class TextService : ITextService
    {
        public ValueTask<TextMessage> GetItemAsync(CallContext context = default)
        {
            return new ValueTask<TextMessage>(new TextMessage
            {
                Message = "This is text message",
                ServiceName = nameof(TextService)
            });
        }
    }
}
