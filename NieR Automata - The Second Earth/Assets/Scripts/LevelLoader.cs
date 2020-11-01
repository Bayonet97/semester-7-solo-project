using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    PlayerControls controls;

    public void Awake()
    {
        controls = new PlayerControls();

        controls.MenuControls.ResetLevel.performed += ctx => LoadLevel("MainScene");

        if(SceneManager.GetActiveScene().name == "App")
        {
            SceneManager.LoadScene("MainScene");
        }
    }
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void OnEnable()
    {
        controls.MenuControls.Enable();
    }

    public void OnDisable()
    {
        controls.MenuControls.Disable();
    }
}
