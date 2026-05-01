using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public ItemInstance itemTemplate;
    public List<ItemData> drops;

    private void OnDestroy()
    {
        int index = Random.Range(0, drops.Count);

        ItemInstance newInstance = Instantiate(itemTemplate);
        newInstance.transform.position = transform.position;
        newInstance.Apply(drops[index]);
    }
}
