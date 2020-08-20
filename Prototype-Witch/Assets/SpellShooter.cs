using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellShooter : MonoBehaviour
{
    [SerializeField] GameObject spellObject = null;
    
    private Vector3 shootDirection = Vector3.forward;
    private int numberOfSpellsFired;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            numberOfSpellsFired++;
            if (numberOfSpellsFired < 2)
            {
                var spell = Instantiate(spellObject, transform.position + transform.rotation * new Vector3(0, 0, 4), Quaternion.identity);
                spell.GetComponent<Rigidbody>().velocity = Vector3.forward * 20;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            numberOfSpellsFired = 0;
        }

    }
}
