using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugFixer : MonoBehaviour
{
    private void Start()
    {
        int levl = GameObject.FindObjectOfType<AudioManager>().level;
        SceneManager.LoadScene(levl);
        
    }
}
