
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
     public int coinsCount;
    public Text coinsCountText;


    public static Inventory instance;

    private void Awake()
    {

        if(instance != null)
        {
            Debug.LogWarning("Plafond Inventaire");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    
}
