﻿using UnityEngine;

[CreateAssetMenu(menuName = "Galilei/IAction/TestAction")]
public class TestAction : IAction {
    public override void OnInteract(GameObject target, Player Plr) {
        Debug.Log("test");
    }
}