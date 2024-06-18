using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Random = UnityEngine.Random;

public class CustomNM : NetworkManager
{
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        User user = conn.identity.GetComponent<User>();
        user.SetDisplayColor(new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f));
        
    }
    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        User user = conn.identity.GetComponent<User>();
        Logout.SendLogout(user.userId);
        
        base.OnServerDisconnect(conn);
    }
}
