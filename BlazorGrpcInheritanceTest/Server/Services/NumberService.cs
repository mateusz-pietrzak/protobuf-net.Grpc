using BlazorGrpcInheritanceTest.Shared;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGrpcInheritanceTest.Server.Services
{
    public class NumberService : INumberService
    {
        public ValueTask<NumberMessage> GetItemAsync(CallContext context = default)
        {
            return new ValueTask<NumberMessage>(new NumberMessage
            {
                Message = 12345,
                ServiceName = nameof(NumberService)
            });
        }
    }
}
