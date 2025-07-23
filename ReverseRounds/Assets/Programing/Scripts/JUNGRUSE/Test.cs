using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{

    public void OnClickButton()
    {
        PlayerStatManager.Instance.health += 5;
        PlayerStatManager.Instance.attack += 5;
        PlayerStatManager.Instance.attackSpeed += 5;
        PlayerStatManager.Instance.bulletSpeed += 5;
        PlayerStatManager.Instance.speed += 5;

        Debug.Log("HP: " + PlayerStatManager.Instance.health);
        Debug.Log("ATK: " + PlayerStatManager.Instance.attack);
        Debug.Log("ATKSPD: " + PlayerStatManager.Instance.attackSpeed);
        Debug.Log("BSPD: " + PlayerStatManager.Instance.bulletSpeed);
        Debug.Log("SPD: " + PlayerStatManager.Instance.speed);
    }

    [System.Serializable]
    public class StatData
    {
        public float health;
        public float attack;
        public float attackSpeed;
        public float bulletSpeed;
        public float speed;
    }


}
