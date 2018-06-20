using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public static GM instance = null;


	public void OpenLevel(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }
    
}
