using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSlider : MonoBehaviour {

    public GameObject SliderMenu;
    public GameObject Sandwich;

    Animator m_Animator;
    Animator icon_Animator;
    

    // Use this for initialization
    void Start () {

        
        m_Animator = SliderMenu.GetComponent<Animator>();
        icon_Animator = Sandwich.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuOffScreen(bool newValue)
    {
        m_Animator.SetBool("slideOut", newValue);
    }

    public void RotateIcon(bool newValue)
    {
        icon_Animator.SetBool("rotate", newValue);
    }
}
