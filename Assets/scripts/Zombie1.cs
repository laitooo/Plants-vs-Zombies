using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    public float defaultSpeed = 5f;
    public int defaultHealth = 20;
    private float speed;
    private int health;
    private Transform target;
    private int waveNumber;

    void Start() {
        health = defaultHealth;
        speed = defaultSpeed;
        int index = (int) (transform.position.x / 4);
        target = WayPoints.points[index];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f) {
            reachedEnd();
        }
    }

    void reachedEnd() {
        PlayerManager.instance.looseLife();
        Destroy(gameObject);
    }

    public void takeDamage(int amount) {
        health -= amount;
        if (health < 1) {
            die();
        }
    }

    void die() {
        // TODO: remove later
        MoneyManager.instance.Money += 50;
        Destroy(gameObject);
    }
}
