using LightProto;
using System;
using MemoryPack;
using System.Collections.Generic;
using Fantasy;
using Fantasy.Pool;
using Fantasy.Network.Interface;
using Fantasy.Serialize;

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618
// ReSharper disable InconsistentNaming
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable RedundantTypeArgumentsOfMethod
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable PreferConcreteValueOverDefault
// ReSharper disable RedundantNameQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable RedundantUsingDirective
// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
namespace Fantasy
{
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestMessage : AMessage, IMessage
    {
        public static C2G_TestMessage Create(bool autoReturn = true)
        {
            var c2G_TestMessage = MessageObjectPool<C2G_TestMessage>.Rent();
            c2G_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestMessage.SetIsPool(false);
            }
            
            return c2G_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_TestRequest : AMessage, IRequest
    {
        public static C2G_TestRequest Create(bool autoReturn = true)
        {
            var c2G_TestRequest = MessageObjectPool<C2G_TestRequest>.Rent();
            c2G_TestRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_TestRequest.SetIsPool(false);
            }
            
            return c2G_TestRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2G_TestRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_TestRequest; } 
        [ProtoIgnore]
        public G2C_TestResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_TestResponse : AMessage, IResponse
    {
        public static G2C_TestResponse Create(bool autoReturn = true)
        {
            var g2C_TestResponse = MessageObjectPool<G2C_TestResponse>.Rent();
            g2C_TestResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_TestResponse.SetIsPool(false);
            }
            
            return g2C_TestResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            Tag = default;
            MessageObjectPool<G2C_TestResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_TestResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_TestMessage : AMessage, IMessage
    {
        public static G2C_TestMessage Create(bool autoReturn = true)
        {
            var g2C_TestMessage = MessageObjectPool<G2C_TestMessage>.Rent();
            g2C_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_TestMessage.SetIsPool(false);
            }
            
            return g2C_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Message = default;
            MessageObjectPool<G2C_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_TestMessage; } 
        [ProtoMember(1)]
        public string Message { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_Notification : AMessage, IResponse
    {
        public static G2C_Notification Create(bool autoReturn = true)
        {
            var g2C_Notification = MessageObjectPool<G2C_Notification>.Rent();
            g2C_Notification.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_Notification.SetIsPool(false);
            }
            
            return g2C_Notification;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            Message = default;
            MessageObjectPool<G2C_Notification>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_Notification; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Message { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_CreatePlayerRequest : AMessage, IRequest
    {
        public static C2G_CreatePlayerRequest Create(bool autoReturn = true)
        {
            var c2G_CreatePlayerRequest = MessageObjectPool<C2G_CreatePlayerRequest>.Rent();
            c2G_CreatePlayerRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_CreatePlayerRequest.SetIsPool(false);
            }
            
            return c2G_CreatePlayerRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_CreatePlayerRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_CreatePlayerRequest; } 
        [ProtoIgnore]
        public G2C_CreatePlayerResponse ResponseType { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2C_CreatePlayerResponse : AMessage, IResponse
    {
        public static G2C_CreatePlayerResponse Create(bool autoReturn = true)
        {
            var g2C_CreatePlayerResponse = MessageObjectPool<G2C_CreatePlayerResponse>.Rent();
            g2C_CreatePlayerResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2C_CreatePlayerResponse.SetIsPool(false);
            }
            
            return g2C_CreatePlayerResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            MessageObjectPool<G2C_CreatePlayerResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2C_CreatePlayerResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2G_SendPlayerMessage : AMessage, IMessage
    {
        public static C2G_SendPlayerMessage Create(bool autoReturn = true)
        {
            var c2G_SendPlayerMessage = MessageObjectPool<C2G_SendPlayerMessage>.Rent();
            c2G_SendPlayerMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2G_SendPlayerMessage.SetIsPool(false);
            }
            
            return c2G_SendPlayerMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            MessageObjectPool<C2G_SendPlayerMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2G_SendPlayerMessage; } 
    }
    /// <summary>
    /// 客户端到聊天服务器的Message消息
    /// </summary>
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_TestMessage : AMessage, IRoamingMessage
    {
        public static C2Chat_TestMessage Create(bool autoReturn = true)
        {
            var c2Chat_TestMessage = MessageObjectPool<C2Chat_TestMessage>.Rent();
            c2Chat_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_TestMessage.SetIsPool(false);
            }
            
            return c2Chat_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Chat_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_TestMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2Map_TestMessage : AMessage, IRoamingMessage
    {
        public static C2Map_TestMessage Create(bool autoReturn = true)
        {
            var c2Map_TestMessage = MessageObjectPool<C2Map_TestMessage>.Rent();
            c2Map_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Map_TestMessage.SetIsPool(false);
            }
            
            return c2Map_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Tag = default;
            MessageObjectPool<C2Map_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Map_TestMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2Chat_TestMessage : AMessage, IRoamingMessage
    {
        public static G2Chat_TestMessage Create(bool autoReturn = true)
        {
            var g2Chat_TestMessage = MessageObjectPool<G2Chat_TestMessage>.Rent();
            g2Chat_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2Chat_TestMessage.SetIsPool(false);
            }
            
            return g2Chat_TestMessage;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            Content = default;
            MessageObjectPool<G2Chat_TestMessage>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2Chat_TestMessage; } 
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public string Content { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class C2Chat_GetDataRequest : AMessage, IRoamingRequest
    {
        public static C2Chat_GetDataRequest Create(bool autoReturn = true)
        {
            var c2Chat_GetDataRequest = MessageObjectPool<C2Chat_GetDataRequest>.Rent();
            c2Chat_GetDataRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                c2Chat_GetDataRequest.SetIsPool(false);
            }
            
            return c2Chat_GetDataRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            PlayerId = default;
            MessageObjectPool<C2Chat_GetDataRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.C2Chat_GetDataRequest; } 
        [ProtoIgnore]
        public Chat2C_GetDataResponse ResponseType { get; set; }
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.ChatRoamingType;
        [ProtoMember(1)]
        public long PlayerId { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Chat2C_GetDataResponse : AMessage, IRoamingResponse
    {
        public static Chat2C_GetDataResponse Create(bool autoReturn = true)
        {
            var chat2C_GetDataResponse = MessageObjectPool<Chat2C_GetDataResponse>.Rent();
            chat2C_GetDataResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                chat2C_GetDataResponse.SetIsPool(false);
            }
            
            return chat2C_GetDataResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            ChatData = default;
            MessageObjectPool<Chat2C_GetDataResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Chat2C_GetDataResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string ChatData { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2Map_GetPlayerRequest : AMessage, IRoamingRequest
    {
        public static G2Map_GetPlayerRequest Create(bool autoReturn = true)
        {
            var g2Map_GetPlayerRequest = MessageObjectPool<G2Map_GetPlayerRequest>.Rent();
            g2Map_GetPlayerRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2Map_GetPlayerRequest.SetIsPool(false);
            }
            
            return g2Map_GetPlayerRequest;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            PlayerId = default;
            MessageObjectPool<G2Map_GetPlayerRequest>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.G2Map_GetPlayerRequest; } 
        [ProtoIgnore]
        public Map2G_GetPlayerResponse ResponseType { get; set; }
        [ProtoIgnore]
        public int RouteType => Fantasy.RoamingType.MapRoamingType;
        [ProtoMember(1)]
        public long PlayerId { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Map2G_GetPlayerResponse : AMessage, IRoamingResponse
    {
        public static Map2G_GetPlayerResponse Create(bool autoReturn = true)
        {
            var map2G_GetPlayerResponse = MessageObjectPool<Map2G_GetPlayerResponse>.Rent();
            map2G_GetPlayerResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                map2G_GetPlayerResponse.SetIsPool(false);
            }
            
            return map2G_GetPlayerResponse;
        }
        
        public void Return()
        {
            if (!AutoReturn)
            {
                SetIsPool(true);
                AutoReturn = true;
            }
            else if (!IsPool())
            {
                return;
            }
            Dispose();
        }

        public void Dispose()
        {
            if (!IsPool()) return; 
            ErrorCode = 0;
            PlayerName = default;
            Level = default;
            MessageObjectPool<Map2G_GetPlayerResponse>.Return(this);
        }
        public uint OpCode() { return OuterOpcode.Map2G_GetPlayerResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string PlayerName { get; set; }
        [ProtoMember(3)]
        public int Level { get; set; }
    }
}