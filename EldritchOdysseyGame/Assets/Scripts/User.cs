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
    [SyncVar (hook = nameof(OnLoginChanged))] [SerializeField] private string loginSyncVar;
    public string login;
    [SyncVar (hook = nameof(OnPasswordChanged))] [SerializeField] private string passwordSyncVar;
    public string password;
    
    [SyncVar (hook = nameof(OnNicknameChanged))] [SerializeField] private string nicknameSyncVar;
    public string nickname;
    [SyncVar (hook = nameof(OnGenderChanged))] [SerializeField] private string genderSyncVar;
    public string gender;
    
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
    public void CmdSetLogin(string login)
    {
        loginSyncVar = login;
    }
    private void OnLoginChanged(string oldLogin, string newLogin)
    {
        login = newLogin;
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
    
    [Command]
    public void CmdSetNickname(string nickname)
    {
        nicknameSyncVar = nickname;
    }
    private void OnNicknameChanged(string oldNickname, string newNickname)
    {
        nickname = newNickname;
    }
    [Command]
    public void CmdSetGender(string gender)
    {
        genderSyncVar = gender;
    }
    private void OnGenderChanged(string oldGender, string newGender)
    {
        gender = newGender;
    }
}

