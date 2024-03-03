using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private string text;
    private bool isActive = false;
    private bool isReady = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
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
            !isActive &&
            collision.gameObject.TryGetComponent(out Player player) &&
            Input.GetKey(KeyCode.F))
        {
            isActive = true;
            player.StartDialoge(text);
        }
    }
}
