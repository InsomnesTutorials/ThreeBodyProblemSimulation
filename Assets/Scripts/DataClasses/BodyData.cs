 using UnityEngine;

 public struct BodyData
 {
     public float mass;
     public Vector2 position;
     public Vector2 velocity;
    
     public BodyData(string name, float mass, float radius, Vector2 position, Vector2 velocity, Vector2 acceleration, Color color)
     {
         this.mass = mass;
         this.position = position;
         this.velocity = velocity;
     }
 }
