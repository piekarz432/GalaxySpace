using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    [SerializeField]
    List<Text> Points = new List<Text>();
    [SerializeField]
    List<Text> Name = new List<Text>();

    public List<string> points = new List<string>();
    public List<string> names = new List<string>();


    [SerializeField]
    GameObject HighScorePanel;

    HighScoreMenu highScoreMenu;


    public List<string> score = new List<string>();
    public void LoadGame()
    {
        Debug.Log(Application.persistentDataPath);
        HighScorePanel.SetActive(true);
        string[] lines = System.IO.File.ReadAllLines(Application.persistentDataPath+"gamesave.txt");
        using (FileStream fs = new FileStream(Application.persistentDataPath + "gamesave.txt", FileMode.Open, FileAccess.Read))
        {
            using (BinaryReader r = new BinaryReader(fs))
            {
                foreach (string line in lines)
                {
                    Debug.Log("\t" + line);
                    score.Add(line);
                }
            }
        }
        score.Sort();
        score.Reverse();
        Odczyt(score);

        foreach (string a in score)
        {
            SplitString(a);
        }

        for(int i=0; i<Name.Count; i++)
        {
            Name[i].text = names[i];
            Points[i].text = points[i];
        }
       
    }


    void Odczyt(List<string> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            char[] b = new char[lista[i].Length];
            b = lista[i].ToCharArray();
        }
    }
    void SplitString(string napis)
    {
        string[] words = napis.Split(':');

        foreach (var word in words)
        {
            Debug.LogFormat($"<{word}>");
        }

        points.Add(words[0]);
        names.Add(words[1]);



        //for (int i = 0; i < c.Length; i++)
        //{
        //    Debug.Log(c[i]);
        //}
    }
}
