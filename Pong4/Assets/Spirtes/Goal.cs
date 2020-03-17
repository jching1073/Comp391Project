using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ball>())
        {
            //todo score goal to the other player
            GameManager.Instance.Score(player);
        }
    }
}
