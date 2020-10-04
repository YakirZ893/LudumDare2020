using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class RecordingSystem : MonoBehaviour
{
    [SerializeField] bool isRecording;
<<<<<<< Updated upstream
    public GameObject PlayerPrefab;
    [SerializeField] bool isthisarecording;
    [SerializeField] Transform spawnpoint;

    public AnimationClip clip;
    public AnimationClip emptyclip;
=======
    public AnimationClip clip;
>>>>>>> Stashed changes
    private GameObjectRecorder m_Recorder;
    [SerializeField] private Animator animator;
    public AnimatorOverrideController animatorOverrideController;

<<<<<<< Updated upstream
    void Start()
=======
    private void Start()
>>>>>>> Stashed changes
    {
        isRecording = false;
        m_Recorder = new GameObjectRecorder(this.gameObject);
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
        animator = GetComponent<Animator>();
<<<<<<< Updated upstream
        
        
    }
=======
    }

>>>>>>> Stashed changes
    private void LateUpdate()
    {
        if (isRecording)
            m_Recorder.TakeSnapshot(Time.deltaTime);
        else
        {
            if (clip == null)
                return;
        }
    }
<<<<<<< Updated upstream
    public void StartRecording()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        print("Recording Started");
        animator.SetBool("IsPlaying", false);
        m_Recorder.ResetRecording();
=======

    public void StartRecording()
    {
        print("Recording Started");
        animator.SetBool("IsPlaying", false);
>>>>>>> Stashed changes
        isRecording = true;
        StartCoroutine(StopRecording());
    }
    IEnumerator StopRecording()
    {
        yield return new WaitForSeconds(3.5f);
        m_Recorder.SaveToClip(clip);
        isRecording = false;
        print("Recording stopped!");
<<<<<<< Updated upstream
        GetComponent<NewPlayerMovement>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CharacterController>().enabled = false;
        GameObject go = Instantiate(PlayerPrefab,spawnpoint.position,Quaternion.identity);
        go.GetComponent<Animator>().enabled = false;
        isthisarecording = true;
        GetComponent<RecordingSystem>().enabled = false;
    }
    public void PlayRecording()
    {      
        animator.SetBool("IsPlaying", true);
        GetComponent<MeshRenderer>().enabled = true;
    }
    public void Rewind()
    {
        m_Recorder.SaveToClip(emptyclip);
        animator.StopPlayback();
        if(isthisarecording)
        {
            Destroy(this.gameObject);
        }    
       
    }


    private void OnApplicationQuit()
    {
        
        
    }
}
=======
        //Instantiate(PlayerPrefab,transform.position,Quaternion.identity);
    }
    public void PlayRecording()
    {
       
        animator.SetBool("IsPlaying", true);
        //animator.Play(clip.name);
    }
    public void Rewind()
    {
        AnimationClip newclip = new AnimationClip();
        animator.StopPlayback();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        animatorOverrideController["PlayerMovementRecording"] = newclip;
        clip = newclip;
    }

}
>>>>>>> Stashed changes
