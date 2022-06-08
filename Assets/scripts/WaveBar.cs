using UnityEngine.UI;
using UnityEngine;

public class WaveBar : MonoBehaviour
{

    public static WaveBar instance;    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one wave bar manager in the scene!");
            return;
        }
        instance = this;
    }

    public Slider waveSlider;
    private float time = 0f;
    private float countDown = 0f;
    [Header("HideInInspector")]
    public bool isPaused = true;

    public void startBar(float time) {
        this.time = time;
        waveSlider.maxValue = time;
        countDown = 0f;
        waveSlider.value = countDown;
        isPaused = false;
    }

    public void pause() {
        isPaused = true;
    }

    public void resume() {
        isPaused = false;
    }

    void Update()
    {
        if (!isPaused){
            if (countDown < time) {
                countDown += Time.deltaTime;
                waveSlider.value = countDown;
            }
        }
    }
}
