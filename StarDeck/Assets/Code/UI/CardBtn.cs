using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBtn : MonoBehaviour
{
    [SerializeField] private GameObject _yourCards;
    [SerializeField] private GameObject _deckCards;
    [SerializeField] private GameObject _card;
    private bool _isOnDeck = false;

    public void Add2Deck ()
    {
        if (_isOnDeck)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            CardBtn[] ts = _deckCards.GetComponentsInChildren<CardBtn>();
            Debug.Log(ts.Length);
            if (ts.Length < 18)
            {
                GameObject card = Instantiate(_card, new Vector3 (0,0,0), Quaternion.identity) as GameObject;
                card.GetComponent<CardBtn>().SetIsOnDeck(true);
                card.transform.SetParent(_deckCards.transform);
            }
        }
        
    }

    public void SetIsOnDeck (bool state)
    {
        _isOnDeck = state;
    }
}
