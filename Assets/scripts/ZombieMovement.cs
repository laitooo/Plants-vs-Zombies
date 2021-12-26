using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Zombie))]
public class ZombieMovement : MonoBehaviour {
    private Zombie zombie;
    private Transform target;
    private int waveNumber;

    void Start() {
        zombie = GetComponent<Zombie>();
        int index = (int) (transform.position.x / 4);
        target = WayPoints.points[index];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * zombie.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f) {
            reachedEnd();
        }

        if (zombie.slownessTimer <= 0f) {
            zombie.speed = zombie.defaultSpeed;
        } else {
            zombie.slownessTimer -= Time.deltaTime;
        }
    }

    void reachedEnd() {
        PlayerManager.instance.looseLife();
        Destroy(gameObject);
    }
}
