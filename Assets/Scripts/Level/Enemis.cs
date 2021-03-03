using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

[System.Serializable]
public class TypeEnemis
{
    public Sprite Image;
    public int Health;
    public int Money;
    public int Points;
}

public class Enemis : MonoBehaviour
{
    [SerializeField]
    public float Health;

    [SerializeField]
    GameObject Explosion;

    [SerializeField]
    GameObject DestroingEnemis;

    [SerializeField]
    Slider EnemyHealth;

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private int Money;
    [SerializeField]
    private int Points;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpeedEnemis();
    }

    public void Configure(TypeEnemis typeEnemis)
    {
        spriteRenderer.sprite = typeEnemis.Image;
        Health = typeEnemis.Health;
        Money = typeEnemis.Money;
        Points = typeEnemis.Points;
        EnemyHealth.maxValue = Health;
        EnemyHealth.value = EnemyHealth.maxValue;
    }

    private void SpeedEnemis()
    {
        var targetSpeed = 2f;
        GetComponent<Rigidbody2D>().velocity = Vector3.down * targetSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var obj = other.gameObject;
        var bullet = obj.GetComponent<Bullet>();

        if (bullet != null)
        {
            GenerateParticle(DestroingEnemis, other.transform.position);

            Health -= bullet.Power;
            EnemyHealth.value -= bullet.Power;
            Destroy(obj);

            if (Health <= 0)
            {
                GenerateParticle(Explosion, other.transform.position);
                FindObjectOfType<GameManager>().Money += Money;
                FindObjectOfType<GameManager>().Points += Points;
                //FindObjectOfType<QuestCounter>().CounterDestroyedEnemis += 1;
                Destroy(gameObject);
            }
        }
    }

    private void GenerateParticle(GameObject prefab, Vector3 position)
    {
        var particles = Instantiate(prefab, position, Quaternion.identity);
    }
}
