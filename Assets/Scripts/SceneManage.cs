using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
  
{
    public LevelLoader LevelLoader;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Recording" || collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings -1)
            {
                SceneManager.LoadScene(0);
            }

            else
            {
                LevelLoader.LoadLevel();
            }
        }
    }
}
