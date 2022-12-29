using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    [Header("Items")]
    [SerializeField] private Image waterBarUI;
    [SerializeField] private Image woodBarUI;
    [SerializeField] private Image carrotBarUI;
    [SerializeField] private Image fishBarUI;

    [Header("Tools")]
    //[SerializeField] private Image axeUI;
    //[SerializeField] private Image shovelUI;
    //[SerializeField] private Image bucketUI;
    public List<Image> toolsUI = new List<Image>();

    [SerializeField] private Color selectColor;
    [SerializeField] private Color alphaColor;

    private PlayerItens playerItens;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        playerItens = player.GetComponent<PlayerItens>();
        waterBarUI.fillAmount = 0f;
        woodBarUI.fillAmount = 0f;
        carrotBarUI.fillAmount = 0f;
        fishBarUI.fillAmount = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        waterBarUI.fillAmount = playerItens.CurrentWater / playerItens.waterLimit;
        woodBarUI.fillAmount = playerItens.TotalWood / playerItens.woodLimit;
        carrotBarUI.fillAmount = playerItens.Carrots / playerItens.carrotsLimit;
        fishBarUI.fillAmount = playerItens.Fishes / playerItens.fishesLimit;

        //toolsUI[player.handlingObj].color = selectColor;

        for (int i = 0; i < toolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                toolsUI[i].color = selectColor;
            }
            else
            {
                toolsUI[i].color = alphaColor;
            }
        }
    }
}
