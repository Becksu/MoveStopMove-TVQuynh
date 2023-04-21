using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public Transform bulletModel;
    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnInit()
    {
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
    }
    protected override void Move()
    {
        tF.Translate(direction * speed * Time.deltaTime);
        float distance = Vector3.Distance(tF.position, target);
        target.y = tF.position.y;
        if (distance > 0.1f) return;
        SimplePool.Despawn(this);
        bulletModel.rotation = Quaternion.LookRotation(direction);
    }

    protected override void IsTouch()
    {
        SimplePool.Despawn(this);
    }
    public override void GetTarget()
    {
        target = tF.position + (direction.normalized * maxSize);
        // tF.LookAt(direction);
    }
    public override float GetBoundSize(Collider collider)
    {
        maxSize = collider.bounds.size.magnitude / 3;
        return maxSize;
    }
}
