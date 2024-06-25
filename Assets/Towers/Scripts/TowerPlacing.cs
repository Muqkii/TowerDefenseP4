using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

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

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
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
}
