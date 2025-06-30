using UnityEngine;
using UnityEngine.Experimental.AI;


public class Card : MonoBehaviour
{
    public static Card instance;
    public string Name;
    public string Description;
    public System.Action<PlayerController> ApplyEffect;

    private void Awake()
    {
        instance = this;
    }
    public Card(string name, string description, System.Action<PlayerController> effect)
    {
        Name = name;
        Description = description;
        ApplyEffect = effect;
    }

    public void Use(PlayerController player)
    {
        ApplyEffect?.Invoke(player);
    }


    //카드 효과 개별적 

    /*
    // 예시: 체력 증가 카드
    Card healCard = new Card(
        "힐 카드",
        "플레이어의 체력을 20 회복합니다.",
        (player) => player.Heal(20)
    );


    */

    public static Card jumpCard = new Card(
        "점프 카드",
        "플레이어의 점프력 2배",
        (player) => player.jumpForce *= 2);


    public static Card rapidFireCard = new Card(
    "연사속도 업",
    "연사 속도가 빨라집니다.",
    (player) =>
    {
        if (player != null) player.fireRate *= 0.5f;
    }
);

    public static Card penetrationCard = new Card(
    "관통탄",
    "총알이 적을 관통합니다.",
    (player) =>
    {
        if (player != null) player.penetration = true;
    }
);

    public static Card ricochetCard = new Card(
        "도탄탄",
        "총알이 벽에 튕깁니다.",
        (player) => {
            if (player != null) player.ricochet = true;
        }
    );

    public static Card burstFireCard = new Card(
    "연발탄",
    "총알을 3연발로 발사합니다.",
    (player) => {
        if (player != null) player.burstCount = 3;
    }
);

    public static Card powerShotCard = new Card(
    "파워샷",
    "총알을 차지해 강력하게 발사합니다.",
    (player) => {
        if (player != null) player.canChargeShot = true;
    }
);

    public static Card multiShotCard = new Card(
    "멀티탄",
    "총알을 동시에 여러 발 발사합니다.",
    (player) => {
        if (player != null) player.multiShotCount = 3;
    }
);

}