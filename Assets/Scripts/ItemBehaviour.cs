using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] public float cooldownTime = 3f;
    [SerializeField] private Image itemImageHolder;

    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;

    private MessageBehaviour message;
    private MovementBehaviour move;

    private Dictionary<Color, System.Action> itemEffects;

    void Start()
    {
        message = GetComponent<MessageBehaviour>();
        move = GetComponent<MovementBehaviour>();

        itemEffects = new Dictionary<Color, System.Action>
        {
            { Color.blue, () => ApplyEffect(" + Move Speed", () => move.moveSpeed += 5) },
            { Color.red, () => ApplyEffect(" + Fire Rate", () => cooldownTime -= 0.1f) },
            { Color.green, () => ApplyEffect(" + Rotation Speed", () => move.rotationSpeed += 10) }
        };
    }

    void Update()
    {
        CycleItems();
        UseItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }

    void PickUpItem(GameObject item)
    {
        Color color = item.gameObject.GetComponent<Renderer>().material.color;
        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;
        UpdateUI();
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && items.Count > 0)
        {
            activeItemIndex = (activeItemIndex + 1) % items.Count;
            UpdateUI();
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {
            Color activeColor = items[activeItemIndex];

            if (itemEffects.ContainsKey(activeColor))
            {
                itemEffects[activeColor](); 
            }

            items.RemoveAt(activeItemIndex);
            activeItemIndex = Mathf.Clamp(activeItemIndex - 1, -1, items.Count - 1);
            UpdateUI();
        }
    }

    void ApplyEffect(string messageText, System.Action effect)
    {
        StartCoroutine(message.ShowMessage(messageText));
        effect?.Invoke();
    }

    void UpdateUI()
    {
        if (items.Count > 0 && activeItemIndex != -1)
        {
            itemImageHolder.color = items[activeItemIndex];
            itemImageHolder.enabled = true;
        }
        else
        {
            itemImageHolder.color = Color.white;
            itemImageHolder.enabled = false;
        }
    }
}
