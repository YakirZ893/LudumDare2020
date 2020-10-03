using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor;
using UnityEditor.Timeline;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] Rigidbody rb;
    [SerializeField] bool isgrounded;
    [SerializeField] bool isRecording;
    public Transform playerspawn;
    public GameObject PlayerPrefab;
    public AnimationClip clip;
    private GameObjectRecorder m_Recorder;
    [SerializeField] private Animator animator;
    public AnimatorOverrideController animatorOverrideController;
    
    

    private void Start()
    {
        isgrounded = true;
        rb = this.GetComponent<Rigidbody>();
        isRecording = false;
        m_Recorder = new GameObjectRecorder(this.gameObject);
        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);
        animator= GetComponent<Animator>();  
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");

        if (x > 0 || x < 0)
            rb.AddForce(-Vector3.right * x * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector3.up * jumpforce * Time.fixedDeltaTime, ForceMode.Impulse);
            isgrounded = false;
        }
        ResetJumps();            
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
    private void ResetJumps()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,-Vector3.up, out hit, 1f))
            if (hit.transform.gameObject.tag == ("Ground"))
                isgrounded = true;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
    }

    public void StartRecording()
    {
        print("Recording Started");
        animator.SetBool("IsPlaying", false);
        isRecording = true;
        StartCoroutine(StopRecording());
    }
    IEnumerator StopRecording()
    {
        yield return new WaitForSeconds(3.5f);
        m_Recorder.SaveToClip(clip);
        isRecording = false;
        print("Recording stopped!");
        //GetComponent<MeshRenderer>().enabled = false;
        //Instantiate(PlayerPrefab,transform.position,Quaternion.identity);
    }    
    public void PlayRecording()
    {
        // GetComponent<MeshRenderer>().enabled = true;
        animator.SetBool("IsPlaying",true);
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

