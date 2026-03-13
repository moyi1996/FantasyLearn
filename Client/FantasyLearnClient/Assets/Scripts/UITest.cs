using Fantasy;
using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Helper;
using Fantasy.Network;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    [SerializeField] private Button _createPlayerButton;
    [SerializeField] private Button _sendPlayerMessageButton;
    // Start is called before the first frame update
    void Start()
    {
        _createPlayerButton.onClick.AddListener(() => OnCreatePlayer().Coroutine());
        _sendPlayerMessageButton.onClick.AddListener(() => OnSendMessage().Coroutine());

    }

    void OnDestroy()
    {
        _createPlayerButton.onClick.RemoveListener(() => OnCreatePlayer().Coroutine());
        _sendPlayerMessageButton.onClick.RemoveListener(() => OnSendMessage().Coroutine());
    }

    public async FTask OnCreatePlayer()
    {
#region AddressMessage
        var createPlayerResponse = await Fantasy.Runtime.Session.C2G_CreatePlayerRequest();

        if (createPlayerResponse.ErrorCode != 0)
        {
            Debug.LogError("Player Created error: " + createPlayerResponse.ErrorCode);
            return;
        }
        {
            Debug.Log("Player Created success");
        }
#endregion
#region Roaming

#endregion
    }
    public async FTask OnSendMessage()
    { 
// #region AddressMessage
//         Fantasy.Runtime.Session.C2G_SendPlayerMessage();
// #endregion
#region Roaming
        Fantasy.Runtime.Session.C2Chat_TestMessage("Roaming 消息测试");
        var response = await Fantasy.Runtime.Session.C2Chat_GetDataRequest(1);
        if (response.ErrorCode != 0)
        {
            Debug.LogError("Get Data error: " + response.ErrorCode);
            return;
        }
        {
            Debug.Log("Get Data success: " + response.ChatData);
        }

#endregion
    }
}
