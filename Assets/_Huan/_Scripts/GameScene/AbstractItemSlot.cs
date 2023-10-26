using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class AbstractItemSlot : MonoBehaviour
{
    [SerializeField] protected Image image;
    [SerializeField] protected Button button;

    protected IItemSlotQuery m_ItemSlotQuery;
    [SerializeField] protected Color selectedColor, notSelectedColor;
    [SerializeField] protected TMP_Text cooldownText;
    [SerializeField] protected Slider cooldownSlider;
    protected int cooldown = 0;

    protected void Awake()
    {
        m_ItemSlotQuery = GetComponent<IItemSlotQuery>();    
    }

    public abstract void OnSlotSelect();

    public AbstractItem GetItemInSlot()
    {
        if (transform.childCount > 0)
        {
            AbstractItem item = transform.GetComponentInChildren<AbstractItem>();
            return item;
        }

        return null;
    }

    protected IEnumerator CooldownCoroutine()
    {
        while (cooldown > 0)
        {
            cooldown -= 1;
            cooldownText.text = cooldown.ToString();
            cooldownSlider.value = cooldown;
            Debug.Log("Item " + gameObject.name + " cooldown = " + cooldown);

            yield return new WaitForSeconds(1);
        }

        cooldownSlider.gameObject.SetActive(false);
        m_ItemSlotQuery.SetSelectable(true);
        button.interactable = true;
        yield return null;
    }

    internal void Select()
    {
        image.color = selectedColor;
    }

    internal void Deselect()
    {
        image.color = notSelectedColor;
    }
}
