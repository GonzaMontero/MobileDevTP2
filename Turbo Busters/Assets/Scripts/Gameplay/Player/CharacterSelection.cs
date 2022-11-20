using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    PlayerManager pm;

    public MainMenuButtonFunctions mainMenuButtonFunctions;

    public GameObject prntChooseCharacters;
    public Button[] selectionButtons;

    public GameObject prntBuySelection;
    public Button buyButton;
    public Button backButton;

    public TextMeshProUGUI buyText;
    public TextMeshProUGUI currentMoneyText;
    public TextMeshProUGUI requiredMoneyText;

    void Start()
    {
        pm = PlayerManager.instance;
        int i = 0;

        foreach(Button b in selectionButtons)
        {
            if(pm.charactersBought[i] == PlayerManager.BuyState.NotBought)
            {
                int y = i;
                b.onClick.AddListener(delegate { OpenBuyPanel(y); });
            }
            else
            {
                int y = i;
                b.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
                b.onClick.AddListener(delegate {
                    pm.selectedGO = pm.characterPrefabList[y];
                    mainMenuButtonFunctions.LoadScene("Main Game Scene"); 
                });
            }

            i++;
        }

        backButton.onClick.AddListener(ReturnToSelection);
    }

    void UpdateButtons()
    {
        int i = 0;

        foreach (Button b in selectionButtons)
        {
            if (pm.charactersBought[i] == PlayerManager.BuyState.NotBought)
            {
                b.onClick.AddListener(delegate { OpenBuyPanel(i); });
            }
            else
            {
                b.transform.GetComponentInChildren<TextMeshProUGUI>().text = "Select";
                b.onClick.AddListener(delegate { mainMenuButtonFunctions.LoadScene("Main Game Scene"); });
            }

            i++;
        }
    }

    public void ReturnToSelection()
    {
        if (!prntBuySelection.activeSelf) return;

        prntBuySelection.SetActive(false);
        prntChooseCharacters.SetActive(true);
    }

    public void GoToBuyPanel()
    {
        if (!prntChooseCharacters.activeSelf) return;

        prntChooseCharacters.SetActive(false);
        prntBuySelection.SetActive(true);
    }

    public void OpenBuyPanel(int buttonNumber)
    {
        CalculationsForBuildPanel(buttonNumber);
        GoToBuyPanel();
    }

    public void CalculationsForBuildPanel(int itemNumber)
    {
        switch (itemNumber)
        {
            case 0:
                buyText.text = "Buy - Circle";
                currentMoneyText.text = "Current Money -" + pm.currentPoints.ToString();
                requiredMoneyText.text = "Required Money - 500";

                if (pm.currentPoints - 500 < 0) buyButton.enabled = false;
                break;
            case 1:
                buyText.text = "Buy - Square";
                currentMoneyText.text = "Current Money -" + pm.currentPoints.ToString();
                requiredMoneyText.text = "Required Money - 500";

                if (pm.currentPoints - 500 < 0) buyButton.enabled = false;
                buyButton.onClick.AddListener(delegate
                {
                    pm.charactersBought[itemNumber] = PlayerManager.BuyState.Bought;
                    ReturnToSelection();
                    UpdateButtons();
                });
                break;
            case 2:
                buyText.text = "Buy - Triangle";
                currentMoneyText.text = "Current Money -" + pm.currentPoints.ToString();
                requiredMoneyText.text = "Required Money - 750";

                if (pm.currentPoints - 750 < 0) buyButton.enabled = false;
                buyButton.onClick.AddListener(delegate
                {
                    pm.charactersBought[itemNumber] = PlayerManager.BuyState.Bought;
                    ReturnToSelection();
                    UpdateButtons();
                });
                break;
            case 3:
                buyText.text = "Buy - Star";
                currentMoneyText.text = "Current Money -" + pm.currentPoints.ToString();
                requiredMoneyText.text = "Required Money - 2000";

                if (pm.currentPoints - 2000 < 0) buyButton.enabled = false;
                buyButton.onClick.AddListener(delegate
                {
                    pm.charactersBought[itemNumber] = PlayerManager.BuyState.Bought;
                    ReturnToSelection();
                    UpdateButtons();
                });
                break;
            default:
                buyText.text = "Buy - Circle";
                currentMoneyText.text = "Current Money -" + pm.currentPoints.ToString();
                requiredMoneyText.text = "Required Money - 500";

                if (pm.currentPoints - 500 < 0) buyButton.enabled = false;
                buyButton.onClick.AddListener(delegate
                {
                    pm.charactersBought[itemNumber] = PlayerManager.BuyState.Bought;
                    ReturnToSelection();
                    UpdateButtons();
                });
                break;
        }
    }
}
