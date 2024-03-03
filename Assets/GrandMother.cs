using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandMother : MonoBehaviour
{
    [SerializeField] private List<string> text;
    [SerializeField] private QuestHome questHome;
    public bool isActive = false;
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
            if (!questHome.isActiveQuest)
            {
                player.StartDialoge(text[0]);
                questHome.isActiveQuest = true;
            }
            else 
            {
                player.StartDialoge(text[1]);
                StartCoroutine(LoadNewScene());
            }
        }
    }

    private IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(2);
    }
}
