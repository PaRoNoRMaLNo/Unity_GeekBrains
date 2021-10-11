using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scream : MonoBehaviour
{
    [SerializeField] float Time;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<AudioSource>().enabled = true;
            StartCoroutine(Scream_off());
        }
    }
    IEnumerator Scream_off()
    {
        yield return new WaitForSeconds(Time);
        gameObject.SetActive(false);
    }
}
