using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    private float cooldownCounter = 0f;
    private ItemBehaviour items;

    void Start()
    {
        items = GetComponent<ItemBehaviour>();
    }

    void Update()
    {
        Shoot();

    }

    void Shoot()
    {
        cooldownCounter += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && cooldownCounter > items.cooldownTime)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.transform.position = transform.position;
            laser.transform.rotation = transform.rotation;
            Destroy(laser, 3f);

            cooldownCounter = 0f;
        }
    }
}
