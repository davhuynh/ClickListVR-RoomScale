using UnityEngine;
using System.Collections;
using VRTK;

public class MenuController : MonoBehaviour {

    public GameObject menuObject;

    private void Start()
    {
        menuObject.SetActive(false);
        GetComponent<VRTK_ControllerEvents>().AliasMenuOn += new ControllerInteractionEventHandler(DoMenuOn);
        GetComponent<VRTK_ControllerEvents>().AliasMenuOff += new ControllerInteractionEventHandler(DoMenuOff);
    }

    private void DoMenuOn(object sender, ControllerInteractionEventArgs e)
    {
        menuObject.SetActive(true);
    }

    private void DoMenuOff(object sender, ControllerInteractionEventArgs e)
    {
        menuObject.SetActive(false);
    }

}
