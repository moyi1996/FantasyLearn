using Fantasy;
using Fantasy.Async;
using Fantasy.Entitas;
using Fantasy.Helper;
using Fantasy.Network;
using System.Collections;
using System.Collections.Generic;
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
        _sendPlayerMessageButton.onClick.AddListener(OnSendMessage);

    }

    void OnDestroy()
    {
        _createPlayerButton.onClick.RemoveListener(() => OnCreatePlayer().Coroutine());
        _sendPlayerMessageButton.onClick.RemoveListener(OnSendMessage);
    }

    public async FTask OnCreatePlayer()
    {
        var createPlayerResponse = await Fantasy.Runtime.Session.C2G_CreatePlayerRequest();

        if (createPlayerResponse.ErrorCode != 0)
        {
            Debug.LogError("Player Created error: " + createPlayerResponse.ErrorCode);
            return;
        }
        {
            Debug.Log("Player Created success");
        }
    }
    public void OnSendMessage()
    { 
        Fantasy.Runtime.Session.C2G_SendPlayerMessage();
    }
}
