using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class SceneChanger : NetworkBehaviour
{
    [HideInInspector] public string sceneName;
    private bool _isSceneChanged = true;
    private void Start()
    {
        if (PlayerPrefs.HasKey("PrevScene"))
        {
            if (PlayerPrefs.GetString("PrevScene") == sceneName)
            {
                GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !_isSceneChanged)
        {
            PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
            ChangeScene();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && _isSceneChanged)
        {
            _isSceneChanged = false;
        }
    }
    
    [Client]
    private void ChangeScene()
    {
        if (isLocalPlayer)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
