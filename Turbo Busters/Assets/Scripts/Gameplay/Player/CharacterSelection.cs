using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelection : MonoBehaviour
{
    PlayerManager pm;

    public MainMenuButtonFunctions mainMenuButtonFunctions;

    public Button buySelectButton;
    public TextMeshProUGUI buySelectButtonText;

    public Button foward;
    public Button backward;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI updateText;

    int currentSelection;

    void Start()
    {
        pm = PlayerManager.instance;

        foward.onClick.AddListener(GoFoward);
        backward.onClick.AddListener(GoBackwards);

        UpdateData(0);
    }

    public void GoFoward()
    {
        currentSelection++;
        if (currentSelection > 3)
            currentSelection = 0;
        UpdateData(currentSelection);
    }

    public void GoBackwards()
    {
        currentSelection--;
        if (currentSelection < 0)
            currentSelection = 3;
        UpdateData(currentSelection);
    }

    public void UpdateData(int i)
    {     
        bool bought = (pm.charactersBought[i] == PlayerManager.BuyState.Bought);

        buySelectButton.onClick.RemoveAllListeners();

        switch (i)
        {
            default:
            case 0:
                nameText.text = "Blue";
                nameText.color = pm.playerColorArray[i];

                updateText.text = "Power - 10" + "\n" +
                    "Bought" + "\n" + "Price - 0" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                    (pm.currentPoints - 0).ToString();

                if (pm.charactersBought[i] == PlayerManager.BuyState.Bought)
                {
                    buySelectButtonText.text = "Select";

                    buySelectButton.onClick.AddListener(delegate
                    {
                        pm.selectedColor = pm.playerColorArray[i];
                        pm.speed = 10;
                        mainMenuButtonFunctions.LoadScene("Main Game Scene");
                    });
                }
                break;
            case 1:
                nameText.text = "Red";
                nameText.color = pm.playerColorArray[i];

                if (bought)
                {
                    updateText.text = "Power - 15" + "\n" +
                    "Bought" + "\n" + "Price - 500" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                     (pm.currentPoints - 500).ToString();
                }
                else
                {
                    updateText.text = "Power - 15" + "\n" +
                    "Buy Now" + "\n" + "Price - 500" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                    (pm.currentPoints - 500).ToString();
                }


                if (pm.charactersBought[i] == PlayerManager.BuyState.Bought)
                {
                    buySelectButtonText.text = "Select";

                    buySelectButton.onClick.AddListener(delegate
                    {
                        pm.selectedColor = pm.playerColorArray[i];
                        pm.speed = 15;
                        mainMenuButtonFunctions.LoadScene("Main Game Scene");
                    });
                }
                else
                {
                    buySelectButtonText.text = "Buy";

                    if (pm.currentPoints - 500 >= 0)
                    {
                        buySelectButton.onClick.AddListener(delegate
                        {
                            pm.charactersBought[i] = PlayerManager.BuyState.Bought;
                            UpdateData(i);
                        });
                    }
                }
                break;
            case 2:
                nameText.text = "Green";
                nameText.color = pm.playerColorArray[i];

                if (bought)
                {
                    updateText.text = "Power - 20" + "\n" +
                    "Bought" + "\n" + "Price - 1000" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                     (pm.currentPoints - 1000).ToString();
                }
                else
                {
                    updateText.text = "Power - 20" + "\n" +
                    "Buy Now" + "\n" + "Price - 1000" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                    (pm.currentPoints - 1000).ToString();
                }

                if (pm.charactersBought[i] == PlayerManager.BuyState.Bought)
                {
                    buySelectButtonText.text = "Select";

                    buySelectButton.onClick.AddListener(delegate
                    {
                        pm.selectedColor = pm.playerColorArray[i];
                        pm.speed = 20;
                        mainMenuButtonFunctions.LoadScene("Main Game Scene");
                    });
                }
                else
                {
                    buySelectButtonText.text = "Buy";

                    if (pm.currentPoints - 1000 >= 0)
                    {
                        buySelectButton.onClick.AddListener(delegate
                        {
                            pm.charactersBought[i] = PlayerManager.BuyState.Bought;
                            UpdateData(i);
                        });
                    }
                }
                break;
            case 3:
                nameText.text = "Yellow";
                nameText.color = pm.playerColorArray[i];

                if (bought)
                {
                    updateText.text = "Power - 30" + "\n" +
                    "Bought" + "\n" + "Price - 2000" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                     (pm.currentPoints - 2000).ToString();
                }
                else
                {
                    updateText.text = "Power - 30" + "\n" +
                    "Buy Now" + "\n" + "Price - 2000" + "\n" + "Current Money - " + pm.currentPoints.ToString() + "Leftover - " +
                    (pm.currentPoints - 2000).ToString();
                }

                if (pm.charactersBought[i] == PlayerManager.BuyState.Bought)
                {
                    buySelectButtonText.text = "Select";

                    buySelectButton.onClick.AddListener(delegate
                    {
                        pm.selectedColor = pm.playerColorArray[i];
                        pm.speed = 30;
                        mainMenuButtonFunctions.LoadScene("Main Game Scene");
                    });
                }
                else
                {
                    buySelectButtonText.text = "Buy";

                    if (pm.currentPoints - 2000 >= 0)
                    {
                        buySelectButton.onClick.AddListener(delegate
                        {
                            pm.charactersBought[i] = PlayerManager.BuyState.Bought;
                            UpdateData(i);
                        });
                    }
                }
                break;
        }

    }
}
