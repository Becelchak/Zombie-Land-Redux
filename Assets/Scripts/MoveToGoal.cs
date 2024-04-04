using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public float speed = 0.5f;
    public float acuracy = 0.5f;
    public List<Transform> goals;

    private List<Transform> tempGoals;
    private Transform goal;
    private bool isMove = false;
    private Animator _animator;

    void Start()
    {
        tempGoals = new List<Transform>(goals);
        _animator = GetComponent<Animator>();
    }
    void LateUpdate()
    {
        if (tempGoals.Count > 0 && !isMove)
        {
            isMove = true;
            _animator.SetTrigger("Move");
            goal = tempGoals[0];
            tempGoals.RemoveAt(0);
        }
        if (isMove)
        {
            this.transform.LookAt(goal.position);
            var direction = goal.position - this.transform.position;

            if (direction.magnitude > acuracy)
            {
                this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                isMove = false;
                tempGoals.Remove(goal);
            }
        }

        if (tempGoals.Count == 0 && !isMove)
            _animator.SetTrigger("Idle");
    }
}
