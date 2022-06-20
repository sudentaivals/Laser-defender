using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] List<SpawnSkillShell> _skillsAddedOnStart;

    public List<SpawnSkill> SkillList { get; private set; }

    void Start()
    {
        SkillList = new List<SpawnSkill>();
        AddStartSkills();
    }

    private void AddStartSkills()
    {
        if(_skillsAddedOnStart != null)
        {
            foreach (var skillShell in _skillsAddedOnStart)
            {
                AddNewSkill(skillShell);
            }
        }
    }

    public void AddNewSkill(SpawnSkillShell skillShell)
    {
        var skill = gameObject.AddComponent<SpawnSkill>();
        skill.SetAction(skillShell.GetSpawnAction());
        skill.SetCooldown(skillShell.Cooldown);
        skill.SetObject(skillShell.SpawnObject);
        skill.SetName(skillShell.SkillName);
        skill.SetSoundEffect(skillShell.SoundOnUsage, skillShell.SoundVolume);
        SkillList.Add(skill);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
