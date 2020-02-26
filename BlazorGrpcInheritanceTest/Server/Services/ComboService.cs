using BlazorGrpcInheritanceTest.Shared;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGrpcInheritanceTest.Server.Services
{
    public class ComboService : ITextService, INumberService
    {
        ValueTask<TextMessage> IDataService<TextMessage>.GetItemAsync(CallContext context)
        {
            return new ValueTask<TextMessage>(new TextMessage
            {
                Message = "This is text message",
                ServiceName = nameof(TextService)
            });
        }

        ValueTask<NumberMessage> IDataService<NumberMessage>.GetItemAsync(CallContext context)
        {
            return new ValueTask<NumberMessage>(new NumberMessage
            {
                Message = 12345,
                ServiceName = nameof(NumberService)
            });
        }
    }
}
