using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Medal : MonoBehaviour
{
    [SerializeField] private Sprite metal;
    [SerializeField] private Sprite bronze;
    [SerializeField] private Sprite silver;
    [SerializeField] private Sprite gold;

    private Image medal;

    private void Awake()
    {
        medal = GetComponent<Image>();
    }

    private void Update()
    {
        if (GameManager.gameScore > 0 && 
            GameManager.gameScore < 2)
        {
            medal.sprite = bronze;
        }
        else if (GameManager.gameScore > 1 &&
            GameManager.gameScore < 3)
        {
            medal.sprite = silver;
        }
        else if (GameManager.gameScore > 2 &&
            GameManager.gameScore < 4)
        {
            medal.sprite = gold;
        }
        else
        {
            medal.sprite = metal;
        }
    }

}
