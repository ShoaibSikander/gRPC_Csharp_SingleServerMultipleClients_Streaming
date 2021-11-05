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

  static readonly grpc::Marshaller<global::TestReq> __Marshaller_TestReq = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::TestReq.Parser.ParseFrom);
  static readonly grpc::Marshaller<global::TestResp> __Marshaller_TestResp = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::TestResp.Parser.ParseFrom);

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

  /// <summary>Base class for server-side implementations of testing</summary>
  [grpc::BindServiceMethod(typeof(testing), "BindService")]
  public abstract partial class testingBase
  {
    public virtual global::System.Threading.Tasks.Task<global::TestResp> TestWorkUnary(global::TestReq request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task TestWorkServerStream(global::TestReq request, grpc::IServerStreamWriter<global::TestResp> responseStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task<global::TestResp> TestWorkClientStream(grpc::IAsyncStreamReader<global::TestReq> requestStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    public virtual global::System.Threading.Tasks.Task TestWorkBidirectionalStream(grpc::IAsyncStreamReader<global::TestReq> requestStream, grpc::IServerStreamWriter<global::TestResp> responseStream, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static grpc::ServerServiceDefinition BindService(testingBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_TestWorkUnary, serviceImpl.TestWorkUnary)
        .AddMethod(__Method_TestWorkServerStream, serviceImpl.TestWorkServerStream)
        .AddMethod(__Method_TestWorkClientStream, serviceImpl.TestWorkClientStream)
        .AddMethod(__Method_TestWorkBidirectionalStream, serviceImpl.TestWorkBidirectionalStream).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  public static void BindService(grpc::ServiceBinderBase serviceBinder, testingBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_TestWorkUnary, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::TestReq, global::TestResp>(serviceImpl.TestWorkUnary));
    serviceBinder.AddMethod(__Method_TestWorkServerStream, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::TestReq, global::TestResp>(serviceImpl.TestWorkServerStream));
    serviceBinder.AddMethod(__Method_TestWorkClientStream, serviceImpl == null ? null : new grpc::ClientStreamingServerMethod<global::TestReq, global::TestResp>(serviceImpl.TestWorkClientStream));
    serviceBinder.AddMethod(__Method_TestWorkBidirectionalStream, serviceImpl == null ? null : new grpc::DuplexStreamingServerMethod<global::TestReq, global::TestResp>(serviceImpl.TestWorkBidirectionalStream));
  }

}
#endregion
