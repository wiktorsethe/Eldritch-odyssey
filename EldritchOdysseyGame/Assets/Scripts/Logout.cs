using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;
using NetworkIdentity = Mirror.NetworkIdentity;

public class Logout : MonoBehaviour
{
    private User user;
    private string serverUrl = "http://54.38.52.204/getlogout.php";

    private void OnApplicationQuit()
    {
        WWWForm form = new WWWForm();
        user = FindObjectOfType(typeof(User)) as User;
        if (user != null) form.AddField("userId", user.userId);
        new WWW(serverUrl, form);
        //UnityWebRequest.Post(serverUrl, form);
    }
}
