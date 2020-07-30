using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assets {


    private IDictionary<string, Sprite> spriteRegistry;


    // INTERFACE METHODS

    public Assets() {
        this.spriteRegistry = new Dictionary<string, Sprite>();
    }

    public void SetSprite(string spriteName, Sprite sprite) {
        this.spriteRegistry.Add(spriteName, sprite);
    }

    public Sprite GetSprite(string spriteName) {
        return this.spriteRegistry[spriteName];
    }


}