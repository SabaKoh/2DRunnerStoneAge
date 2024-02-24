using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    void Update()
    {
        Vector3 position = Player.transform.position;
        position.z = -10f;
        transform.position = position;
    }
}
