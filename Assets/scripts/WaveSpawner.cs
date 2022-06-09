using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {
    public static int zombiesAlive;
    public Transform enemyPrefab;
    public Text countDownText;
    public float timeBetweenWaves = 5f;
    private float countDown = 0f;
    private int waveIndex = 0;
    public Wave[] waves;
    public Transform[] spawnPositions;

    void Start() {
        countDown = timeBetweenWaves;
        zombiesAlive = 0;
    }

    void Update() {
        if (zombiesAlive > 0) {
            return;
        }
        
        if (waveIndex == waves.Length) {
            // TODO: do animation here
            GameManager.instance.wonLevel();
            this.enabled = false;
        }

        if (countDown <= 0f) {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
            return;
        }


        countDown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
    }
    
    IEnumerator spawnWave() {
        PlayerManager.instance.rounds++;
        Wave wave = waves[waveIndex];
        float t = 0f;
        t += (wave.numberZombies * wave.spawnDelay);
        WaveBar.instance.startBar(t);

        for (int i=0; i<wave.numberZombies; i++) {
            spawnEnemy(wave.zombie);
            yield return new WaitForSeconds(wave.spawnDelay);
        }
        waveIndex++;
    }

    void spawnEnemy(GameObject prefab) {
        int x = Random.Range(0, 5);
        Instantiate(prefab, spawnPositions[x].position, Quaternion.Euler(0, 0, 0));
        zombiesAlive++;
    }
}
