using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager2 : MonoBehaviour
{
    public static CardManager2 instance;

    // 최대 카드 개수 지정
    public int maxCardCount = 2;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    public List<CardList2> playerCards = new List<CardList2>();

    // 카드 추가
    public bool AddCard(CardList2 card, PlayerManager2 player)
    {
        if (playerCards.Count >= maxCardCount)
        {
            Debug.Log("최대 카드 개수에 도달했습니다.");
            return false;
        }
        playerCards.Add(card);

        // 카드를 얻자마자 효과 즉시 적용 (패시브 효과)
        card.Use(player);

        return true;
    }

    public void OnJumpCardButtonClick()
    {
        AddCard(CardList2.jumpCard, PlayerManager2.Instance);
    }

    public void OnRateCardButtonClick()
    {
        AddCard(CardList2.rateCard, PlayerManager2.Instance);
    }

    public void OnHomingCardButtonClick()
    {
        AddCard(CardList2.homingCard, PlayerManager2.Instance);
    }

}
