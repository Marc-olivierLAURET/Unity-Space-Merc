using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public AudioSource MainMusic;
    public AudioSource Alarm = null;
    public AudioSource EndMusic;


    public Image BackGroundImage;
    public Text GameOverLabel;
    public Color BackColor = new Color(0.1226415f, 0.1226415f, 0.1226415f);
    public Color LabelColor = new Color(0.9f, 0f, 0f);

    public GameObject RestartButton;
    public GameObject QuitButton;

    private float BackOpacity = 0f;
    private float LabelOpacity = 0f;

    public float wait_1 = 3f;
    public float wait_2 = 5.5f;
    public float wait_3 = 7.5f;

    private bool is_Dead = false;
    private bool done = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (is_Dead && !done) {
            if (wait_1 < Time.time && BackOpacity <= 1f) {
                BackOpacity += 0.5f * Time.deltaTime;
                MainMusic.volume = 1f - BackOpacity;
                if (Alarm)
                    Alarm.volume = 1f - BackOpacity;
                BackColor.a = BackOpacity;
                BackGroundImage.color = BackColor;
            }
            if (wait_2 < Time.time && LabelOpacity <= 1f) {
                LabelOpacity += 0.6f * Time.deltaTime;
                EndMusic.volume = LabelOpacity;
                LabelColor.a = LabelOpacity;
                GameOverLabel.color = LabelColor;
            }
            if (wait_3 < Time.time) {
                RestartButton.SetActive(true);
                QuitButton.SetActive(true);
                done = true;
            }
        }
    }

    public void SetDead() {
        wait_1 += Time.time;
        wait_2 += Time.time;
        wait_3 += Time.time;
        is_Dead = true;
        
        
    }
}
