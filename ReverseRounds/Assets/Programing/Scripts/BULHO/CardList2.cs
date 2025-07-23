using UnityEngine;

public class CardList2
{
    public static CardList2 instance;
    public string Name;
    public string Description;
    public System.Action<PlayerManager2> ApplyEffect;

    public CardList2(string name, string description, System.Action<PlayerManager2> effect)
    {
        Name = name;
        Description = description;
        ApplyEffect = effect;
    }

    public void Use(PlayerManager2 player)
    {
        ApplyEffect?.Invoke(player);
    }

    public static CardList2 jumpCard = new CardList2(
        "점프 카드",
        "플레이어의 점프력 +2",
        (player) => player.jumpForce += 2);

    public static CardList2 rateCard = new CardList2(
        "발사 쿨타임 카드",
        "플레이어의 발사 쿨타임 -0.2초",
        (player) => player.fireRate = Mathf.Max(0.1f, player.fireRate - 0.2f));

    public static CardList2 homingCard = new CardList2(
        "유도탄 카드",
        "총알이 가장 가까운 적을 따라감",
        (player) => player.isHomingBullet = true);
}
