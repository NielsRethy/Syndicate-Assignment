using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Medkit : SCR_Item {

    // ================================== 
    // Medkit item class: 
    // ================================== 
    //  - Information about this item
    //  - Picking up medkit
    // ----------------------------------

    public SCR_Medkit()
    {
        //initialize Medkit
        FileIconLocation = "Textures/Medkit";
        PickupObject = ItemType.Medkit;
    }

    public override void PickUp(SCR_Character ch)
    {
        //Picking up medkit
    }
}
