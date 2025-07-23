using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletList : MonoBehaviour
{
    public bool isHoming = false;
    //public bool isRicochet = false;
    //public bool isStun = false;
    //public bool isPoison = false;
    //public bool isPlayerSeeking = false;

    //public bool isShotgun = false;
    //public bool isMultiShot = false;

    public float damageMultiplier = 1f;     // 공격력
    public float fireRateMultiplier = 1f;   // 공격속도

    public BulletList Clone()
    {
        return (BulletList)this.MemberwiseClone();
    }
}
