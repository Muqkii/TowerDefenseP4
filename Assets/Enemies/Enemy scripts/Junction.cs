using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;

public class Junction : MonoBehaviour
{
    public SplineContainer thePath;
    public float gap;
    public Spline currentPath;
    public int currentPathNumber = 0;

    bool atEnd;

    private int[] zero = { 3, 4 };
    private int[] one = { 2 };
    private int[] three = { 2 };
    private int[] four = { 1, 5 };
    private int[] five = { 7, 9 };
    private int[] six = { 2 };
    private int[] seven = { 8 };
    private int[] nine = { 6, 10 };
    private int[] ten = { 8 };

    void Update()
    {
        PathSelection();
    }

    private void CheckIfAtEnd(string tag)
    {
        Vector3 EndKnotPos = GameObject.FindGameObjectWithTag(tag).transform.position;
        //Debug.Log(transform.position);
        //Debug.Log(EndKnotPos + "Ik ben de tweede");
        //Debug.Log(" ");
        if (Vector3.Distance(transform.position, EndKnotPos) < gap)
        {
            PathSelection();
            Debug.Log("At end of a spline");
        }
    }

    private void PathSelection()
    {
        switch (currentPathNumber)
        {
            case 0:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 3-4");
                }
                else
                {
                    NewPath(zero);
                }
                break;
            case 1:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 2");
                }
                else
                {
                    NewPath(one);
                }
                break;
            case 2:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction end");
                }
                else
                {
                    EndPath();
                }
                break;
            case 3:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 2");
                }
                else
                {
                    NewPath(three);
                }
                break;
            case 4:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 1-5");
                }
                else
                {
                    NewPath(four);
                }
                break;
            case 5:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 7-9");
                }
                else
                {
                    NewPath(five);
                }
                break;
            case 6:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 2");
                }
                else
                {
                    NewPath(six);
                }
                break;
            case 7:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 8");
                }
                else
                {
                    NewPath(seven);
                }
                break;
            case 8:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction end");
                }
                else
                {
                    EndPath();
                }
                break;
            case 9:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 6-10");
                }
                else
                {
                    NewPath(nine);
                }
                break;
            case 10:
                if (!atEnd)
                {
                    CheckIfAtEnd("Junction 8");
                }
                else
                {
                    NewPath(ten);
                }
                break;
            default:
                Debug.Log("Invalid path");
                break;
        }
    }

private void NewPath(int[] randomPath)
    {
        int chosenPath = randomPath[Random.Range(0, randomPath.Length - 1)];
        currentPathNumber = chosenPath;
        gameObject.GetComponent<SplineAnimate>().Container.Spline = thePath.Splines[chosenPath];
        Debug.Log("New path chosen");
    }

    private void EndPath()
    {
        gameObject.GetComponent<SplineAnimate>().Pause();
        Debug.Log("Pausing / Stop");
    }
}
