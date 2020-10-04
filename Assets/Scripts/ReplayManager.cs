using System;
using UnityEngine;
using System.IO;

public class ReplayManager : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;

    private MemoryStream memoryStream = null;
    private BinaryWriter binaryWriter = null;
    private BinaryReader binaryReader = null;

    private bool recordingInitialized = false;
    private bool recording = false;
    private bool replaying = false;

    private int currentRecordingFrames = 0;
    public int maxRecordingFrames = 360;

    public int replayFrameLength = 2;
    private int replayFrameTimer = 0;

    public Action OnStartedRecording;
    public Action OnStoppedRecording;
    public Action OnStartedReplaying;
    public Action OnStoppedReplaying;

    public GameObject prefab;
    public Transform playerspawn;
    public void Start()
    {
        transforms = FindObjectsOfType<Transform>();
    }

    public void FixedUpdate()
    {
        if (recording)
        {
            UpdateRecording();
        }
        else if (replaying)
        {
            UpdateReplaying();
        }
    }

    public void StartStopRecording()
    {
        if (!recording)
        {
            StartRecording();
        }
        else
        {
            StopRecording();
        }
    }

    public void InitializeRecording()
    {
        memoryStream = new MemoryStream();
        binaryWriter = new BinaryWriter(memoryStream);
        binaryReader = new BinaryReader(memoryStream);
        recordingInitialized = true;
    }

    private void StartRecording()
    {
        if (!recordingInitialized)
        {
            InitializeRecording();
        }
        else
        {
            memoryStream.SetLength(0);
        }
        ResetReplayFrame();

        StartReplayFrameTimer();
        recording = true;
        if (OnStartedRecording != null)
        {
            OnStartedRecording();
        }
    }

    private void UpdateRecording()
    {
        if (currentRecordingFrames > maxRecordingFrames)
        {
            StopRecording();
            currentRecordingFrames = 0;
            return;
        }

        if (replayFrameTimer == 0)
        {
            SaveTransforms(transforms);
            ResetReplayFrameTimer();
        }
        --replayFrameTimer;
        ++currentRecordingFrames;
    }

    private void StopRecording()
    {
        recording = false;
        if (OnStoppedRecording != null)
        {
            OnStoppedRecording();
        }
    }

    private void ResetReplayFrame()
    {
        memoryStream.Seek(0, SeekOrigin.Begin);
        binaryWriter.Seek(0, SeekOrigin.Begin);
    }

    public void StartStopReplaying()
    {
        //need to change this in order to replay in a loop//
        if (!replaying)
        {
            StartReplaying();
            SpawnPlayer();
        }
        else
        {
            StopReplaying();
        }
    }

    private void StartReplaying()
    {
        ResetReplayFrame();
        StartReplayFrameTimer();
        replaying = true;
       
        if (OnStartedReplaying != null)
        {
            OnStartedReplaying();
        }
    }

    private void UpdateReplaying()
    {
        if (memoryStream.Position >= memoryStream.Length)
        {
            ResetReplayFrame();
            //StopReplaying();
            return;
        }

        if (replayFrameTimer == 0)
        {
            LoadTransforms(transforms);
            ResetReplayFrameTimer();
        }
        --replayFrameTimer;
    }

    private void StopReplaying()
    {
        replaying = false;
        if (OnStoppedReplaying != null)
        {
            OnStoppedReplaying();
        }
    }

    private void ResetReplayFrameTimer()
    {
        replayFrameTimer = replayFrameLength;
    }

    private void StartReplayFrameTimer()
    {
        replayFrameTimer = 0;
    }

    private void SaveTransforms(Transform[] transforms)
    {
        foreach (Transform transform in transforms)
        {
            SaveTransform(transform);
        }
    }

    private void SaveTransform(Transform transform)
    {
        binaryWriter.Write(transform.localPosition.x);
        binaryWriter.Write(transform.localPosition.y);
        binaryWriter.Write(transform.localPosition.z);
        binaryWriter.Write(transform.localScale.x);
        binaryWriter.Write(transform.localScale.y);
        binaryWriter.Write(transform.localScale.z);
    }

    private void LoadTransforms(Transform[] transforms)
    {
        foreach (Transform transform in transforms)
        {
            LoadTransform(transform);
        }
    }

    private void LoadTransform(Transform transform)
    {
        float x = binaryReader.ReadSingle();
        float y = binaryReader.ReadSingle();
        float z = binaryReader.ReadSingle();
        transform.localPosition = new Vector3(x, y, z);
        x = binaryReader.ReadSingle();
        y = binaryReader.ReadSingle();
        z = binaryReader.ReadSingle();
        transform.localScale = new Vector3(x, y, z);
    }
    private void SpawnPlayer()
    {
        Instantiate(prefab, playerspawn.position, Quaternion.identity);
        GetComponent<CharacterController>().enabled = false;
       
    }
}
