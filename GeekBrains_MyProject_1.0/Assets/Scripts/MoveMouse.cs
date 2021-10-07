using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{

    public GameObject player; // Перетащить в капсулу на переднем плане
    Vector3 rot = new Vector3(0, 0, 0); // Сначала определите переменную rot типа Vectory3 (0,0,0)
    public float speed; // Это чувствительность мыши
    void Start()
    {

    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * speed;
        float MouseY = Input.GetAxis("Mouse Y") * speed;
        rot.x = rot.x - MouseY;
        rot.y = rot.y + MouseX;
        rot.z = 0; // Заблокировать ось z угла движения камеры, чтобы предотвратить наклон влево и вправо
        transform.eulerAngles = rot; // После того, как все направления установлены,ВЭБ-камераУгол = вращение
        player.transform.eulerAngles = new Vector3(0, rot.y, 0);  // Угол персонажа можно изменить только с помощью MouseX, то есть заблокировать rot.y
    }
}