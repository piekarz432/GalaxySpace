using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnEnemis : MonoBehaviour
{
    [SerializeField]
    GameObject Enemis;

    [SerializeField]
    TypeEnemis[] typeEnemis;

    [SerializeField]
    public float SpawnTime = 2f;

    public bool Spawning = true;

    public int EnemisLevel { get; set; }
    public int EnemisRange { get; set; }


    // Use this for initialization
    void Start()
    {
        EnemisLevel = 0;
        EnemisRange = 5;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            while (Spawning)
            {
                SpawnEnemi();
                yield return new WaitForSeconds(SpawnTime);
            }

            yield return new WaitForEndOfFrame();
        }

    }
    private TypeEnemis RandomType()
    {
        var index = EnemisLevel + Random.Range(-EnemisRange, EnemisRange);
        index = Mathf.Clamp(index, 0, typeEnemis.Length - 1);
        return typeEnemis[index];
    }

    private void SpawnEnemi()
    {
        var obj = Instantiate(Enemis, transform.position, Quaternion.identity);
        obj.transform.position += Vector3.right * Random.Range(-2f, 2f);
        var enemisType = RandomType();
        obj.GetComponent<Enemis>().Configure(enemisType);
    }


}

