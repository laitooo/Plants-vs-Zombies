using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {
    public static int zombiesAlive = 0;
    public Transform enemyPrefab;
    public Text countDownText;
    public float timeBetweenWaves = 5f;
    private float countDown = 0f;
    private int waveIndex = 0;
    public Wave[] waves;

    void Start() {
        countDown = timeBetweenWaves;
    }

    void Update() {
        if (zombiesAlive > 0) {
            return;
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
        for (int i=0; i<wave.numberZombies; i++) {
            spawnEnemy(wave.zombie);
            yield return new WaitForSeconds(wave.spawnDelay);
        }
        waveIndex++;

        if (waveIndex == waves.Length) {
            Debug.Log("You won");
            this.enabled = false;
        }
    }

    void spawnEnemy(GameObject prefab) {
        int x = Random.Range(0, 5);
        Instantiate(prefab, new Vector3(x * 4.1f, 1.5f, 28.7f), Quaternion.Euler(0, 0, 0));
        zombiesAlive++;
    }
}
