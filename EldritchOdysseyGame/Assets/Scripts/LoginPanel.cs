using System;
using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{
    private string serverUrl = "http://54.38.52.204/getlogin.php";
    [SerializeField] private Button loginButton;
    [SerializeField] private GameObject canvas;
    [SerializeField] private InputField loginField;
    [SerializeField] private InputField passwordField;
    private User _user;
    [SerializeField] private NetworkManager nm;
    
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
        if (userData.Length == 2)
        {
            User.SetUsername(userData[0]);
            User.SetPassword(userData[1]);
            /*_user = new User
            {
                username = userData[0],
                password = userData[1]
            };*/
            
            Debug.Log("login success");
            SceneManager.LoadSceneAsync("Main");
        }
        else
        {
            loginField.text = "";
            passwordField.text = "";
        }
    }
}