using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    public float speed = 1f;
    private Transform target;
    private int waveNumber;

    void Start() {
        int index = (int) (transform.position.x / 4);
        Debug.Log("x = " + transform.position.x + " index = " + index + " correct = " + (transform.position.x / 4.1f));
        target = WayPoints.points[index];
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
