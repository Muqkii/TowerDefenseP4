using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacing : MonoBehaviour
{
    public GameObject tower1;
    public GameObject towerPre1;
    public float xCorrection;
    public float yCorrection;

    private bool buildMode = false;
    private GameObject previewTower;
    private Vector3 hitPos;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            hitPos = hit.point;
            hitPos.x += xCorrection;
            hitPos.y += yCorrection;
            Debug.Log("Raycast hit");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1) && buildMode == false)
        {
            buildMode = true;

            GameObject obj = Instantiate(towerPre1, hitPos, Quaternion.identity);
            previewTower = obj;
            Debug.Log("Buildmode werkt" + buildMode);
        }
        
        previewTower.transform.position = hitPos;

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && tower1 != null && towerPre1 != null)
        {
            Instantiate(tower1, hitPos, Quaternion.identity);
        }
        Debug.Log("Place functie werkt");
    }
}
