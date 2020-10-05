using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    [SerializeField] float transitionTime;
   
  
    public void LoadLevel()
    {
        StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }
   public IEnumerator LoadTransition(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    public void ReloadCurrentLevel()
    {
        StartCoroutine(ReloadCurrentLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public IEnumerator ReloadCurrentLevel(int index)
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index);
    }
}
