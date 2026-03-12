using System.Runtime.CompilerServices;
using Fantasy;
using Fantasy.Async;
using Fantasy.Network;
using System.Collections.Generic;
#pragma warning disable CS8618
namespace Fantasy
{
   public static class NetworkProtocolHelper
   {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_TestMessage(this Session session, C2G_TestMessage C2G_TestMessage_message)
		{
			session.Send(C2G_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_TestMessage(this Session session, string tag)
		{
			using var C2G_TestMessage_message = Fantasy.C2G_TestMessage.Create();
			C2G_TestMessage_message.Tag = tag;
			session.Send(C2G_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_TestResponse> C2G_TestRequest(this Session session, C2G_TestRequest C2G_TestRequest_request)
		{
			return (G2C_TestResponse)await session.Call(C2G_TestRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_TestResponse> C2G_TestRequest(this Session session, string tag)
		{
			using var C2G_TestRequest_request = Fantasy.C2G_TestRequest.Create();
			C2G_TestRequest_request.Tag = tag;
			return (G2C_TestResponse)await session.Call(C2G_TestRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void G2C_TestMessage(this Session session, G2C_TestMessage G2C_TestMessage_message)
		{
			session.Send(G2C_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void G2C_TestMessage(this Session session, string message)
		{
			using var G2C_TestMessage_message = Fantasy.G2C_TestMessage.Create();
			G2C_TestMessage_message.Message = message;
			session.Send(G2C_TestMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_CreatePlayerResponse> C2G_CreatePlayerRequest(this Session session, C2G_CreatePlayerRequest C2G_CreatePlayerRequest_request)
		{
			return (G2C_CreatePlayerResponse)await session.Call(C2G_CreatePlayerRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static async FTask<G2C_CreatePlayerResponse> C2G_CreatePlayerRequest(this Session session)
		{
			using var C2G_CreatePlayerRequest_request = Fantasy.C2G_CreatePlayerRequest.Create();
			return (G2C_CreatePlayerResponse)await session.Call(C2G_CreatePlayerRequest_request);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_SendPlayerMessage(this Session session, C2G_SendPlayerMessage C2G_SendPlayerMessage_message)
		{
			session.Send(C2G_SendPlayerMessage_message);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void C2G_SendPlayerMessage(this Session session)
		{
			using var message = Fantasy.C2G_SendPlayerMessage.Create();
			session.Send(message);
		}

   }
}