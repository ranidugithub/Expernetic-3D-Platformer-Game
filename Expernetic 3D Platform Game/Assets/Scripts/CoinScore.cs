using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          ScoreManager.sManager.IncreaseScore(10);
          Destroy(this.gameObject);
        }
    }
}
