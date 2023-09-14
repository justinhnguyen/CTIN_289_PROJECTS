using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    int money;
    bool inNewTowerMode = false;

    [SerializeField]
    int startingMoney;

    [SerializeField]
    TMPro.TextMeshProUGUI moneyUI;

    List<Tower> towerList;

    // Start is called before the first frame update
    void Start() {
        towerList = new List<Tower>();
        money = startingMoney;
    }

    // Update is called once per frame
    void Update() {

        moneyUI.text = "$" + money.ToString();

    }

    public bool IsInTowerSpawnMode() {
        return inNewTowerMode;
    }

    public void HandleNewTowerButton() {

        bool hasTheMoney = money >= 2;

        if (hasTheMoney && !inNewTowerMode) {
            inNewTowerMode = true;
        }

    }

    public void HandleUpgradeButton() {

        bool hasTheMoney = money >= 10;

        if (hasTheMoney && !inNewTowerMode) {
            UpgradeAllTowers();
        }

    }

    public void HandleTowerSpawned(Tower newTower) {

        money -= 2;
        towerList.Add(newTower);

        inNewTowerMode = false;

    }

    public void HandleKillCreep() {
        money += 1;
    }

    private void UpgradeAllTowers() {

        money -= 10;

        foreach (Tower eachTower in towerList) {
            eachTower.Upgrade();
        }

    }

}
