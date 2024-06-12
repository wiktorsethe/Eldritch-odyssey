using System;
using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Types;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{
    private string serverUrl = "http://54.38.52.204/getlogin.php";
    [SerializeField] private Button loginButton;
    [SerializeField] private GameObject canvas;
    [SerializeField] private InputField loginField;
    [SerializeField] private InputField passwordField;
    public User user;
    public void Start()
    {
        Button btn = loginButton.GetComponent<Button>();
        btn.onClick.AddListener(LoginOnClick);
    }

    public void LoginOnClick()
    {
        StartCoroutine(LoginDB(loginField.text, passwordField.text));
    }
    IEnumerator LoginDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        WWW www = new WWW(serverUrl, form);

        yield return www;

        string[] userData = www.text.Split('|');
        if (userData.Length == 3)
        {
            /*user.UserId = userData[0];
            user.Username = userData[1];
            user.Password = userData[2];*/

            var ni = NetworkClient.connection.identity;
            ni.GetComponent<User>().CmdSetUserId(userData[0]);
            ni.GetComponent<User>().CmdSetUsername(userData[1]);
            ni.GetComponent<User>().CmdSetPassword(userData[2]);
            
            gameObject.SetActive(false);
        }
        else
        {
            loginField.text = "";
            passwordField.text = "";
            Debug.Log(www.text);
        }
    }
}