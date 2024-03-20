using System;
using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

[System.Serializable]
 public class User
{
    public string username;
    public string password;
}

public class LoginPanel : MonoBehaviour
{
    private string serverUrl = "localhost:9999/getdata";
    [SerializeField] private Button loginButton;
    [SerializeField] private GameObject canvas;
    [SerializeField] private InputField loginField;
    [SerializeField] private InputField passwordField;
    private bool succesfullLogin = false;
    private User user;
    private GameObject[] player;
    [SerializeField] private NetworkManager nm;
    
    public void Start()
    {
        StartCoroutine(GetData());
        nm.playerPrefab.GetComponent<PlayerMovement>().enabled = false;
        Button btn = loginButton.GetComponent<Button>();
        btn.onClick.AddListener(LoginOnClick);
    }

    void LoginOnClick()
    {
        if (user.username == loginField.text && passwordField.text == user.password)
        {
            succesfullLogin = true;
        }
        if (succesfullLogin)
        {
            player = GameObject.FindGameObjectsWithTag("Player");
            canvas.SetActive(false);
            for (int i = 0; i < player.Length; i++)
            {
                player[i].GetComponent<PlayerMovement>().enabled = true;
            }
        }
        else
        {
            loginField.text = "";
            passwordField.text = "";
        }
    }
    IEnumerator GetData()
    {
        UnityWebRequest www = UnityWebRequest.Get(serverUrl);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Pomyślnie otrzymano dane z serwera
            Debug.Log(www.downloadHandler.text);
            user = JsonUtility.FromJson<User>(www.downloadHandler.text);
            Debug.Log(user.username);
            Debug.Log(user.password);
        }
    }
}
