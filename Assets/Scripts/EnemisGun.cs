using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemisGun : MonoBehaviour
{
        [SerializeField]
        GameObject Bullet;

        [SerializeField]
        BulletType BossBullet;

        float LastShootTime = 0f;

        CannonType CurrentGun;

        void Start()
        {
            //var CurrentGun = (CannonType)Random.Range(0, System.Enum.GetValues(typeof(CannonType)).Length);

            //BossBullet.CannonType = CurrentGun;
        }

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
            if (BossBullet.CannonType == CannonType.Single)
            {
                ShootBullet(Vector3.zero + Vector3.down * 0.4f, Vector3.zero);
            }
            /*
            else if (BossBullet.CannonType == CannonType.Double)
            {
                ShootBullet(Vector3.left * 0.7f, Vector3.forward * 6f);
                ShootBullet(Vector3.right * 0.7f, Vector3.back * 5f);

            }
            else if (BossBullet.CannonType == CannonType.Triple)
            {
                ShootBullet(Vector3.zero + Vector3.down * 0.4f, Vector3.zero);
                ShootBullet(Vector3.left * 0.7f, Vector3.forward * 5f);
                ShootBullet(Vector3.right * 0.7f, Vector3.back * 5f);
            }
            */
        }

        public bool CanShoot()
        {
            return (Time.timeSinceLevelLoad - LastShootTime >= BossBullet.ShootDuration);
        }
}
