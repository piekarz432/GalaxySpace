using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

   public Sprite[] Sprite;

   private Component[] ObjectChildren;

    int index;

    private void Start()
    {
        index=Losuj();
        Przypisz();
    }

    int Losuj()
    {
        var index = Random.Range(0, Sprite.Length);
        return index;
    }
    
    void Przypisz()
    {
        ObjectChildren = gameObject.GetComponentsInChildren<SpriteRenderer>();
        
        foreach(SpriteRenderer spr in ObjectChildren)
        {
            spr.GetComponent<SpriteRenderer>().sprite= Sprite[index];
        }
    }
}
