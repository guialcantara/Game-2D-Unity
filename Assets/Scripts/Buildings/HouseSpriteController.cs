using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpriteController : MonoBehaviour
{
    [SerializeField] private Color buildingColor;
    [SerializeField] private Color endColor;
    [SerializeField] private GameObject selectors;
    [SerializeField] private UnityEngine.U2D.SpriteShapeRenderer Sprite;
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    public void ChangeBuildState(bool building)
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            if (building) { 
                sprites[i].color = buildingColor;
            }
            else{
                sprites[i].color = endColor;
            }
        }   
    }

    public void SetSelectors(bool active)
    {
        selectors.SetActive(active);
    }

    public void CanBuild(bool canBuild, int playerWood, int needWood)
    {
        if(playerWood < needWood)
        {
            Sprite.enabled = true;
        }
        else
        {
        Sprite.enabled = !canBuild;
        }
    }
}
