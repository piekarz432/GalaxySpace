using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BossType
{
    public Sprite ImageBoss;
    public float Health=10f;
}
public class Boss : MonoBehaviour
{
    [SerializeField]
    BossType boss;

    [SerializeField]
    float StartPositionBoss;

    [SerializeField]
    float EndPositionBoss;

    [SerializeField]
    float Health;

    [SerializeField]
    Slider HealthBar;

    [SerializeField]
    float SpeedBoss = 0.6f;

    private Vector3 newposition;


    private void Awake()
    {
        Configure(boss);
    }

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private void Configure(BossType boss)
    {
        GetComponent<SpriteRenderer>().sprite = boss.ImageBoss;
        Health = boss.Health;
        HealthBar.maxValue = Health;
        HealthBar.value = HealthBar.maxValue;
    }

    private void MoveBoss()
    {
        float currentposition = Mathf.Lerp(StartPositionBoss, EndPositionBoss, Mathf.PingPong(Time.time * SpeedBoss, 1));
        transform.position = new Vector2(currentposition, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var obj = other.gameObject;
        var bullet = obj.GetComponent<Bullet>();

        if (bullet != null && bullet.tag!="Bullet")
        { 
            Health -= bullet.Power;
            HealthBar.value -= bullet.Power;
            Destroy(obj);

            if(Health<=0)
            {
                Destroy(this.gameObject);
            }

        }
    }

    private IEnumerator MoveCoroutine()
    {
        bool random = false;
        bool firstPlay = true;
        while (true)
        {
            if (firstPlay)
            {
                
                transform.position = new Vector3(0f , 2f, transform.position.z);
                newposition = new Vector3((int)Random.Range(-2, 2), (int)Random.Range(3, 1), transform.position.z);
                random = true;
                yield return new WaitForSeconds(1f);

                while (random)
                {
                    transform.position = Vector3.Lerp(transform.position, newposition, Time.deltaTime*3);

                    if (transform.position == newposition)
                    {
                        random = false;
                        firstPlay = false;
                    }
                    yield return new WaitForEndOfFrame();

                }
            }else if(!firstPlay)
            {
                transform.position = newposition;
                newposition = new Vector3((int)Random.Range(-2, 2), (int)Random.Range(2.5f, 1), transform.position.z);
                random = true;

                while (random)
                {
                    transform.position = Vector3.Lerp(transform.position, newposition, Time.deltaTime*3);

                    if (transform.position == newposition)
                    {
                        random = false;
                    }
                    yield return new WaitForEndOfFrame();
                }
            }

        }
    }
}
