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
        if (replayManager.recording && replayManager.currentRecordingFrames < replayManager.maxRecordingFrames) 
        {
            int recordingtime = replayManager.currentRecordingFrames / 60;
            this.GetComponent<Text>().text=recordingtime.ToString();
        }
        else if (replayManager.currentRecordingFrames >= replayManager.maxRecordingFrames && !replayManager.recording)
        {
            this.GetComponent<Text>().text
                = "Recording Done!";
            StartCoroutine(Wait());
        }
        else
        {
            this.GetComponent<Text>().text = "Waiting for recording..";
        }
    }

        IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
}
