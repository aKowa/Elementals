using UnityEngine;
using System.Collections;

[System.Serializable]
public class AttackBonus{
	public float damage = 1;
	public float speed = 1;
	public float size = 1;
	public float lifetime = 1;
}

[System.Serializable]
public class ElementalBonus{

}

[System.Serializable]
public class Attributes{

}

public class Gems : MonoBehaviour {
public Gems (){}

	public Gems ( string newName ){
		name = newName;
	}

	public AttackBonus attackBonus;
}
