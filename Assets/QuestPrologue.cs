using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPrologue : MonoBehaviour
{
    [SerializeField] GameObject scoreTable;
    [SerializeField] GameObject wall;
    [SerializeField] int topCamera;
    [SerializeField] int botCamera;
    [SerializeField] Player player;
    [SerializeField] Transform deliriumPosition;
    [SerializeField] PolygonCollider2D largeConfiner;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] CinemachineConfiner confiner;
    [SerializeField] GameObject shoot;
    [SerializeField] Spawner spawner;
    [SerializeField] GameObject soldier;

    void Start()
    {
        player.MoveValue(true);
    }

    public void OnDeliriumMode()
    {
        virtualCamera.Follow = null;
        virtualCamera.m_Lens.OrthographicSize = 250;
        confiner.m_BoundingShape2D = largeConfiner;

        player.gameObject.transform.position = deliriumPosition.position;
        player.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        soldier.SetActive(false);
        wall.SetActive(true);
        shoot.SetActive(true);
        scoreTable.SetActive(true);

        spawner.StartScript();

        StartCoroutine(RideCamera());
    }

    private IEnumerator RideCamera()
    {
        var cameraPosition = virtualCamera.gameObject.transform.position;
        while (true)
        {
            while (virtualCamera.gameObject.transform.position.y < topCamera)
            {
                float randomDelay = Random.Range(0f, 0.08f);
                float random = Random.Range(0f, 30f);
                var position = virtualCamera.gameObject.transform.position;

                Vector3 newPosition = new Vector3(position.x, position.y + random, position.z);
                virtualCamera.gameObject.transform.position = newPosition;

                yield return new WaitForSeconds(randomDelay);
            }
            while (virtualCamera.gameObject.transform.position.y > botCamera)
            {
                float randomDelay = Random.Range(0f, 0.08f);
                float random = Random.Range(0f, 30f);
                var position = virtualCamera.gameObject.transform.position;

                Vector3 newPosition = new Vector3(position.x, position.y - random, position.z);
                virtualCamera.gameObject.transform.position = newPosition;

                yield return new WaitForSeconds(randomDelay);
            }
        }
    }
}
