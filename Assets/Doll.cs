using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] QuestHome questHome;
    [SerializeField] GrandMother grandMother;
    private bool isReady = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (questHome.isActiveQuest && 
            collision.gameObject.TryGetComponent(out Player player))
        {
            isReady = true;
            player.ShowActionPanel(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            isReady = false;
            player.ShowActionPanel(false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isReady &&
            questHome.isActiveQuest &&
            collision.gameObject.TryGetComponent(out Player player) &&
            Input.GetKey(KeyCode.F))
        {
            
            player.StartDialoge(text);
            player.TakeDoll();
            questHome.isActiveQuest = true;
            grandMother.isActive = false;
            gameObject.SetActive(false);
        }
    }
}
