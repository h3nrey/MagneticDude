using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    [SerializeField] PointEffector2D magneticField;
    [SerializeField] float magneticForce;
    [SerializeField] bool gravited;
    [SerializeField] KeyCode E;
    void Start()
    {
        magneticField.forceMagnitude = 0;
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKey(E)) {
            print("hahha");
            gravited = true;
        } else if(Input.GetKeyUp(E) || Input.GetKeyDown(E)) {
            Repulse();
            gravited = false;
        }

        ActiveMagneticField();
    }

    void ActiveMagneticField() {
        if(gravited) {
            magneticField.forceMagnitude = -magneticForce;
        } else {
            magneticField.forceMagnitude = 0;
        }
    }

    void Repulse() {
        magneticField.forceMagnitude = 2 * magneticForce;
    }
}
