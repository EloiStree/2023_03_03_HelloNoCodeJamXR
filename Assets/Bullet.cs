using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    void Start()
    {
        // Destroy the bullet after a specified lifetime
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet forward
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when it collides with an object
        Destroy(gameObject);
    }
}
