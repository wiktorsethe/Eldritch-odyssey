using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class User : NetworkBehaviour
{
    private static string _username;
    private static string _password;

    public static void SetUsername(string username)
    {
        _username = username;
    }

    public static string GetUsername()
    {
        return _username;
    }
    public static void SetPassword(string password)
    {
        _password = password;
    }

    public static string GetPassword()
    {
        return _password;
    }
}
