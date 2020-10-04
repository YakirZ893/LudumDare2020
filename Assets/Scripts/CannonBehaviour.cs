using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour
{
    public Transform barrel;
    public GameObject prefab;
    public ButtonBehaviour Button;
    private bool hasshot;

   
    void Update()
    {
        if (Button.isbuttonclickedcannon && !hasshot)
        {
            Instantiate(prefab, barrel.position, Quaternion.Euler(90f, 0, 0));
            hasshot = true;
        }
        if(!Button.isbuttonclickedcannon && hasshot)
        {
            hasshot = false;
        }
    }
}
