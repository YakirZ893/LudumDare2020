using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void StartFunction()
    {
        SceneManager.LoadScene(1);
    }
    public void Quitfunction()
    {
        Application.Quit();
    }

}
