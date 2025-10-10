using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootInterval = 2f;
    public bool facingRight = true;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        // ’e‚ğ¶¬
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Œü‚«î•ñ‚ğ’e‚É“n‚·
        bullet.GetComponent<Bullet>().SetDirection(facingRight);
    }
}
