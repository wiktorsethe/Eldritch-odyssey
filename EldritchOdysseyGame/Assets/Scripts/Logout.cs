using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Networking;

public class Logout : NetworkBehaviour
{
    private string serverUrl = "http://54.38.52.204/getlogout.php";

    private void OnApplicationQuit()
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", User.GetUserId());
        new WWW(serverUrl, form);
        //UnityWebRequest.Post(serverUrl, form);
    }
}
