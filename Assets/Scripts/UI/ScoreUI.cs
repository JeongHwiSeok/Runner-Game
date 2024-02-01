using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    private void Start()
    {
        StartCoroutine(increaseScore());
    }

    IEnumerator increaseScore()
    {
        while(GameManager.instance.state)
        {
            yield return CoroutineCache.waitForSeconds(0.25f);

            if(GameManager.instance.state == false)
            {
                yield break;
            }

            score = score + 10;
            DataManager.instance.score = score;

            scoreText.text = score.ToString() + "m";
        }
    }
}
