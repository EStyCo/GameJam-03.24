using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHome : MonoBehaviour
{
    public bool isActiveQuest = false;  
    [SerializeField] private Player player;

    void Start()
    {
        player.StartDialoge("� �������� � ����� � �������");
    }
}
