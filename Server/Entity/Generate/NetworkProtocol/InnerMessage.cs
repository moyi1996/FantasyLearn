using LightProto;
using MemoryPack;
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Fantasy;
using Fantasy.Pool;
using Fantasy.Network.Interface;
using Fantasy.Serialize;

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
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8618
namespace Fantasy
{
    [Serializable]
    [ProtoContract]
    public partial class G2Player_TestMessage : AMessage, IAddressMessage
    {
        public static G2Player_TestMessage Create(bool autoReturn = true)
        {
            var g2Player_TestMessage = MessageObjectPool<G2Player_TestMessage>.Rent();
            g2Player_TestMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2Player_TestMessage.SetIsPool(false);
            }
            
            return g2Player_TestMessage;
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
            MessageObjectPool<G2Player_TestMessage>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.G2Player_TestMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2Player_TestRequest : AMessage, IAddressRequest
    {
        public static G2Player_TestRequest Create(bool autoReturn = true)
        {
            var g2Player_TestRequest = MessageObjectPool<G2Player_TestRequest>.Rent();
            g2Player_TestRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2Player_TestRequest.SetIsPool(false);
            }
            
            return g2Player_TestRequest;
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
            MessageObjectPool<G2Player_TestRequest>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.G2Player_TestRequest; } 
        [ProtoIgnore]
        public Player2G_TestResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Player2G_TestResponse : AMessage, IAddressResponse
    {
        public static Player2G_TestResponse Create(bool autoReturn = true)
        {
            var player2G_TestResponse = MessageObjectPool<Player2G_TestResponse>.Rent();
            player2G_TestResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                player2G_TestResponse.SetIsPool(false);
            }
            
            return player2G_TestResponse;
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
            MessageObjectPool<Player2G_TestResponse>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.Player2G_TestResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2M_TestAddressMessage : AMessage, IAddressMessage
    {
        public static G2M_TestAddressMessage Create(bool autoReturn = true)
        {
            var g2M_TestAddressMessage = MessageObjectPool<G2M_TestAddressMessage>.Rent();
            g2M_TestAddressMessage.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2M_TestAddressMessage.SetIsPool(false);
            }
            
            return g2M_TestAddressMessage;
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
            MessageObjectPool<G2M_TestAddressMessage>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.G2M_TestAddressMessage; } 
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2M_TestAddressRequest : AMessage, IAddressRequest
    {
        public static G2M_TestAddressRequest Create(bool autoReturn = true)
        {
            var g2M_TestAddressRequest = MessageObjectPool<G2M_TestAddressRequest>.Rent();
            g2M_TestAddressRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2M_TestAddressRequest.SetIsPool(false);
            }
            
            return g2M_TestAddressRequest;
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
            MessageObjectPool<G2M_TestAddressRequest>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.G2M_TestAddressRequest; } 
        [ProtoIgnore]
        public M2G_TestAddressResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Tag { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class M2G_TestAddressResponse : AMessage, IAddressResponse
    {
        public static M2G_TestAddressResponse Create(bool autoReturn = true)
        {
            var m2G_TestAddressResponse = MessageObjectPool<M2G_TestAddressResponse>.Rent();
            m2G_TestAddressResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                m2G_TestAddressResponse.SetIsPool(false);
            }
            
            return m2G_TestAddressResponse;
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
            Result = default;
            MessageObjectPool<M2G_TestAddressResponse>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.M2G_TestAddressResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public string Result { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class G2Map_CreatePlayerRequest : AMessage, IAddressRequest
    {
        public static G2Map_CreatePlayerRequest Create(bool autoReturn = true)
        {
            var g2Map_CreatePlayerRequest = MessageObjectPool<G2Map_CreatePlayerRequest>.Rent();
            g2Map_CreatePlayerRequest.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                g2Map_CreatePlayerRequest.SetIsPool(false);
            }
            
            return g2Map_CreatePlayerRequest;
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
            Name = default;
            Age = default;
            MessageObjectPool<G2Map_CreatePlayerRequest>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.G2Map_CreatePlayerRequest; } 
        [ProtoIgnore]
        public Map2G_CreatePlayerResponse ResponseType { get; set; }
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Age { get; set; }
    }
    [Serializable]
    [ProtoContract]
    public partial class Map2G_CreatePlayerResponse : AMessage, IAddressResponse
    {
        public static Map2G_CreatePlayerResponse Create(bool autoReturn = true)
        {
            var map2G_CreatePlayerResponse = MessageObjectPool<Map2G_CreatePlayerResponse>.Rent();
            map2G_CreatePlayerResponse.AutoReturn = autoReturn;
            
            if (!autoReturn)
            {
                map2G_CreatePlayerResponse.SetIsPool(false);
            }
            
            return map2G_CreatePlayerResponse;
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
            PlayerAddress = default;
            MessageObjectPool<Map2G_CreatePlayerResponse>.Return(this);
        }
        public uint OpCode() { return InnerOpcode.Map2G_CreatePlayerResponse; } 
        [ProtoMember(1)]
        public uint ErrorCode { get; set; }
        [ProtoMember(2)]
        public long PlayerAddress { get; set; }
    }
}