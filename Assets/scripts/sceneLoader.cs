using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{

    public void Lvl1(){
        SceneManager.LoadScene("level1");
    }

    public void quit(){
        Application.Quit();
    }
}
