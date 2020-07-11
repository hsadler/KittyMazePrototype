using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSceneObjectPlacement {

    public void PlacePlayerObject(GameObject playerObject, GameObject startPosition) {
        GameObject.Instantiate(playerObject, startPosition.transform);
    }
    

}
