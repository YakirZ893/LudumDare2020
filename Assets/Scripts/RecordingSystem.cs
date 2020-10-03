using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class RecordingSystem : MonoBehaviour
{
    [SerializeField] bool isRecording;
    public GameObject PlayerPrefab;
    [SerializeField] bool isthisarecording;
    [SerializeField] Transform spawnpoint;

    public AnimationClip clip;
    public AnimationClip emptyclip;
    private GameObjectRecorder m_Recorder;
    [SerializeField] private Animator animator;
    public AnimatorOverrideController animatorOverrideController;

    void Start()
    {
        isRecording = false;
        m_Recorder = new GameObjectRecorder(this.gameObject);
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
        animator = GetComponent<Animator>();
        
        
    }
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
    public void StartRecording()
    {
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;
        print("Recording Started");
        animator.SetBool("IsPlaying", false);
        m_Recorder.ResetRecording();
        isRecording = true;
        StartCoroutine(StopRecording());
    }
    IEnumerator StopRecording()
    {
        yield return new WaitForSeconds(3.5f);
        m_Recorder.SaveToClip(clip);
        isRecording = false;
        print("Recording stopped!");
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
