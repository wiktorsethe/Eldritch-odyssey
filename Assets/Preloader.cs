using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.UI;
using TMPro;
public class Preloader : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-launch-as-server")
            {
                OnServerClick(); 
                text.text = "1";
            }
            else if (args[i] == "-launch-as-host")
            {
                OnHostClick();
                text.text = "2";
            }
            else if (args[i] == "-launch-as-client")
            {
                OnClientClick();
                text.text = "3";
            }
            
        }
    }
    public void OnClientClick()
    {
        NetworkManager.Singleton.StartClient();
        Invoke(nameof(ChangeScene), 3f);
    }
    public void OnServerClick()
    {
        NetworkManager.Singleton.StartServer();
        Invoke(nameof(ChangeScene), 3f);
    }
    public void OnHostClick()
    {
        NetworkManager.Singleton.StartHost();
        Invoke(nameof(ChangeScene), 3f);
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(1);
    }
}
