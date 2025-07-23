using UnityEngine;
public class CardList
{
    public static CardList instance;
    public string Name;
    public string Description;
    public System.Action<PlayerManager> ApplyEffect;

    public CardList(string name, string description, System.Action<PlayerManager> effect)
    {
        Name = name;
        Description = description;
        ApplyEffect = effect;
    }

    public void Use(PlayerManager player)
    {
        ApplyEffect?.Invoke(player);
    }


    public static CardList jumpCard = new CardList(
    "점프 카드",
    "플레이어의 점프력 +2",
    (player) => player.jumpForce += 2);

    public static CardList rateCard = new CardList(
    "발사 쿨타임 카드",
    "플레이어의 발사 쿨타임 -0.2초",
    (player) => player.fireRate = Mathf.Max(0.1f, player.fireRate - 0.2f));



}