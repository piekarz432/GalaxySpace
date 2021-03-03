using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum QuestType { CounterDestroyedAsteroids, CounterDestroyedEnemis, CounterDestroyedBoss, CounterMoney }

public class QuestLine : MonoBehaviour
{

    public QuestType QuestType;

    public Text NameQuest;

    public Text QuestReward;

    public Button buttonReward;

    public int Counter;

}
