using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    public float speed = 2f;
    public int wavePointIndex = 0;
    private Transform target;

    void Start() {
        target = WayPoints.points[wavePointIndex];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f) {
            destroyObject();
        }
    }

    void destroyObject() {
        Destroy(gameObject);
    }
}
