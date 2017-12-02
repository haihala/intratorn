using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    #region Public interface
    public void Gather(Item item) {
        print("Picked up " + item.Name);
    }
    #endregion Public interface
}
