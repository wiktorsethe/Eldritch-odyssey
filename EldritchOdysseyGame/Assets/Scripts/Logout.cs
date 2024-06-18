using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;
using NetworkIdentity = Mirror.NetworkIdentity;

public class Logout : MonoBehaviour
{
    private static string serverUrl = "http://54.38.52.204/getlogout.php";

    public static void SendLogout(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userId", userid);
        new WWW(serverUrl, form);
        //UnityWebRequest.Post(serverUrl, form);
    }
}
