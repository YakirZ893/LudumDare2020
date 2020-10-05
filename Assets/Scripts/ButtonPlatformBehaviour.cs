using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlatformBehaviour : MonoBehaviour
{
    public ButtonBehaviour BB;
    [SerializeField] private Transform PlatformTarget;
    [SerializeField] private Transform StartPoint;
    private float time;
    [Range(0,1)]
    [SerializeField] float speed;

    private void Update()
    {
        
        if(BB.isbuttonclicked)
        {
         transform.position = Vector3.Lerp(transform.position, PlatformTarget.position, speed *  Time.deltaTime);
        }

        if (!BB.isbuttonclicked)
        {
            time = Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, StartPoint.position,speed* time);
            if (time > 1)
            { 
                time = 0;
            }
        }
    }
}
