using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

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

    public List<CardList> playerCards = new List<CardList>();

    // 카드 추가
    public bool AddCard(CardList card, PlayerManager player)
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
        AddCard(CardList.jumpCard, PlayerManager.Instance);
    }

    public void OnRateCardButtonClick()
    {
        AddCard(CardList.rateCard, PlayerManager.Instance);
    }


}
