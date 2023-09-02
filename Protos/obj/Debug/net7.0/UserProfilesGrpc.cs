// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: UserProfiles.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Protos.UserProfiles {
  public static partial class UserProfiles
  {
    static readonly string __ServiceName = "userprofiles.UserProfiles";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest> __Marshaller_createuserprofile_CreateUserProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> __Marshaller_createuserprofile_CreateUserProfileResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest> __Marshaller_getuserprofile_GetUserProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> __Marshaller_getuserprofile_GetUserProfileResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest> __Marshaller_updateuserprofile_UpdateUserProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> __Marshaller_updateuserprofile_UpdateUserProfileResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest> __Marshaller_getselectedsurnamename_GetSelectedSurnameNameRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> __Marshaller_getselectedsurnamename_GetSelectedSurnameNameResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest, global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> __Method_registerUserProfile = new grpc::Method<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest, global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "registerUserProfile",
        __Marshaller_createuserprofile_CreateUserProfileRequest,
        __Marshaller_createuserprofile_CreateUserProfileResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest, global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> __Method_getUserProfile = new grpc::Method<global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest, global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getUserProfile",
        __Marshaller_getuserprofile_GetUserProfileRequest,
        __Marshaller_getuserprofile_GetUserProfileResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest, global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> __Method_updateUserProfile = new grpc::Method<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest, global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "updateUserProfile",
        __Marshaller_updateuserprofile_UpdateUserProfileRequest,
        __Marshaller_updateuserprofile_UpdateUserProfileResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest, global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> __Method_getSelectedSurnameName = new grpc::Method<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest, global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "getSelectedSurnameName",
        __Marshaller_getselectedsurnamename_GetSelectedSurnameNameRequest,
        __Marshaller_getselectedsurnamename_GetSelectedSurnameNameResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Protos.UserProfiles.UserProfilesReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserProfiles</summary>
    [grpc::BindServiceMethod(typeof(UserProfiles), "BindService")]
    public abstract partial class UserProfilesBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> registerUserProfile(global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> getUserProfile(global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> updateUserProfile(global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> getSelectedSurnameName(global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for UserProfiles</summary>
    public partial class UserProfilesClient : grpc::ClientBase<UserProfilesClient>
    {
      /// <summary>Creates a new client for UserProfiles</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserProfilesClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for UserProfiles that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserProfilesClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserProfilesClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserProfilesClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse registerUserProfile(global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return registerUserProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse registerUserProfile(global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_registerUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> registerUserProfileAsync(global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return registerUserProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse> registerUserProfileAsync(global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_registerUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse getUserProfile(global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getUserProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse getUserProfile(global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> getUserProfileAsync(global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getUserProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse> getUserProfileAsync(global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse updateUserProfile(global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return updateUserProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse updateUserProfile(global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_updateUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> updateUserProfileAsync(global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return updateUserProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse> updateUserProfileAsync(global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_updateUserProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse getSelectedSurnameName(global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getSelectedSurnameName(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse getSelectedSurnameName(global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_getSelectedSurnameName, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> getSelectedSurnameNameAsync(global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return getSelectedSurnameNameAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse> getSelectedSurnameNameAsync(global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_getSelectedSurnameName, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override UserProfilesClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserProfilesClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserProfilesBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_registerUserProfile, serviceImpl.registerUserProfile)
          .AddMethod(__Method_getUserProfile, serviceImpl.getUserProfile)
          .AddMethod(__Method_updateUserProfile, serviceImpl.updateUserProfile)
          .AddMethod(__Method_getSelectedSurnameName, serviceImpl.getSelectedSurnameName).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserProfilesBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_registerUserProfile, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileRequest, global::Protos.UserProfiles.CreateUserProfile.CreateUserProfileResponse>(serviceImpl.registerUserProfile));
      serviceBinder.AddMethod(__Method_getUserProfile, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Protos.UserProfiles.GetUserProfile.GetUserProfileRequest, global::Protos.UserProfiles.GetUserProfile.GetUserProfileResponse>(serviceImpl.getUserProfile));
      serviceBinder.AddMethod(__Method_updateUserProfile, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileRequest, global::Protos.UserProfiles.UpdateUserProfile.UpdateUserProfileResponse>(serviceImpl.updateUserProfile));
      serviceBinder.AddMethod(__Method_getSelectedSurnameName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameRequest, global::Protos.UserProfiles.GetSelectedSurnameName.GetSelectedSurnameNameResponse>(serviceImpl.getSelectedSurnameName));
    }

  }
}
#endregion
