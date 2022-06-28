using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {
    public static Players Instance; 
    
    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
