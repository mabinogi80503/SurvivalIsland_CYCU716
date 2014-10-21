using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour {
    Dictionary<string, Skill> skillChain;
    private GameObject mTarget;

    public SkillManager(GameObject target) {
        mTarget = target;
        skillChain = new Dictionary<string,Skill>() ;
        skillChain.Add("skill_1", new Skill());
        GetSkill("skill_1");
    }

    public Skill GetSkill(string name)  {
        if (skillChain.ContainsKey(name))
            return skillChain[name];
        else
            return null;
    } 
}
