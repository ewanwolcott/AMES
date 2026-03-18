using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ItemInstance : MonoBehaviour
{
    public ItemData data;

    [SerializeField] Image itemImage;

    [SerializeField] GameObject image;

    private SpriteRenderer _sprt;

    private void Awake()
    {
        _sprt = GetComponent<SpriteRenderer>();
        _sprt.sprite = data.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemImage.sprite = data.sprite;
        image.SetActive(true);
        Destroy(gameObject);
    }
}
