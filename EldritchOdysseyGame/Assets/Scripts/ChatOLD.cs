using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using TMPro;
using System;
public class ChatOLD : NetworkBehaviour
{
    [SerializeField] private TMP_Text chatText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject canvas;

    private static event Action<string> OnMessage;

    private bool isPlayerMovementEnabled = true;
    [SerializeField] private PlayerMovement playerMovement;

    public string localPlayerName;

    public override void OnStartAuthority()
    {
        canvas.SetActive(true);
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        inputField.onDeselect.AddListener(OnDeselect);
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

    [Client]
    public void Send()
    {
        if (!Input.GetKeyDown(KeyCode.Return)) { return; }
        if (string.IsNullOrWhiteSpace(inputField.text)) { return; }
        CmdSendMessage(inputField.text);
        inputField.text = string.Empty;
        if (!isPlayerMovementEnabled)
        {
            GetComponent<PlayerMovement>().enabled = true;
            isPlayerMovementEnabled = true;
        }
    }

    [Command]
    private void CmdSendMessage(string message)
    {
        RpcHandleMessage($"[{localPlayerName}]: {message}"); //{connectionToClient.connectionId}
    }

    [ClientRpc]
    private void RpcHandleMessage(string message)
    {
        OnMessage?.Invoke($"\n{message}");
    }

    private void OnInputValueChanged(string value)
    {
        if (value.Length > 0)
        {
            if (isPlayerMovementEnabled)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                playerMovement.enabled = false;
                isPlayerMovementEnabled = false;
            }
        }
        else
        {
            if (!isPlayerMovementEnabled)
            {
                playerMovement.enabled = true;
                isPlayerMovementEnabled = true;
            }
        }
    }
    private void OnDeselect(string value)
    {
        playerMovement.enabled = true;
        isPlayerMovementEnabled = true;
    }
}

