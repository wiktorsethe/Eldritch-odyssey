using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button serverButton;
    [SerializeField] private Button clientButton;

    private void Awake()
    {
        new Logger(new MyLogHandler());
        Application.targetFrameRate = 30;

        string[] args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-launch-as-server") OnServerClick();
            else if (args[i] == "-launch-as-host") OnHostClick();
            else if (args[i] == "-launch-as-client") OnClientClick();

        }
    }
    public void OnClientClick()
    {
        NetworkManager.Singleton.StartClient();
    }
    public void OnServerClick()
    {
        NetworkManager.Singleton.StartServer();
    }
    public void OnHostClick()
    {
        NetworkManager.Singleton.StartHost();
    }
    public class MyLogHandler : ILogHandler
    {
        public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
        {
            Debug.unityLogger.logHandler.LogFormat(logType, context, format, args);
        }

        public void LogException(Exception exception, UnityEngine.Object context)
        {
            Debug.unityLogger.LogException(exception, context);
        }
    }
}
