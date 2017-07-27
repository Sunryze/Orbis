using UnityEngine;
using System.Collections;

public class TutorialDisableBlink : MonoBehaviour {


    public GameObject Canvas;
    public GameObject Orb;

    void Start()
    {
        Canvas.SetActive(false);
      //  Orb.SetActive(false);

    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "Player") //overwrites the currents players checkpoint
        {

            Canvas.SetActive(true);
          //  Orb.SetActive(true); //orb not disble not working as intended
        }
    }
}
