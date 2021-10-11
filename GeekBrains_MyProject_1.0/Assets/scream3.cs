using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scream3 : MonoBehaviour
{
    [SerializeField] GameObject Scream3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Scream3.SetActive(true);
            StartCoroutine(Screm3());
        }
    }
    IEnumerator Screm3()
    {
        yield return new WaitForSeconds(3);
        Destroy(Scream3);
    }
}
