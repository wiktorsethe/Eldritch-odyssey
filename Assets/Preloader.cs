using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;
public class Preloader : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;

    private void Start()
    {
        Application.targetFrameRate = 60;

        if(Application.platform == RuntimePlatform.LinuxServer) OnServerClick();
        else OnClientClick();
    }
    public void OnClientClick()
    {
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }
    public void OnServerClick()
    {
        NetworkManager.Singleton.StartServer();
        gameObject.SetActive(false);
    }
    public void OnHostClick()
    {
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }
}
