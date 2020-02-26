using ProtoBuf;
using ProtoBuf.Grpc;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BlazorGrpcInheritanceTest.Shared
{
    [ServiceContract]
    public interface ITextService : IDataService<TextMessage>
    {

    }

    [ProtoContract]
    public class TextMessage
    {
        [ProtoMember(1)]
        public string Message { get; set; }

        [ProtoMember(2)]
        public string ServiceName { get; set; }
    }

    [ServiceContract]
    public interface INumberService : IDataService<NumberMessage>
    {

    }

    [ProtoContract]
    public class NumberMessage
    {
        [ProtoMember(1)]
        public int Message { get; set; }

        [ProtoMember(2)]
        public string ServiceName { get; set; }
    }

    public interface IDataService<TItem> where TItem : class, new()
    {
        ValueTask<TItem> GetItemAsync(CallContext context = default);
    }
}
