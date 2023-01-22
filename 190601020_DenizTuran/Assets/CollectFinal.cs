using UnityEngine;

public class CollectFinal : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform collectionPoint;
    public float collectRadius = 1.0f;
    public float distanceBetweenObjects = 0.5f;
    public int collectLimit = 5;
    public int collectCount = 0;

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(collectionPoint.position, collectRadius);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].gameObject.CompareTag("Collectable"))
            {
                CollectItem(hitColliders[i].gameObject);
                break;
            }
        }
    }

    void CollectItem(GameObject item)
    {

        if (collectCount < collectLimit)
        {
            collectCount++;

            item.transform.position = collectionPoint.position;

            item.transform.parent = transform;

            item.GetComponent<Collider>().enabled = false;

            item.tag = "Collected";
        }

    }
}