using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public ItemData data;

    private Image itemImage;

    private SpriteRenderer _sprt;

    private void Awake()
    {
        _sprt = GetComponent<SpriteRenderer>();
        itemImage = GameObject.FindWithTag("Pocket").GetComponent<Image>();

        if (data)
            Apply(data);
    }

    public void Apply(ItemData data)
    {
        this.data = data;
        _sprt.sprite = data.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && collision.gameObject.GetComponent<Interact>().hasItem == false)
        {
            itemImage.color = new(1, 1, 1, 1);
            itemImage.sprite = data.sprite;

            collision.GetComponent<Interact>().hasItem = true;
            
            Destroy(gameObject);
        }
    }
}
