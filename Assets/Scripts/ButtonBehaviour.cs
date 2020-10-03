using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject Platform;
    public Animator anim;

    private Animator PlatformAnim;

    // Start is called before the first frame update
    void Start()
    {
        PlatformAnim = Platform.GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {

    anim.SetBool("ButtonPressed", true);
    PlatformAnim.SetBool("Moving", true);

    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("ButtonPressed", false);
        //PlatformAnim.SetBool("Moving", false); // returns to first animation keyframe/initial position once button is unpressed

    }


}
