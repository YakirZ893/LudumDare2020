using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public Transform barrel;
    public GameObject prefab;
    public GameObject smoke;
    public ButtonBehaviour Button;
    private bool hasshot;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (Button.isbuttonclickedcannon && !hasshot)
        {
            anim.SetTrigger("Shoot");
            Instantiate(prefab, barrel.position, Quaternion.Euler(90f, 0, 0));
            Instantiate(smoke, barrel.position, Quaternion.Euler(-180f,0,0));
            hasshot = true;

        }
        if(!Button.isbuttonclickedcannon && hasshot)
        {
            hasshot = false;
        }
    }
}
