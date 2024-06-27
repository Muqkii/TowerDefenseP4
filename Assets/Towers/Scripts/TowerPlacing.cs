using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacing : MonoBehaviour
{
    public GameObject tower1;
    public GameObject towerPrePlacable;
    public GameObject towerPreUnPlacable;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject tower4;
    public GameObject tower5;
    
    public float manaPool;
    public float costTower1;
    public float costTower2;   
    public float costTower3;
    public float costTower4;
    public float costTower5;

    public float rotationSpeed;
    public float xCorrection;
    public float yCorrection;

    private bool buildMode = false;
    private bool placable;
    private GameObject previewTower;
    private Vector3 hitPos;
    private int towerNumber;

    [Header ("UI")]

    public UnityEngine.UI.Text manaPoolText;
    public UnityEngine.UI.Text tower1Info;
    public UnityEngine.UI.Text tower2Info;
    public UnityEngine.UI.Text tower3Info;
    public UnityEngine.UI.Text tower4Info;
    public UnityEngine.UI.Text tower5Info;
    public UnityEngine.UI.Image towerInfoBackground;

    bool towerInfoWindow;

    Ray ray;
    RaycastHit hit;
    float scrollInput;

    float tower1Damage;
    float tower2Damage;
    float tower3Damage;
    float tower4Damage;
    float tower5Damage;

    private void Start()
    {
        tower1Damage = Resources.Load<TowerBehavior>("Tower/Basic tower").towerDamage;
        tower2Damage = Resources.Load<TowerBehavior>("Tower/Snel low damage").towerDamage;
        tower3Damage = Resources.Load<TowerBehavior>("Tower/Boem tower").towerDamage;
        tower4Damage = Resources.Load<TowerBehavior>("Tower/sniper").towerDamage;
        tower5Damage = Resources.Load<TowerBehavior>("Tower/Anti air").towerDamage;

        //tower1Damage = GameObject.Find("Basic tower").GetComponent<TowerBehavior>().towerDamage;
        //tower2Damage = GameObject.Find("Snel low damage").GetComponent<TowerBehavior>().towerDamage;
        //tower3Damage = GameObject.Find("Boem tower").GetComponent<TowerBehavior>().towerDamage;
        //tower4Damage = GameObject.Find("sniper").GetComponent<TowerBehavior>().towerDamage;
        //tower5Damage = GameObject.Find("Anti Air").GetComponent<TowerBehavior>().towerDamage;
    }

    private void Update()
    {
        if (buildMode)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }


        if (Physics.Raycast(ray, out hit))
        {
            hitPos = hit.point;
            hitPos.x += xCorrection;    
            hitPos.y += yCorrection;
            //Debug.Log("Raycast hit");
        }

        //if ()
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && buildMode == false && placable == true)
        {
            buildMode = true;

            towerNumber = 1;

            GameObject obj = Instantiate(towerPrePlacable, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && buildMode == false)
        {
            buildMode = true;

            towerNumber = 2;

            GameObject obj = Instantiate(towerPrePlacable, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && buildMode == false)
        {
            buildMode = true;

            towerNumber = 3;

            GameObject obj = Instantiate(towerPrePlacable, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && buildMode == false)
        {
            buildMode = true;

            towerNumber = 4;

            GameObject obj = Instantiate(towerPrePlacable, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && buildMode == false)
        {
            buildMode = true;

            towerNumber = 5;

            GameObject obj = Instantiate(towerPrePlacable, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        if (previewTower)
        {
            previewTower.transform.position = hitPos;

        }

        if (buildMode)
        {
            scrollInput = Input.GetAxis("Mouse ScrollWheel");
        }
        
        if (scrollInput != 0f)
        {
            float rotationAmount = scrollInput * rotationSpeed;
            previewTower.transform.Rotate(Vector3.up, rotationAmount, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && buildMode == true)
        {
            buildMode = false;
            Destroy(GameObject.FindGameObjectWithTag("PreviewTower"));
            PlaceTower();
            Debug.Log("Tower placement word aangeroepen");
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && buildMode == true)
        {
            buildMode = false;
            Destroy(GameObject.FindGameObjectWithTag("PreviewTower"));
            Debug.Log("Buildmode cancel werkt");
        }

        NumberToText(manaPoolText, manaPool);
        TowerInfoCheck();
    }
    public void PlaceTower()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && towerNumber == 1 && manaPool >= costTower1)
        {
            Instantiate(tower1, hitPos, Quaternion.identity);
            manaPool -= costTower1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && towerNumber == 2 && manaPool >= costTower2)
        {
            Instantiate(tower2, hitPos, Quaternion.identity);
            manaPool -= costTower2;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && towerNumber == 3 && manaPool >= costTower3)
        {
            Instantiate(tower3, hitPos, Quaternion.identity);
            manaPool -= costTower3;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && towerNumber == 4 && manaPool >= costTower4)
        {
            Instantiate(tower4, hitPos, Quaternion.identity);
            manaPool -= costTower4;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && towerNumber == 5 && manaPool >= costTower5)
        {
            Instantiate(tower5, hitPos, Quaternion.identity);
            manaPool -= costTower5;
        }
    }

    void NumberToText(Text text, float number)
    {
        int newNumber = (int)number;
        text.text = newNumber.ToString();
    }

    void TowerInfoCheck()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("X is ingedrukken");
            if (towerInfoWindow)
            {
                towerInfoWindow = false;
            }
            else
            {
                towerInfoWindow = true;
            }
        }
        if (towerInfoWindow)
        {
            GameObject.Find("TowerInfoButton").GetComponent<Text>().text = "Press 'X' to close window";
            GameObject.Find("TowerInfoBackground").GetComponent<Image>().enabled = true;
            TowerInfoConverter(1, tower1Info, costTower1, tower1Damage);
            TowerInfoConverter(2, tower2Info, costTower2, tower2Damage);
            TowerInfoConverter(3, tower3Info, costTower3, tower3Damage);
            TowerInfoConverter(4, tower4Info, costTower4, tower4Damage);
            TowerInfoConverter(5, tower5Info, costTower5, tower5Damage);
        }
        else
        {
            GameObject.Find("TowerInfoButton").GetComponent<Text>().text = "Press 'X' to see tower info";
            GameObject.Find("TowerInfoBackground").GetComponent<Image>().enabled = false;
            tower1Info.text = null;
            tower2Info.text = null;
            tower3Info.text = null;
            tower4Info.text = null;
            tower5Info.text = null;
        }
    }

    void TowerInfoConverter(int tower,Text text, float manaCost, float damage)
    {
        switch (tower)
        {
            case 1:
                TowerInfoToText(tower, text, manaCost, damage, tower1);
                break;
            case 2:
                TowerInfoToText(tower, text, manaCost, damage, tower2);
                break;
            case 3:
                TowerInfoToText(tower, text, manaCost, damage, tower3);
                break;
            case 4:
                TowerInfoToText(tower, text, manaCost, damage, tower4);
                break;
            case 5:
                TowerInfoToText(tower, text, manaCost, damage, tower5);
                break;
        }
    }

    void TowerInfoToText(int tower, Text text, float manaCost, float damage, GameObject theTower)
    {
        int manaCostInt = (int)manaCost;
        int damageInt = (int)damage;
        text.text = theTower.name + ": does '" + damage + "' damage and costs '" + manaCostInt + "' mana.";
    }
}
