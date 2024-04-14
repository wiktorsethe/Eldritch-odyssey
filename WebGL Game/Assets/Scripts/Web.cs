using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    [SerializeField] private User user;
    private void Start()
    {
        //StartCoroutine(Login("wiktor", "wiktor"));
    }
    public void SetUser(string username)
    {
        user.username = username;
    }
}
