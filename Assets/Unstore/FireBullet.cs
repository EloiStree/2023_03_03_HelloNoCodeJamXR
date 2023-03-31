using UnityEngine;
using UnityEngine.Events;

public class FireBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 10f;

    public UnityEvent m_onBulletFire;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireABullet();
        }
    }

    [ContextMenu("FireABullet")]
    public void FireABullet()
    {   
        // Instantiate the bullet prefab at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Set the bullet's speed
        bullet.GetComponent<Bullet>().speed = bulletSpeed;
        m_onBulletFire.Invoke();
    }
}
