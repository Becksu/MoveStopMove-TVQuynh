using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public JoystickController joystick;
    public Rigidbody rb;
    public float speed;

    protected override void OnInit()
    {
        base.OnInit();
        joystick =  Instantiate(joystick, transform);
        rb = Cache.GetComponent<Rigidbody>(gameObject);
        ChangAnim(Constans.ANIM_IDLE);
    }

    protected override void OnUpdate()
    {
        if (!LevelManager.Ins.isStartGame)
        {
            joystick.gameObject.SetActive(false);
            return;
        }
        if (isDie)
        {
            joystick.gameObject.SetActive(false);
            return;
        }
        joystick.gameObject.SetActive(true);
        if (Input.GetMouseButton(0))
        {
            GetMove();
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = Vector3.zero;
            //rb.rotation = Quaternion.identity;
            ChangAnim(Constans.ANIM_IDLE);
            if (attacker.GetCharacterRange())
            {
                Atack();
            }
        }
    }
    protected override void OnFixUpdate()
    {

    }
    public override void Atack()
    {
        base.Atack();
        rb.velocity = Vector3.zero;
    }
    public void GetMove()
    {
        Vector3 dirc = joystick.direction;
        float angle = Mathf.Atan2(dirc.x, dirc.z) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0,angle,0);
        rb.velocity = dirc * speed * Time.deltaTime;
        rb.rotation = rotate;
        ChangAnim(Constans.ANIM_RUN);
    }
    public override void Death()
    {
        base.Death();
        rb.velocity = Vector3.zero;
    }

}
