using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColisionTipo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Localizador;
    public GameObject PielTipo2;
    public GameObject PielTipo3Derecha;
    public GameObject PielTipo3Izquierda;
    public GameObject[] enmedio;

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("navaja") && Mathf.Abs(other.transform.position.x-transform.position.x)<=5.0f){

            enmedio = new GameObject[20];

            // gameObject.GetComponent<MeshRenderer>().enabled=false;
            Destroy(this.gameObject);
            GameObject parteIzquierda;
            GameObject parteDerecha;
            Vector3 donde;
            donde = other.transform.position;
            float mag = donde.x-transform.position.x;
            
            // Para la parte izquierda
            float x2i = transform.position.x+0.5f*mag-0.5f-0.25f*transform.localScale.x;
            
            // Instantiate(Localizador,new Vector3(x2i,transform.position.y,transform.position.z),Quaternion.identity);
            parteIzquierda=Instantiate(PielTipo2,new Vector3(x2i,transform.position.y,transform.position.z),Quaternion.identity);
            parteIzquierda.transform.Rotate(new Vector3(90,0,0));
            float tamXi = transform.localScale.x/2+mag-1;
            parteIzquierda.transform.localScale = new Vector3(tamXi,transform.localScale.y,transform.localScale.z);
            

            // Para la parte derecha
            // float x2d = transform.position.x-0.5f*mag+0.5f+0.25f*transform.localScale.x;
            float x2d = transform.position.x+(transform.localScale.x/2-((transform.localScale.x/2-mag)-1)/2);
            // Instantiate(Localizador,new Vector3(x2d,transform.position.y,transform.position.z),Quaternion.identity);
            parteDerecha=Instantiate(PielTipo2,new Vector3(x2d,transform.position.y,transform.position.z),Quaternion.identity);
            parteDerecha.transform.Rotate(new Vector3(90,0,0));
            float tamXd = transform.localScale.x/2-mag-1;
            parteDerecha.transform.localScale = new Vector3(tamXd,transform.localScale.y,transform.localScale.z);

            // Crear las partes de enmedio
            float zIterado;
            zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*0-0.5f);
            enmedio[0]=Instantiate(PielTipo3Izquierda,new Vector3(donde.x-0.5f,transform.position.y,zIterado),Quaternion.identity);
            enmedio[1]=Instantiate(PielTipo3Derecha,new Vector3(donde.x+0.5f,transform.position.y,zIterado),Quaternion.identity);

            for(int i=2;i<20;i+=2){
                // GameObject tipo2Izquierda1;
                // GameObject tipo2Derecha1;
                zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*(i/2)-0.5f);
                
                enmedio[i]=Instantiate(PielTipo3Izquierda,new Vector3(donde.x-0.5f,transform.position.y,zIterado),Quaternion.identity);
                enmedio[i+1]=Instantiate(PielTipo3Derecha,new Vector3(donde.x+0.5f,transform.position.y,zIterado),Quaternion.identity);
                
                FixedJoint unionIzquierda1 = (enmedio[i].transform.Find("Armature.005").Find("Bone.002")).gameObject.AddComponent<FixedJoint>();
                unionIzquierda1.connectedBody = enmedio[i-2].transform.Find("Armature.005").Find("Bone.004").GetComponent<Rigidbody>();


                FixedJoint unionDerecha1 = enmedio[i+1].transform.Find("Armature.005").Find("Bone.001").gameObject.AddComponent<FixedJoint>();
                unionDerecha1.connectedBody = enmedio[i-1].transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();
                // FixedJoint unionIzquierda2 = (enmedio[i+1].transform.Find("Armature.005").Find("Bone.001")).gameObject.AddComponent<FixedJoint>();
                // unionIzquierda2.connectedBody = enmedio[i-1].transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();

                // FixedJoint unionDerecha1 = enmedio[i+2].transform.Find("Armature.005").Find("Bone.001").gameObject.AddComponent<FixedJoint>();
                // unionDerecha1.connectedBody = enmedio[i].transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();
                // FixedJoint unionDerecha2 = enmedio[i+2].transform.Find("Armature.005").Find("Bone.002").gameObject.AddComponent<FixedJoint>();
                // unionDerecha2.connectedBody = enmedio[i].transform.Find("Armature.005").Find("Bone.004").GetComponent<Rigidbody>();

                // // Crear un segundo par
                // GameObject tipo2Izquierda2;
                // GameObject tipo2Derecha2;
                // zIterado=(transform.position.z+transform.localScale.z/2- transform.localScale.z/10*i-0.5f);
                
                // // Par izquierdo
                // tipo2Izquierda2=Instantiate(PielTipo3,new Vector3(donde.x-0.5f,transform.position.y,zIterado-1f),Quaternion.identity);
                // FixedJoint unionIzquierda1 = (tipo2Izquierda2.transform.Find("Armature.005").Find("Bone.002")).gameObject.AddComponent<FixedJoint>();
                // unionIzquierda1.connectedBody = tipo2Izquierda1.transform.Find("Armature.005").Find("Bone.004").GetComponent<Rigidbody>();
                // FixedJoint unionIzquierda2 = (tipo2Izquierda2.transform.Find("Armature.005").Find("Bone.001")).gameObject.AddComponent<FixedJoint>();
                // unionIzquierda2.connectedBody = tipo2Izquierda1.transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();

                // // Par derecho
                // tipo2Derecha2=Instantiate(PielTipo3,new Vector3(donde.x+0.5f,transform.position.y,zIterado-1f),Quaternion.identity);
                // FixedJoint unionDerecha1 = tipo2Derecha2.transform.Find("Armature.005").Find("Bone.001").gameObject.AddComponent<FixedJoint>();
                // unionDerecha1.connectedBody = tipo2Derecha1.transform.Find("Armature.005").Find("Bone.003").GetComponent<Rigidbody>();
                // FixedJoint unionDerecha2 = tipo2Derecha2.transform.Find("Armature.005").Find("Bone.002").gameObject.AddComponent<FixedJoint>();
                // unionDerecha2.connectedBody = tipo2Derecha1.transform.Find("Armature.005").Find("Bone.004").GetComponent<Rigidbody>();

            }
        }
        
    }
    // void OnTriggerExit(Collider other) {
    //     print("salio");
    //     Destroy(this.gameObject);
    // }
}
