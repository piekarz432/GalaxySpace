using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterType
{
    public Sprite splash;
}


public class SelectCharacter : MonoBehaviour
{

    [SerializeField]
    List<CharacterType> characterList= new List<CharacterType>();

    [HideInInspector]
    public int SelecetedCharacterIndex;

    [SerializeField]
    Image CharacterSplash;


    // Start is called before the first frame update
    void Start()
    {
        
        UpdateCharacter();
        DontDestroyOnLoad(gameObject);
    }

    private void UpdateCharacter()
    {
        CharacterSplash.sprite =characterList[SelecetedCharacterIndex].splash;
    }

    public void  LeftArrow()
    {
        SelecetedCharacterIndex--;
        if(SelecetedCharacterIndex<0)
        {
            SelecetedCharacterIndex = characterList.Count - 1;
        }
        UpdateCharacter();
    }

    public void RightArrow()
    {
        SelecetedCharacterIndex++;
        if (SelecetedCharacterIndex== characterList.Count)
        {
            SelecetedCharacterIndex = 0;
        }
        UpdateCharacter();
    }
}
