// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/test_service.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class testing
{
  static readonly string __ServiceName = "testing";

  static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (message is global::Google.Protobuf.IBufferMessage)
    {
      context.SetPayloadLength(message.CalculateSize());
      global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
      context.Complete();
      return;
    }
    #endif
    context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
  }

  static class __Helper_MessageCache<T>
  {
    public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
  }

  static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
  {
    #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
    if (__Helper_MessageCache<T>.IsBufferMessage)
    {
      return parser.ParseFrom(context.PayloadAsReadOnlySequence());
    }
    #endif
    return parser.ParseFrom(context.PayloadAsNewBuffer());
  }

  static readonly grpc::Marshaller<global::TestReq> __Marshaller_TestReq = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TestReq.Parser));
  static readonly grpc::Marshaller<global::TestResp> __Marshaller_TestResp = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::TestResp.Parser));

  static readonly grpc::Method<global::TestReq, global::TestResp> __Method_TestWorkUnary = new grpc::Method<global::TestReq, global::TestResp>(
      grpc::MethodType.Unary,
      __ServiceName,
      "TestWorkUnary",
      __Marshaller_TestReq,
      __Marshaller_TestResp);

  static readonly grpc::Method<global::TestReq, global::TestResp> __Method_TestWorkServerStream = new grpc::Method<global::TestReq, global::TestResp>(
      grpc::MethodType.ServerStreaming,
      __ServiceName,
      "TestWorkServerStream",
      __Marshaller_TestReq,
      __Marshaller_TestResp);

  static readonly grpc::Method<global::TestReq, global::TestResp> __Method_TestWorkClientStream = new grpc::Method<global::TestReq, global::TestResp>(
      grpc::MethodType.ClientStreaming,
      __ServiceName,
      "TestWorkClientStream",
      __Marshaller_TestReq,
      __Marshaller_TestResp);

  static readonly grpc::Method<global::TestReq, global::TestResp> __Method_TestWorkBidirectionalStream = new grpc::Method<global::TestReq, global::TestResp>(
      grpc::MethodType.DuplexStreaming,
      __ServiceName,
      "TestWorkBidirectionalStream",
      __Marshaller_TestReq,
      __Marshaller_TestResp);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::TestServiceReflection.Descriptor.Services[0]; }
  }

  /// <summary>Client for testing</summary>
  public partial class testingClient : grpc::ClientBase<testingClient>
  {
    /// <summary>Creates a new client for testing</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    public testingClient(grpc::ChannelBase channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for testing that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    public testingClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    protected testingClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    protected testingClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    public virtual global::TestResp TestWorkUnary(global::TestReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return TestWorkUnary(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual global::TestResp TestWorkUnary(global::TestReq request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_TestWorkUnary, null, options, request);
    }
    public virtual grpc::AsyncUnaryCall<global::TestResp> TestWorkUnaryAsync(global::TestReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return TestWorkUnaryAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncUnaryCall<global::TestResp> TestWorkUnaryAsync(global::TestReq request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_TestWorkUnary, null, options, request);
    }
    public virtual grpc::AsyncServerStreamingCall<global::TestResp> TestWorkServerStream(global::TestReq request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return TestWorkServerStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncServerStreamingCall<global::TestResp> TestWorkServerStream(global::TestReq request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncServerStreamingCall(__Method_TestWorkServerStream, null, options, request);
    }
    public virtual grpc::AsyncClientStreamingCall<global::TestReq, global::TestResp> TestWorkClientStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return TestWorkClientStream(new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncClientStreamingCall<global::TestReq, global::TestResp> TestWorkClientStream(grpc::CallOptions options)
    {
      return CallInvoker.AsyncClientStreamingCall(__Method_TestWorkClientStream, null, options);
    }
    public virtual grpc::AsyncDuplexStreamingCall<global::TestReq, global::TestResp> TestWorkBidirectionalStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return TestWorkBidirectionalStream(new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    public virtual grpc::AsyncDuplexStreamingCall<global::TestReq, global::TestResp> TestWorkBidirectionalStream(grpc::CallOptions options)
    {
      return CallInvoker.AsyncDuplexStreamingCall(__Method_TestWorkBidirectionalStream, null, options);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    protected override testingClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new testingClient(configuration);
    }
  }

}
#endregion
