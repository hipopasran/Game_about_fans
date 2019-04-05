using UnityEngine;
using System.Collections.Generic;

public class AnimationSprites : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> dudeSprites;
    [SerializeField]
    private SpriteRenderer dudeRender;
    [SerializeField]
    private SpriteRenderer dudeHandRender;
    [SerializeField]
    private Animator anim;


    private void OnValidate()
    {
        // Find replacement body sprite
        Sprite newCharSprite = dudeSprites.Find(item => item.name == dudeRender.sprite.name);
        if (newCharSprite) // If replacement sprites were found, replace them
            dudeRender.sprite = newCharSprite;

        // Find replacement hand sprite
        Sprite newHandSprite = dudeSprites.Find(item => item.name == dudeHandRender.sprite.name);
        if (newHandSprite) // If replacement sprites were found, replace them
            dudeHandRender.sprite = newHandSprite;
    }

    void LateUpdate()
    {
        // Find replacement sprites
        Sprite newCharSprite = dudeSprites.Find(item => item.name == dudeRender.sprite.name);
        if (newCharSprite) // If replacement sprites were found, replace them
            dudeRender.sprite = newCharSprite;

        // Find replacement hand sprites
        if (dudeHandRender.gameObject.activeSelf)
        {
            Sprite newHandSprite = dudeSprites.Find(item => item.name == dudeHandRender.sprite.name);
            if (newHandSprite) // If replacement sprites were found, replace them
                dudeHandRender.sprite = newHandSprite;
        }
    }


    private bool walking = false;
    public void ToggleWalk()
    {
        walking = !walking;
        anim.SetBool("Walking", walking);
    }

    public void Bored()
    {
        anim.SetTrigger("Bored");
    }
}
