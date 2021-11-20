using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [System.Serializable]
    private enum ItemType
    {
        Food
    };
    [SerializeField] ItemType itemType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {

            switch (itemType)
            {
                case ItemType.Food:
                    if (Player.Instance.GetWeight() < Player.Instance.maxWeight)
                    {
                        Player.Instance.IncreaseWeight();
                        Destroy(gameObject);
                    }
                    break;              
                default:
                    break;
            }            
        }
    }
}
