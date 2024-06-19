using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;

public class CreateCharacterPanel : MonoBehaviour
{
    private string serverUrl = "http://54.38.52.204/putcharacter.php";
    [SerializeField] private TMP_InputField nicknameField;
    [SerializeField] private TMP_InputField genderField;
    [SerializeField] private GameObject selectCharacterPanel;
    private SelectCharacterPanel _selectCharacterPanel;
    public void PutCharacter()
    {
        var ni = NetworkClient.connection.identity;
        StartCoroutine(PutCharacterToDB(nicknameField.text, genderField.text, ni.GetComponent<User>().userId));
        gameObject.SetActive(false);
        selectCharacterPanel.SetActive(true);
        _selectCharacterPanel = FindObjectOfType(typeof(SelectCharacterPanel)) as SelectCharacterPanel;
        if (_selectCharacterPanel != null) _selectCharacterPanel.SelectCharacters(ni.GetComponent<User>().userId);
    }
    
    IEnumerator PutCharacterToDB(string nickname, string gender, string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("nickname", nickname);
        form.AddField("gender", gender);
        form.AddField("userid", userid);

        WWW www = new WWW(serverUrl, form);

        yield return www;
        
        Debug.Log(www.text);
    }
}
