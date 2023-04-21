using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomerang : Weapon
{
    public bool isBom;
    protected override void OnInit()
    {
        base.OnInit();
        isBom = false;
    }
    protected override void Move()
    {
        if (!isBom)
        {
            tF.Translate(direction * speed * Time.deltaTime);
            float distance = Vector3.Distance(tF.position, target);
            target.y = tF.position.y;
            if (distance < 0.1f)
            {
                isBom = true;
            }
        }
        else
        {
            tF.position = Vector3.MoveTowards(tF.position, pointWeaponStart, speed * 2 * Time.deltaTime);
            pointWeaponStart.y = tF.position.y;
            if (Vector3.Distance(tF.position, pointWeaponStart) > 0.1f) return;
            isBom = false;
            SimplePool.Despawn(this);
        }
    }
    protected override void IsTouchBox()
    {
        SimplePool.Despawn(this);
    }
    public override void GetTarget()
    {
        target = tF.position + (direction.normalized * maxSize);
    }
    public override float GetBoundSize(Collider collider)
    {
        maxSize = collider.bounds.size.magnitude / 3;
        return maxSize;
    }
}
