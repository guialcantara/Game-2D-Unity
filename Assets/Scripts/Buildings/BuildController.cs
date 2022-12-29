using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private float timeAmount;

    [Header("Components")]
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private GameObject housePreviewPrefab;

    public Player player;
    private PlayerAnim playerAnim;
    private PlayerItens playerItens;

    private GameObject housePreview;
    private House house;
    private Camera cam;

    private bool buildingMode;
    private bool building;
    private float timeCount;


    void Start()
    {
        
        cam = FindObjectOfType<Camera>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItens = player.GetComponent<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleBuildingMode();
        if (housePreview)
        {
            HousePreviewFollowMousePosition();
            VerifyCanBuild();
            if (Input.GetMouseButtonDown(0) && house.canBuild && playerItens.TotalWood >= woodAmount)
            {
                building = true;
                house.houseSpriteController.SetSelectors(false);
                house.MaterialPanel.SetActive(false);
                house.timeBar.SetActive(true);
                housePreview = null;
                buildingMode = false;
                player.transform.SetPositionAndRotation(house.point.position, house.point.rotation);
                playerAnim.OnHammeringStarted();
            }
        }

        if (building)
        {
            timeCount += Time.deltaTime;
            house.bar.transform.localScale = new Vector3((timeCount * 100 / 5)/100, 1f);
            if (timeCount >= timeAmount)
            {
                //casa é finalizada

                playerItens.TotalWood -= woodAmount;
                playerAnim.OnHammeringEnded();
                player.isPaused = false;
                house.timeBar.SetActive(false);
                timeCount = 0f;
                building = false;
                Instantiate(housePrefab, house.transform.position, Quaternion.identity);
                Destroy(house.gameObject);
            }
        }     
    }

    private void ToggleBuildingMode()
    {
        if (Input.GetKeyDown(KeyCode.F1) && !buildingMode && !building)
        {
            if (!housePreview)
            {
                //cria uma preview da house que acompanha a posição do mouse.
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = Mathf.Abs(cam.transform.position.z);

                Vector3 objectPos = cam.ScreenToWorldPoint(mousePos);
                objectPos.z = 0f;
                housePreview = Instantiate(housePreviewPrefab, objectPos, Quaternion.identity);
                house = housePreview.GetComponent<House>();
                house.txtPlayerWoodAmount.text = playerItens.TotalWood +"";
                house.txtNeedWoodAmount.text = "/"+woodAmount;
            }

            buildingMode = true;
            player.isPaused = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && buildingMode)
        {
            buildingMode = false;
            player.isPaused = false;
            Destroy(housePreview);
        }
    }

   private void HousePreviewFollowMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(cam.transform.position.z);

        Vector3 objectPos = cam.ScreenToWorldPoint(mousePos);
        objectPos.z = 0f;
        housePreview.transform.position = objectPos;
    }

   private void VerifyCanBuild()
    {
        house.houseSpriteController.CanBuild(house.canBuild, playerItens.TotalWood, woodAmount);
    }
}
