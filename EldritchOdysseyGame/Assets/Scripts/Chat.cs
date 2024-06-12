using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using System;
public class Chat : NetworkBehaviour
{
    [SerializeField] private TMP_Text chatText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject canvas;

    private static event Action<string> OnMessage;

    public override void OnStartAuthority()
    {
        canvas.SetActive(true);

        OnMessage += HandleNewMessage;
    }

    [ClientCallback]
    private void OnDestroy()
    {
        if (!isLocalPlayer) { return; }
        OnMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string message)
    {
        chatText.text += message;

    }

    public void Send()
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }
        if (string.IsNullOrWhiteSpace(inputField.text)) { return; }
        
        var ni = NetworkClient.connection.identity;
        string prettymessage = $"[{ni.GetComponent<User>().username}]: {inputField.text}";
        CmdSendMessage(prettymessage);
        inputField.text = string.Empty;
    }

    [Command(requiresAuthority = false)]
    private void CmdSendMessage(string message)
    {
        RpcHandleMessage(message);
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {

        OnMessage?.Invoke($"\n{message}");
    }
    
}