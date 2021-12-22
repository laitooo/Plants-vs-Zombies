using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour {

    public static MoneyManager instance;    
    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one moeny manager in the scene!");
            return;
        }
        instance = this;
    }

    public int Money;
    public Text moneyCounter;
    public int startMoney = 400;

    void Start() {
        Money = startMoney;
        updateText();
    }    

    public void useMoney(int amount) {
        Money -= amount;
        updateText();
    }

    void updateText() {
        moneyCounter.text = "Money = " + Money.ToString() + "$";
    }
}
