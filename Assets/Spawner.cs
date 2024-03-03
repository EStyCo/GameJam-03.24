using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] Transform BotPoint;
    [SerializeField] Transform TopPoint;
    [SerializeField] Transform targetPoint;

    [Header("Enemy")]
    [SerializeField] GameObject enemy;

    public void StartScript()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        AudioManager.Instance?.OnDuhast();

        while (true) 
        { 
            var point = GetRandomPoint();

            GameObject instance = Instantiate(enemy, point, Quaternion.identity, transform);
            instance.GetComponent<Enemy>().SetTarget(targetPoint);

            yield return new WaitForSeconds(0.35f);
        }
    }

    private Vector2 GetRandomPoint()
    {
        float randomValue = Random.Range(0.15f, 0.851f);

        return Vector2.Lerp(TopPoint.position, BotPoint.position, randomValue);
    }
}
