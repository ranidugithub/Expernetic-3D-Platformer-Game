using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour
{
    public AudioSource coinSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
          ScoreManager.sManager.IncreaseScore(10);
          coinSound.Play();
          Destroy(this.gameObject);
        }
    }
}
