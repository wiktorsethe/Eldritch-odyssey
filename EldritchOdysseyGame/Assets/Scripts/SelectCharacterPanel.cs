using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectCharacterPanel : MonoBehaviour
{
    private string serverUrl = "http://54.38.52.204/getcharacters.php";
    [SerializeField] private GameObject characterPrefab;

    public void SelectCharacters(string id)
    {
        StartCoroutine(GetUserCharacters(id));
    }
    
    IEnumerator GetUserCharacters(string userId)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userId);

        WWW www = new WWW(serverUrl, form);

        yield return www;

        string[] lines = www.text.Split('\n');
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    ShowCharacter(parts[0], parts[1]);
                }
            }
        }
        //string[] userData = www.text.Split('|');
    }

    private void ShowCharacter(string username, string gender)
    {
        GameObject character = Instantiate(characterPrefab, transform.Find("List"));
        character.GetComponentInChildren<TMP_Text>().text = username + " [" + gender + "]";
    }
}
