using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Preloader : MonoBehaviour
{
    private void Start()
    {
        if (Application.platform != RuntimePlatform.LinuxServer)
        {
            NetworkManager.singleton.networkAddress = "54.38.52.204";
            NetworkManager.singleton.StartClient();
        }
    }
}
