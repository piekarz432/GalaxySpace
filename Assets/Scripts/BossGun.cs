using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeBoss {Red, Green, Yellow }

public class BossGun : MonoBehaviour
{

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    BulletType BossBullet;

    [SerializeField]
    private TypeBoss TypeBoss;

    float LastShootTime = 0f;


    // Update is called once per frame
    void Update()
    {
        if (!CanShoot())
            return;

        ShotBullets();
        LastShootTime = Time.timeSinceLevelLoad;
    }


    public void ShootBullet(Vector3 postion, Vector3 rotation)
    {
        var bullet = Instantiate(Bullet, transform.position + postion + Vector3.down * 0.2f, Quaternion.Euler(rotation));
        bullet.GetComponent<Bullet>().ConfigureBulletBoss(BossBullet);
    }

    private void ShotBullets()
    {
        if (TypeBoss == TypeBoss.Green)
        {
            if (BossBullet.CannonType == CannonType.Boss)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.08f+ Vector3.down * 1.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.12f + Vector3.down * 1.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.left * 1.56f + Vector3.up* 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.left * 1.37f + Vector3.up * 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 1.56f + Vector3.up * 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 1.37f + Vector3.up * 0.57f, Vector3.zero);
            }
        }

        if (TypeBoss == TypeBoss.Yellow)
        {
            if (BossBullet.CannonType == CannonType.Boss)
            {
                ShootBullet(Vector3.zero + Vector3.left * 0.08f + Vector3.down * 1.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 0.12f + Vector3.down * 1.6f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.left * 1.56f + Vector3.up * 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.left * 1.37f + Vector3.up * 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 1.56f + Vector3.up * 0.57f, Vector3.zero);
                ShootBullet(Vector3.zero + Vector3.right * 1.37f + Vector3.up * 0.57f, Vector3.zero);
            }
        }
    }

    public bool CanShoot()
	{
		return (Time.timeSinceLevelLoad - LastShootTime >= BossBullet.ShootDuration);
	}
}
