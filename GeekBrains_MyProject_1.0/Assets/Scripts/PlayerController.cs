using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed = 10f;
    [SerializeField] GameObject Camera;
    [SerializeField] Animator Animator;
    [SerializeField] float mouseSpeed;
    [SerializeField] GameObject Bullet;//только для визуализации
    [SerializeField] float Power;
    [SerializeField] bool HaveKey = false;
    [SerializeField] Animator animator_door;
    [SerializeField] GameObject text_end;
    private float MouseX;
    Rigidbody Rigidbody;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0, MouseX, 0);
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            Animator.SetBool("Walk", true);
        else
            Animator.SetBool("Walk", false);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject b = Instantiate(Bullet, transform.localPosition + new Vector3(1,1,0), Quaternion.Euler(0,0,90));
            b.GetComponent<Rigidbody>().AddForce((transform.right + new Vector3(0,0.1f,0)) * Power, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") != 0 && (Rigidbody.velocity.magnitude < 5 && Rigidbody.velocity.magnitude > -5))
        {
            Rigidbody.AddRelativeForce(new Vector3(Input.GetAxisRaw("Vertical") * Speed, 0, 0));
        }
        if (Input.GetAxisRaw("Horizontal") != 0 && (Rigidbody.velocity.magnitude < 5 && Rigidbody.velocity.magnitude > -5))
        {
            Rigidbody.AddRelativeForce(new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * Speed * -1));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Key")
        {
            HaveKey = true;
            Destroy(collision.gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            if (HaveKey)
            {
                animator_door.SetBool("HaveKey", true);
                text_end.SetActive(true);
            }
        }
    }
}
