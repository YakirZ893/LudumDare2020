using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecordingTime : MonoBehaviour
{
    public ReplayManager replayManager;
    void Update()
    {
        if(replayManager.recording)
        {
            this.GetComponent<TextMeshPro>().text = replayManager.currentRecordingFrames.ToString();
        }
        else
        {
            this.GetComponent<TextMeshPro>().text = "Recording Done!";
        }
    }
}
