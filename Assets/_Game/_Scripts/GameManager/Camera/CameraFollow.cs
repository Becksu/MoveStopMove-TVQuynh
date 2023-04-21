using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Transform starPos;
    public Transform newPos;
    public Vector3 distance;
    public bool isCamera;

    private void Start()
    {
        isCamera = false;
    }
    private void LateUpdate()
    {
        if (!player)
        {
            player = LevelManager.Ins.player;

        }
        if (!LevelManager.Ins.isStartGame)
        {
            transform.position = starPos.position;
            transform.rotation = starPos.rotation;
        }
        if(LevelManager.Ins.isStartGame&&!isCamera)
        {

            transform.position = Vector3.Lerp(transform.position, newPos.position, 3f * Time.deltaTime);
            transform.rotation = newPos.rotation;
            Invoke(nameof(IsCam), 1f);
        }
        if(LevelManager.Ins.isStartGame && isCamera)
        {
            transform.position = player.tF.position - distance;
            transform.rotation = newPos.rotation;
        }
    }
    public void IsCam()
    {
        isCamera = true;
        distance = player.transform.position - transform.position;
    }
}
