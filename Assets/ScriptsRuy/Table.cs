using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public Transform placingSpot;
    public GameObject objOverTable;

    public void PutOverTable(Player player)
    {
        objOverTable = player.CheckInsideContainer();
        player.ClearContainer();
        PlaceObj(placingSpot);
        Debug.Log(objOverTable.name + " inside container, player" + player.id);

    }
    public void PlaceObj(Transform target)
    {
        objOverTable.transform.position = target.position;
        objOverTable.transform.rotation = target.rotation;
        objOverTable.transform.parent = target;
    }
    public void ClearTable()
    {
        objOverTable = (GameObject)null;
    }
    void OnTriggerStay(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            Player player = col.transform.GetComponent<Player>();

            if (Input.GetButtonDown("Fire" + player.id.ToString()))
            {
                if (!player.IsContainerEmpty())
                {
                    if(objOverTable == null)
                    {
                        PutOverTable(player);
                    }
                }
                else if (objOverTable != null)
                {
                    player.PutInContainer(objOverTable);
                    PlaceObj(player.transform);
                    Debug.Log(objOverTable.name + " in player " + player.id + "hands");
                    ClearTable();
               }
                
                    

            }

        }

    }
}
