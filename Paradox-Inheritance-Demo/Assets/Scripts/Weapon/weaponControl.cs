using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponControl : MonoBehaviour
{
    private Animator charAnim;
    public GameObject weapon;
    public GameObject charCamera;
    void Start()
    {
        charAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !charAnim.GetBool("weapon"))
        {
            charAnim.SetBool("weapon",true);
            weapon.SetActive(true);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) && charAnim.GetBool("weapon"))
        {
            charAnim.SetBool("weapon", false);
            weapon.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Mouse1) && charAnim.GetBool("weapon"))
        {
            charAnim.SetBool("weaponAimIdle", true);
            charCamera.GetComponent<Animator>().Play("cameraAnim");
            if (charAnim.GetFloat("movement") > 0)
            {
                charAnim.SetBool("weaponAimWalk", true);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    charAnim.SetBool("aimWalkFire", true);
                }
                else
                {
                    charAnim.SetBool("aimWalkFire", false);
                }
            }
            else
            {
                charAnim.SetBool("weaponAimWalk", false);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                charAnim.SetBool("idleFire", true);
            }
            else
            {
                charAnim.SetBool("idleFire", false);
            }
        }
        else
        {
            charAnim.SetBool("weaponAimIdle", false);
            charAnim.SetBool("weaponAimWalk", false);
            charAnim.SetBool("aimWalkFire", false);
            charCamera.GetComponent<Animator>().Play("cameraAnimBack");
        }
    }
}
