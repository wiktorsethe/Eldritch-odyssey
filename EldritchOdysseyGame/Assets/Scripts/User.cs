using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    private static int _userId;
    private static string _username;
    private static string _password;

    public static void SetUserId(int userid)
    {
        _userId = userid;
    }
    public static int GetUserId()
    {
        return _userId;
    }
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
