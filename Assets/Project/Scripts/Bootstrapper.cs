using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrapper : MonoBehaviour
{
    private void Start()
    {
        if (!SceneManager.GetSceneByName("Game").isLoaded)
        {
            SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        }
    }


    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
#if UNITY_EDITOR
        Scene currentlyLoadedEditorScene = SceneManager.GetActiveScene();
#endif

        if (!SceneManager.GetSceneByName("Bootstrap").isLoaded)
        {
            SceneManager.LoadScene("Bootstrap");
        }            

#if UNITY_EDITOR
        if (currentlyLoadedEditorScene.IsValid())
        {
            SceneManager.LoadSceneAsync(currentlyLoadedEditorScene.name, LoadSceneMode.Additive);
        }            
#else
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
#endif
    }
}
