using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private SkillManager _skillManager;
    private void Start()
    {
        _skillManager = gameObject.GetComponent<SkillManager>();
    }

    private void Update()
    {
        try
        {
            foreach (var skill in _skillManager.SkillList)
            {
                skill.TryUseSkill();
            }
        }
        catch
        {
            return;
        }
    }

}

