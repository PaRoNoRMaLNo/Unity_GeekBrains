using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_fire : MonoBehaviour
{
    [SerializeField] GameObject Bullet_turel;
    [SerializeField] GameObject Turel;
    GameObject Player;
    bool isEnter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
            Turel.transform.LookAt(Player.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isEnter = true;
            Player = other.transform.gameObject;
            StartCoroutine(Fire());
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isEnter = false;
    }
    IEnumerator Fire()
    {
        if (isEnter)
        {
            GameObject b = Instantiate(Bullet_turel, transform.position, Quaternion.LookRotation(transform.position, Player.transform.position));
            b.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
            yield return new WaitForSeconds(2);
            StartCoroutine(Fire());
        }
    }
}
