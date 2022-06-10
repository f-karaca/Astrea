using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour
{
    public Transform rayPoint;
    public float rayDistance = 5f;
    UnityEvent OnDashControl;
    public Dash dashScript;
    public float mana = 100f;
    public float manaIncrement = 35f;
    public Scrollbar scrollbar;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    private RaycastHit rayHit;
    private bool dashControl = true;

    private void Start()
    {
        Transform startPoint = GameObject.FindGameObjectWithTag("StartPoint").transform;
        spawnPosition = startPoint.position;
        spawnRotation = startPoint.rotation;
        dashControl = true;

        if (OnDashControl == null)
            OnDashControl = new UnityEvent();

        OnDashControl.AddListener(dashScript.KillDOTween);
    }

    private void Update()
    {
        DashCheck();

        mana += manaIncrement * Time.deltaTime;
        scrollbar.image.fillAmount = mana / 100f;

        if (mana >= 100 )
        {
            mana = 100f;
        }
        else if(mana <= 0f)
        {
            mana = 0f;
        }


        print(mana);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SpawnVolume"))
        {
            spawnPosition = other.transform.GetChild(0).position;
            spawnRotation = other.transform.GetChild(0).rotation;
        }

        if (other.CompareTag("DeadZone"))
        {
            transform.position = spawnPosition;
            transform.rotation = spawnRotation;
        }
    }

    private void DashCheck()
    {
        if (Physics.Raycast(rayPoint.position, transform.forward, out rayHit, rayDistance) && dashControl)
        {
            dashScript.isDash = false;
            dashScript.KillDOTween();
            dashControl = false;
        }
        else if (Physics.Raycast(rayPoint.position, transform.forward, out rayHit, rayDistance) == false)
        {
            dashControl = true;
            dashScript.isDash = true;
        }

        Debug.DrawRay(rayPoint.position, transform.forward * rayDistance, Color.red);
    }
}
