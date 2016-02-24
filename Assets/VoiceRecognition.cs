using UnityEngine;
using System.Collections;

public class VoiceRecognition : MonoBehaviour {

    AudioClip clip;
    bool recordingStarted = false;
    float[] data;
    TextAsset binAudioData = (TextAsset)Resources.Load("data.byte");

	// Use this for initialization
	void Start () {
        Application.RequestUserAuthorization(UserAuthorization.Microphone);
	}
	
	// Update is called once per frame
	void Update () {
        if (recordingStarted && !Microphone.IsRecording(null)) {
            data = new float[clip.samples * clip.channels];
            clip.GetData(data, 0);
            binAudioData.
            //Debug.Log(clip.samples + " Samples.  " + clip.channels + " Channels.  " + clip.samples * clip.channels + " Bytes.");
        }

	}

    public void StartRecord() {
        clip = Microphone.Start(null, false, 2, 44100);
        recordingStarted = true;
    }

    public void StopRecord() {
        //Microphone.End(null);
    }

    public void PlayBack() {
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }
}
