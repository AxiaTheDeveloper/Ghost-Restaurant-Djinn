using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MasakGodong {

public class NGonRenderer : MonoBehaviour
{
    public float radius;
    
    public Vector2[] pointPositions = new Vector2[0];

    private struct Quad {
        public Vector2 topLeft;
        public Vector2 topRight;
        public Vector2 bottomLeft;
        public Vector2 bottomRight;
        
        public override string ToString() {
            return "(" + topLeft + ", " + topRight + ", " + bottomLeft + ", " + bottomRight + ")";
        }
    }

    private Quad[] quads = new Quad[0];

    private int pointCount;
    
    public int dontDrawCount;

    public float lineWidth;

    public float lineRotation;
    
    Material lineMaterial;

    Color lineColor;

    void OnEnable()
     {
         RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
     }
     void OnDisable()
     {
         RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
     }
     private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext context, Camera camera)
     {
        drawLines();
     }

    // Start is called before the first frame update
    void Start()
    {    
        lineMaterial = null;
        lineColor = new Color(0.70588f, 1, 0.831373f, 1);

        pointCount = pointPositions.Length;
        
        quads = new Quad[pointCount];

        for(int i = 0; i < pointCount; ++i)
        {
            float a = i / (float) pointCount;

            float angle = a * Mathf.PI * 2;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            pointPositions[i] = new Vector2(x, y); 
        }

        for(int i = 1; i <= pointCount; i++) {
            Vector2 first;
            Vector2 second;
            if(i == pointCount) {
                first = pointPositions[i-1];
                second = pointPositions[0];
            } else {
                first = pointPositions[i-1];
                second = pointPositions[i];
            }

            quads[i-1] = new Quad();
            
            quads[i-1].bottomLeft = generateWidth(first, second, true);
            quads[i-1].bottomRight = generateWidth(first, second, false);

            quads[i-1].topLeft = generateWidth(second, first, true);
            quads[i-1].topRight = generateWidth(second, first, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // drawLines();
    }

    /**
     * this function will be ran when a value changes.
     * So it's used to calculate the points of circle
     */
    public void OnValidate() 
    {
        pointCount = pointPositions.Length;
        
        quads = new Quad[pointCount];

        for(int i = 0; i < pointCount; ++i)
        {
            float a = i / (float) pointCount;

            float angle = a * Mathf.PI * 2;

            float x = radius * Mathf.Cos(angle);
            float y = radius * Mathf.Sin(angle);

            pointPositions[i] = new Vector2(x, y); 
        }

        for(int i = 1; i <= pointCount; i++) {
            Vector2 first;
            Vector2 second;
            if(i == pointCount) {
                first = pointPositions[i-1];
                second = pointPositions[0];
            } else {
                first = pointPositions[i-1];
                second = pointPositions[i];
            }

            quads[i-1] = new Quad();
            
            quads[i-1].bottomLeft = generateWidth(first, second, true);
            quads[i-1].bottomRight = generateWidth(first, second, false);

            quads[i-1].topLeft = generateWidth(second, first, true);
            quads[i-1].topRight = generateWidth(second, first, false);
        }
    }

    void CreateLineMaterial() 
    {
        if(lineMaterial == null) {
            Shader shader = Shader.Find("Hidden/Internal-Colored");

            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            lineMaterial.color = new Color(18, 255, 212);

            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);

            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    void drawLines() 
    {
        CreateLineMaterial();

        GL.PushMatrix();
        lineMaterial.SetPass(0);

        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.QUADS);
        GL.Color(Color.cyan);

        drawQuad();

        GL.End();

        GL.PopMatrix();

    }

    Vector2 generateWidth(Vector2 first, Vector2 second, bool isLeft) {
        int negMult = isLeft ? 1 : -1;


        float diffY = first.y - second.y;
        float diffX = first.x - second.x;

        float distance = Mathf.Sqrt(diffY * diffY + diffX * diffX );
        float angle = Mathf.Atan2(diffY, diffX);

        Vector2 tempPoint = new Vector2();
        tempPoint.x = (lineWidth * Mathf.Cos(angle));
        tempPoint.y = (lineWidth * Mathf.Sin(angle));

        Vector2 result = new Vector2();
        result.x = (negMult * -1 * tempPoint.y) + first.x;
        result.y = (negMult * tempPoint.x) + first.y;

        return result;
    }

    void drawQuad() {
        for(int i = 0; i < quads.Length; ++i)
        {
            if(i > pointCount - dontDrawCount - 1)
            {
                break;
            }

            Quad quad = quads[i];
            quad = rotateQuad(quad, lineRotation);

            drawMainQuad(quad);

            Quad quadSecond =  new Quad();

            if(i == 0) 
            {
                if(dontDrawCount > 0) 
                {
                    continue;
                }
                quadSecond = quads[quads.Length - 1];

            }
            else
            {
                quadSecond = quads[i-1];
            }

            quadSecond = rotateQuad(quadSecond, lineRotation);
            drawGapQuad(quadSecond, quad);

        }
    }

    void drawMainQuad(Quad quad) {
        GL.Vertex(quad.bottomLeft);
        GL.Vertex(quad.bottomRight);
        GL.Vertex(quad.topLeft);
        GL.Vertex(quad.topRight);
    }
    
    void drawGapQuad(Quad quad1, Quad quad2) {
        GL.Vertex(quad1.topLeft);
        GL.Vertex(quad1.topRight);
        GL.Vertex(quad2.bottomLeft);
        GL.Vertex(quad2.bottomRight);
    }

    public void OnDrawGizmos() 
    {
        drawLines();
    }

    public int PointInLines(Vector2 point)
    {
        int line = -1;

        float area = quadArea(quads[0]);
        
        for(int i = 0; i < quads.Length; ++i) 
        {
            if(i > pointCount - dontDrawCount - 1)
            {
                break;
            }

            Quad quad = quads[i];
            quad = rotateQuad(quad, lineRotation);
            quad = quadPositionToWorld(quad);

            /**
             * we will check if point is inside rectangle by first
             * making a triangle from sides of rectangle and the point
             * and then check if the sum of sides is equal to rectangle
             * if it is then the point is inside of rectangle
             * 
             * each area is formed by the point to the two edges of rectangle
             */

            float area1 = triadArea(quad.bottomLeft, quad.bottomRight, point);
            float area2 = triadArea(quad.bottomRight, quad.topLeft, point);
            float area3 = triadArea(quad.topLeft, quad.topRight, point);
            float area4 = triadArea(quad.topRight, quad.bottomLeft, point);

            if(area1 + area2 + area3 + area4 <= area) {
                line = i;
                break;
            } 
        }

        return line;
    }

    Quad quadPositionToWorld(Quad quad) {
        Vector2 position = transform.position;

        quad.bottomLeft += position;
        quad.bottomRight += position;
        quad.topLeft += position;
        quad.topRight += position;

        return quad;
    }

    float triadArea(Vector2 a, Vector2 b, Vector2 c) {
        float side1 = pointDistance(a, b);
        float side2 = pointDistance(a, c);
        float side3 = pointDistance(b, c);

        float perim = (side1 + side2 + side3) / 2;

        return Mathf.Sqrt(perim * (perim - side1) * (perim - side2) * (perim - side3));
    }

    float quadArea(Quad quad) {
        float a = pointDistance(quad.bottomLeft, quad.bottomRight);
        float b = pointDistance(quad.bottomLeft, quad.topLeft);

        return a * b;
    }

    float pointDistance(Vector2 a, Vector2 b) 
    {
        float diffY = a.y - b.y;
        float diffX = a.x - b.x;
        return Mathf.Sqrt(diffX*diffX + diffY*diffY);
    }
    
    Quad rotateQuad(Quad quad, float rotation) 
    {
        Quad result = new Quad();

        result.bottomLeft = rotatePoint(quad.bottomLeft, rotation);
        result.bottomRight = rotatePoint(quad.bottomRight, rotation);
        result.topLeft = rotatePoint(quad.topLeft, rotation);
        result.topRight = rotatePoint(quad.topRight, rotation);

        return result;
    }

    Vector2 rotatePoint(Vector2 point, float rotation) 
    {
        float cosRes = Mathf.Cos(rotation);
        float sinRes = Mathf.Sin(rotation);

        return new Vector2(
            cosRes * point.x - sinRes * point.y,
            sinRes * point.x + cosRes * point.y
        );
    }

    public bool IsLast(int lineNumber) {
        return lineNumber == pointCount - dontDrawCount - 1;
    }
}

}