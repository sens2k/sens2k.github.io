using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    [SerializeField] private GameObject meteor;

    private Vector2 spawnPosition = new Vector2(12f, 0f);
    private float spawnTime = 1f;
    private int lastScore = 0;

    private void Start()
    {
        meteor.transform.localScale = new Vector2(1.2f, 1.2f);
        InvokeRepeating("ScoreAdd", 1.0f, 1.0f);
        StartCoroutine(SpawnMeteors());
    }

    IEnumerator SpawnMeteors() 
    {
        while(true)
        {
            Instantiate(meteor, spawnPosition, Quaternion.identity);
            spawnPosition.y = Random.Range(-4.5f, 5.5f);
            LevelHarder();
            yield return new WaitForSeconds(spawnTime);
        }
    }


    private void ScoreAdd()
    {
        ScoreManager.Instance.AddScore(1);
    }
    private void LevelHarder()
    {
        if (ScoreManager.Instance.Score - lastScore == 10)
        {
            if (spawnTime > 0.1)
            {
                meteor.transform.localScale = new Vector2(meteor.transform.localScale.x + 0.1f, meteor.transform.localScale.y + 0.1f);//Увеличивает противника
                lastScore += 10; 
                spawnTime -= 0.1f;//Уменьшает время спавна
            }
        }
    }
}
