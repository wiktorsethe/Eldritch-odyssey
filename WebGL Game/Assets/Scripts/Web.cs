using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Mirror;

public class Web : NetworkBehaviour
{
    [SyncVar]
    public string playerName;

    public override void OnStartServer()
    {
        playerName = (string)connectionToClient.authenticationData;
    }

    public override void OnStartLocalPlayer()
    {
        ChatUI.localPlayerName = playerName;
    }
}
