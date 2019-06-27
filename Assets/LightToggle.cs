using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Stop1()
    {
        GameObject.FindGameObjectWithTag("GoLight1").SetActive(false);
        GameObject.FindGameObjectWithTag("GoLight1").SetActive(false);
    }

    public void Stop2()
    {
        GameObject.FindGameObjectWithTag("GoLight2").SetActive(false);
        GameObject.FindGameObjectWithTag("GoLight2").SetActive(false);
    }

    public void Go1()
    {
        GameObject.FindGameObjectWithTag("GoLight1").SetActive(true);
        GameObject.FindGameObjectWithTag("GoLight1").SetActive(true);
    }

    public void Go2()
    {
        GameObject.FindGameObjectWithTag("GoLight2").SetActive(true);
        GameObject.FindGameObjectWithTag("GoLight2").SetActive(true);
    }
}
