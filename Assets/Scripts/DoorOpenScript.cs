using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{
    public Animator doorAnim;
    public Material doorKnob;
    public float emisSTR = 2f;

    private void Start()
    {
        doorKnob.color = Color.red;
        doorKnob.SetColor("_EmissionColor", new Color(1f, 0f, 0f, 1f) * emisSTR);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Recording"))
        {
            doorAnim.SetTrigger("isOpen");
            GameObject.FindObjectOfType<AudioManager>().Play("Door");
            doorKnob.color = Color.green;
            doorKnob.SetColor("_EmissionColor", new Color(0f, 1f, 0f, 1f) * emisSTR);
        }
    }
}