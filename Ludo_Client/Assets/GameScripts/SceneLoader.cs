using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadSceneSingle("Login");
    }

    public static void UnloadSceneSingle(string sceneName)
    {
       SceneManager.UnloadSceneAsync(sceneName);

        //while (!t.isDone) ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void LoadSceneSingle(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
