using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    public GameObject buttonText;


    public void MuteSound(AudioSource audio)
    {
        audio.mute = !audio.mute;
        Text muteStatusText = this.buttonText.GetComponent<Text>();

        if (audio.mute)
        {
            muteStatusText.text = "Music Off";
        }
        else
        {
            muteStatusText.text = "Music On";
        }
    }
}
