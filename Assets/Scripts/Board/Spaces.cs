using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spaces : MonoBehaviour {

    public List<GameObject> spaceObjects = new List<GameObject>();
    public List<Color> spaceColours = new List<Color>();
    public static Spaces Instance;
    public int numOfSpaces = 0;

    void Start() {
        foreach(Transform child in transform) {

            int spaceColour = Random.Range(1,9);

            if(child.GetSiblingIndex() != 0){
                if (Enumerable.Range(1,5).Contains(spaceColour)) {
                    child.GetComponent<Renderer>().material.color = Color.blue;
                }
                if (Enumerable.Range(6,7).Contains(spaceColour)) {
                    child.GetComponent<Renderer>().material.color = Color.red;
                }
                if (Enumerable.Range(8,9).Contains(spaceColour)) {
                    child.GetComponent<Renderer>().material.color = Color.green;
                }
            }
            spaceColours.Add(child.GetComponent<Renderer>().material.color);
            spaceObjects.Add(child.gameObject);
        }
        numOfSpaces = numberOfSpaces(spaceObjects);
    }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public GameObject getSpace(int spaceNumber) {
        return spaceObjects[spaceNumber];
    }
    public Color getSpaceColor(int spaceNumber) {
        return spaceColours[spaceNumber];
    }

    public GameObject getStartSpace() {
        return spaceObjects[0];
    }

    public int getSpaceIndex(GameObject space) {
        return spaceObjects.IndexOf(space);
    }

    public int numberOfSpaces(List<GameObject> list) {
        return list.Count;
    }
}
