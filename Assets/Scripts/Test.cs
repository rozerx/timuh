using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        //for (int i = 0; i < 20; i++)
        //{
        //    Triangle a = new Triangle();
        //    a.RandomTriangle();
        //}
        Triangle a = new Triangle();
        a.RandomTriangle();        
    }

    public class Triangle
    {        
        public Vector3[] corners = new Vector3[3];

        //public Vector3[] corners2 = new Vector3[30];

        public void RandomTriangle()
        {
            for (int i = 0; i < corners.Length; i++)
            {
                corners[i].x = Random.Range(0, 30);
                corners[i].y = Random.Range(0, 30);
                corners[i].z = Random.Range(0, 30);
            }
            //Angle 1
            float angle1 = Vector3.Angle(corners[1] - corners[0], corners[2] - corners[0]);
            //Angle 2
            float angle2 = Vector3.Angle(corners[0] - corners[1], corners[2] - corners[1] );
            //Angle 3
            float angle3 = Vector3.Angle(corners[0] - corners[2], corners[1] - corners[2]);

            //float edgeA = Vector3.Distance(corners[0], corners[1]);
            //float edgeB = Vector3.Distance(corners[0], corners[2]);
            //float edgeC = Vector3.Distance(corners[1], corners[2]);

            //Debug.Log(" Angle 1 = " + angle1);
            //Debug.Log(" Angle 2 = " + angle2);
            //Debug.Log(" Angle 3 = " + angle3);

            //AreaWithAngle(angle1, corners);string[] triangles=new string[20]
            string[] triangles = new string[10];

            for (int i = 0; i < triangles.Length; i++)
            {

                Debug.Log(" triangle " + i + " Angle 1 = " + angle1 + " Angle 2 = " + angle2 + " Angle 3 = " + angle3);

                //Debug.Log(" norm 1 = " + edge1.magnitude);
                //Debug.Log(" norm 2 = " + edge2.magnitude);
                //Debug.Log(" norm 3 = " + edge3.magnitude);
                Vector3 line1Start = corners[0];
                Vector3 line1End = corners[1];

                Debug.DrawLine(line1Start, line1End);
                Vector3 line2Start = corners[0];
                Vector3 line2End = corners[2];

                Debug.DrawLine(line2Start, line2End);
                Vector3 line3Start = corners[2];
                Vector3 line3End = corners[1];

                Debug.DrawLine(line3Start, line3End);
            }
        }
        //public void AreaWithAngle(float anotherAngle, Vector3[] cornerz)
        //{
        //    //Triangle tri = new Triangle();
        //    float angle0 = anotherAngle;
        //    Vector3 corner0= cornerz[0];
        //    Vector3 corner1 = cornerz[1];
        //    Vector3 corner2 = cornerz[2];

        //    float edge1 = Vector3.Distance(corner0, corner1);
        //    float edge2 = Vector3.Distance(corner0, corner2);
        //    float edge3 = Vector3.Distance(corner1, corner2);

        //    float area = Mathf.Abs(edge1 * edge2 * Mathf.Sin(angle0) / 2) ;

        //    Debug.Log(" Area = " + area);
        //}        
    }
}
//              [0]
//          
//          a           b
//    
//    [2]
//              c             [1]
//    
//  Area = 1/2 * a * b * sin([0]) 


