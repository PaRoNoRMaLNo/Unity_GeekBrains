using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float seeDistance = 5f;
    //дистанция до атаки
    public float attackDistance = 2f;
    //скорость енеми
    public float speed = 6;
    //игрок
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > attackDistance)
            {
                transform.LookAt(target.transform);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
            Destroy(gameObject);
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}
