using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
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
            SceneManager.LoadSceneAsync(sceneName);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && _isSceneChanged)
        {
            _isSceneChanged = false;
        }
    }
}
