using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public string test;

    // Start is called before the first frame update
    void Start()
    {
        //SceneLoader.LoadSceneSingle("Game");

        SceneLoader.LoadSceneSingle("Login");

       // SceneManager.SetActiveScene();
        

        //Unload();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unload()
    {
        if (SceneManager.sceneCount == 2)
        {
          //  SceneLoader.UnloadSceneSingle("Login");
            SceneLoader.LoadSceneSingle("Game");
        }
        else
        {
            SceneLoader.LoadSceneSingle("Login");
        }
    }

}
