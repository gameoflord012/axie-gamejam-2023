using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ColliderFilter))]
public class Attacker : MonoBehaviour
{
    public UnityEvent<Transform> onAttackerAttackTransform;
    
    [SerializeField] uint damage;
    [SerializeField] bool isAreaAttack = false;
    [SerializeField] bool autoDealDamageWhenTouch = false;

    List<Health> whiteList = new();

    [SerializeField] bool debug;

    ColliderFilter attackTrigger;

    public uint Damage { get => damage; set => damage = value; }
    public List<Health> WhiteList { get => whiteList; set => whiteList = value; }

    private void Awake()
    {
        attackTrigger = GetComponent<ColliderFilter>();
    }

    private void OnEnable()
    {
        if(autoDealDamageWhenTouch)
            attackTrigger.onTriggerEnter.AddListener(OnAttackerTouchHealth);
    }

    private void OnDisable()
    {
        attackTrigger.onTriggerEnter.RemoveListener(OnAttackerTouchHealth);
    }

    private void Update()
    {
        if(debug)
        {
            Debug.Log("Attack target num: " + GetAttackTargets().Count());
        }
    }

    public Health GetAttackTarget()
    {
        return GetAttackTargets().Count() > 0 ? GetAttackTargets().First() : null;
    }

    public Health[] GetAttackTargets()
    {
        return attackTrigger.GetTouchCols().
            Select(col => col.GetComponent<Health>()).
            Where(health => health.GetHealth() > 0).
            ToArray();
    }

    public void DealDamageAll()
    {
        foreach(var health in GetAttackTargets())
        {
            DealDamageTo(health);
            if (!isAreaAttack) break;
        }
    }

    void OnAttackerTouchHealth(Collider2D collider2D)
    {
        DealDamageTo(collider2D.GetComponent<Health>());
    }

    void DealDamageTo(Health health)
    {
        if (WhiteList.Count > 0 && !WhiteList.Contains(health)) return;
        health.UpdateHealth(this);
        onAttackerAttackTransform?.Invoke(health.transform);
    }
}
