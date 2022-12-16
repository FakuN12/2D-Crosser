using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxLength = 1f;
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;
    public HingeJoint2D StartJoint;
    public HingeJoint2D EndJoint;

    float startJointCurrentLoad = 0;
    float endJointCurrentLoad = 0;
    MaterialPropertyBlock propBlock;

    public void UpdateCreatingBar(Vector2 ToPosition)
    {
        transform.position = (ToPosition + StartPosition) / 2;

        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        float Length = dir.magnitude;
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;
    }

    public void UpdateMaterial()
    {
        if (StartJoint) startJointCurrentLoad = StartJoint.reactionForce.magnitude / StartJoint.breakForce;
        if (EndJoint) endJointCurrentLoad = EndJoint.reactionForce.magnitude / EndJoint.breakForce;
        float maxLoad = Mathf.Max(startJointCurrentLoad, endJointCurrentLoad);

        propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Load", maxLoad);
        barSpriteRenderer.SetPropertyBlock(propBlock);
    }

    private void Update()
    {
        if (Time.timeScale == 1) UpdateMaterial();
    }
}
