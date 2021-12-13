using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Text countDownText;
    public float timeBetweenWaves = 5f;
    private float countDown = 0f;
    private int waveIndex = 0;

    void Start() {
        
    }

    void Update() {
        if (countDown <= 0f) {
            StartCoroutine(spawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
        countDownText.text = Mathf.Round(countDown).ToString();
    }
    
    IEnumerator spawnWave() {
        waveIndex++;
        for (int i=0; i<waveIndex; i++) {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void spawnEnemy() {
        int x = Random.Range(0, 5);
        Instantiate(enemyPrefab, new Vector3(x * 4.1f, 1.5f, 28.7f), Quaternion.Euler(0, 0, 0));
    }
}
