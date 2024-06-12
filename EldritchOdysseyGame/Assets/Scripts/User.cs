using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class User : NetworkBehaviour
{
    [SyncVar (hook = nameof(HandleDisplayColorChange))] [SerializeField] private Color displayColor;
    [SerializeField] private SpriteRenderer userSprite;

    [SyncVar (hook = nameof(OnUserIdChanged))] [SerializeField] private string userIdSyncVar;
    public string userId;
    [SyncVar (hook = nameof(OnUsernameChanged))] [SerializeField] private string usernameSyncVar;
    public string username;
    [SyncVar (hook = nameof(OnPasswordChanged))] [SerializeField] private string passwordSyncVar;
    public string password;

    [Server]
    public void SetDisplayColor(Color newColor)
    {
        displayColor = newColor;
    }

    private void HandleDisplayColorChange(Color oldColor, Color newColor)
    {
        userSprite.color = newColor;
    }
    
    [Command]
    public void CmdSetUserId(string userId)
    {
        userIdSyncVar = userId;
    }
    private void OnUserIdChanged(string oldUserId, string newUserid)
    {
        userId = newUserid;
    }
    
    [Command]
    public void CmdSetUsername(string username)
    {
        usernameSyncVar = username;
    }
    private void OnUsernameChanged(string oldUsername, string newUsername)
    {
        username = newUsername;
    }
    
    [Command]
    public void CmdSetPassword(string password)
    {
        passwordSyncVar = password;
    }
    private void OnPasswordChanged(string oldPassword, string newPassword)
    {
        password = newPassword;
    }
}

