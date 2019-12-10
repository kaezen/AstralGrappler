using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGuns : MonoBehaviour
{

    public Dropdown rightHandList;
    public GameObject rightHand;
    Fire1ShootScript rightHandShootScript;
    public Dropdown leftHandList;
    public GameObject leftHand;
    Fire2ShootScript leftHandShootScript;
    GameObject[] gunList;
    List<string> gunNames;

    // Start is called before the first frame update
    void Start()
    {
        //TODO: Come up with better method to load the hands / gun controlls into memory to make it easier, maybe pulling from player somehow?
        //rightHandShootScript = player.GetComponentInChildren<Fire1ShootScript>();
        //leftHandShootScript = player.GetComponentInChildren<Fire2ShootScript>();

        rightHandShootScript = rightHand.GetComponent<Fire1ShootScript>();
        leftHandShootScript = leftHand.GetComponent<Fire2ShootScript>();


        rightHandList.ClearOptions();
        leftHandList.ClearOptions();

        //gunList = Resources.LoadAll("Guns").Cast<GameObject>().ToArray();
        gunList = Resources.LoadAll<GameObject>("Guns");
        //TODO: refactor this so it only loads from specific folder


        gunNames = new List<string>();
        foreach (GameObject g in gunList)
        {
            gunNames.Add(g.name);
        }

        leftHandList.AddOptions(gunNames);
        rightHandList.AddOptions(gunNames);
    }

    // Update is called once per frame
    public void SetEquipment()
    {
        leftHandShootScript.ClearGunList();
        rightHandShootScript.ClearGunList();


        Instantiate(gunList[rightHandList.value], rightHand.transform);
        Instantiate(gunList[leftHandList.value], leftHand.transform);

        //delay the update a moment to ensure Unity has time to destroy the previous guns
        leftHandShootScript.Invoke("UpdateGuns", .05f);
        rightHandShootScript.Invoke("UpdateGuns", .05f);
    }
}
