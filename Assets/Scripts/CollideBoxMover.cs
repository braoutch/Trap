using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBoxMover : MonoBehaviour {

    //L'objet collidebox qu'on va bouger, dont on va changer la taille, etc
    private CollideBox m_collideBox;

    //Jusqu'ou peut bouger l'objet ?
    private int[] m_frontiers = new int[2] { 5, 5 };

	// Use this for initialization
	void Start () {
        m_collideBox = GetComponent<CollideBox>();
	}
	
	// Update is called once per frame
	void Update () {
        m_collideBox.MoveCollideBox(GetRandomMoves());
        m_collideBox.LimitSpeed();
        m_collideBox.ChangeScale(0.9999f);
	}

    private Vector2 GetRandomMoves()
    {
        Vector2 v2 = m_collideBox.GetColliderPosition();
        //Debug.Log("La box est en" + v2.x + "," + v2.y);
        float x = Random.Range(-m_frontiers[0], m_frontiers[0])+ v2.x;
        float y = Random.Range(-m_frontiers[1], m_frontiers[1])+ v2.y;
        //Debug.Log("On la bouge de" + -x + "," + -y);
        return new Vector2(-x * m_collideBox.vitesse, -y * m_collideBox.vitesse);
    }
}
