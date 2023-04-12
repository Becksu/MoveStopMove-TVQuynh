using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Vector3 distance;
    private void LateUpdate()
    {
        if (!player)
        {
            player = LevelManager.Ins.player;
            distance = player.transform.position - transform.position;
        }
        transform.position = player.transform.position - distance;
    }
}
