using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Woody
{
    
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        List<Asset3d> objectList = new List<Asset3d>();
        List<Asset3d> objectList2dWoody = new List<Asset3d>();
        List<Asset3d> objectList2dJessie = new List<Asset3d>();
        List<Asset3d> objectcurveDraw = new List<Asset3d>();
        List<Asset3d> woodyHeadList = new List<Asset3d>();
        List<Asset3d> woodyHatList = new List<Asset3d>();
        List<Asset3d> woodyLegLeft = new List<Asset3d>();
        List<Asset3d> woodyLegRight = new List<Asset3d>();
       
        List<Asset3d> woodyList = new List<Asset3d>();
        List<Asset3d> woodyArmHandList = new List<Asset3d>();
        List<Asset3d> woodyHandRList = new List<Asset3d>();

        List<Asset3d> jessieList = new List<Asset3d>();
        List<Asset3d> jessieKepangList = new List<Asset3d>();

        List<Asset3d> jessieLegLeft = new List<Asset3d>();
        List<Asset3d> jessieLegRight = new List<Asset3d>();

        List<Asset3d> mrspotatoheadList= new List<Asset3d>();

        List<Asset3d> windowList = new List<Asset3d>();
        List<Asset3d> drawingList = new List<Asset3d>();

        List<Asset3d> boxList = new List<Asset3d>();

        List<Asset3d> mspotatoheadList = new List<Asset3d>();

        Asset3d woodyLeftLegCylinder;
        Asset3d woodyRightLegCylinder;
        Asset3d jessLeftLegCylinder;
        Asset3d jessRightLegCylinder;




        float degr = 0;
        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 1f;


        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            //Ganti background Warna
            GL.ClearColor(0.529f, 0.807f, 0.921f, 1.0f);



            ////WOODY HEAD JAW OUTLINE
            //var headJawOutline = new Asset3d(new Vector3(0,0,0));
            //headJawOutline.createEllipsoid(0, 0, -0.16f, 0.0855f, 0.0855f, 0.0855f);
            //objectList.Add(headJawOutline);

            ////WOODY HEAD CYLINDER OUTLINE
            //var headOutline = new Asset3d(new Vector3(0, 0, 0));
            //headOutline.createCylinder(0, -0.16f, 0f, 100, 0.0855f, 0.165f);
            //objectList.Add(headOutline);






            // back hair
            var hairback = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hairback.createEllipticParaboloid(0, -0.18f, -0.078f, 0.065f, 0.02f, 0.07f, 100, 100);
            hairback.rotate(hairback.objectCenter, Vector3.UnitX, -90);
            objectList.Add(hairback);

            woodyList.Add(hairback);

            // hair samping kanan
            var hairR = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hairR.createRectangle(0.1f, -0.059f, 0.02f, 0.01f, 0.1f, 0.01f);
            objectList.Add(hairR);

            woodyList.Add(hairR);


            // hair samping kiri
            var hairL = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hairL.createRectangle(-0.1f, -0.059f, 0.02f, 0.01f, 0.1f, 0.01f);
            objectList.Add(hairL);

            woodyList.Add(hairL);


            // hair belakang kanan
            var hairBR = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hairBR.createCylinder2(0.07f, -0.072f, -0.020f, 100, 0.04f, 0.05f, 0.08f);
            objectList.Add(hairBR);

            woodyList.Add(hairBR);

            // hair belakang kiri
            var hairBL = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hairBL.createCylinder2(-0.07f, -0.072f, -0.020f, 100, 0.04f, 0.05f, 0.08f);
            objectList.Add(hairBL);

            woodyList.Add(hairBL);



            //WOODY HEAD JAW
            var headJaw = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            headJaw.createEllipsoid(0, -0.16f, 0, 0.1f, 0.1f, 0.09f, 100, 100);
            objectList.Add(headJaw);

            woodyList.Add(headJaw);


            //WOODY HEAD CYLINDER
            var head = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            head.createCylinder2(0, -0.16f, 0f, 100, 0.1f, 0.09f, 0.16f);
            objectList.Add(head);

            woodyList.Add(head);


            //WOODY EAR RIGHT
            var earR = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            earR.createEllipsoid(0.1f, -0.11f, 0f, 0.03f, 0.04f, 0.01f, 100, 100);
            objectList.Add(earR);

            woodyList.Add(earR);

            //WOODY EAR LEFT
            var earL = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            earL.createEllipsoid(-0.1f, -0.11f, 0f, 0.03f, 0.04f, 0.01f, 100, 100);
            objectList.Add(earL);

            woodyList.Add(earL);

            /*  //WOODY HAIR FRONT MIDDLE
              var hairFM = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
              hairFM.createEllipticParaboloid(0, -0.03f, 0.15f, 0.03f, 0.02f, 0.03f, 1000, 1000);
              *//*   hairFM.createEllipsoid(0, 0.015f, 0.045f, 0.07f, 0.08f, 0.06f, 1000, 1000);*/
            /* hairFM.rotate(hairFM.objectCenter, Vector3.UnitY, 180);*//*
             objectList.Add(hairFM);*/



            //WOODY ALIS LEFT
            var alisL = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            alisL.createRectangle(-0.040f, -0.045f, 0.07f, 0.055f, 0.01f, 0.055f);
            /*     alisL.rotate(alisL.objectCenter, Vector3.UnitZ, -15);*/
            objectList.Add(alisL);

            woodyList.Add(alisL);


            //WOODY ALIS RIGHT
            var alis = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            alis.createRectangle(0.040f, -0.045f, 0.07f, 0.055f, 0.01f, 0.055f);
            objectList.Add(alis);

            woodyList.Add(alis);


            //WOODY EYE LEFT
            var eyeLeft = new Asset3d(new Vector3(1, 1, 1));
            eyeLeft.createEllipsoid(-0.031f, -0.085f, 0.053f, 0.040f, 0.040f, 0.040f, 100, 100);
            objectList.Add(eyeLeft);

            woodyList.Add(eyeLeft);


            //WOODY EYE RIGHT
            var eyeRight = new Asset3d(new Vector3(1, 1, 1));
            eyeRight.createEllipsoid(0.031f, -0.085f, 0.053f, 0.040f, 0.040f, 0.040f, 100, 100);
            objectList.Add(eyeRight);

            woodyList.Add(eyeRight);


            //WOODY EYE LEFT inside
            var eyeLeftI = new Asset3d(new Vector3(0.701f, 0.352f, 0.243f));
            eyeLeftI.createEllipsoid(-0.0377f, -0.085f, 0.0725f, 0.0215f, 0.0215f, 0.0215f, 100, 100);
            objectList.Add(eyeLeftI);

            woodyList.Add(eyeLeftI);


            //WOODY EYE RIGHT inside
            var eyeRightI = new Asset3d(new Vector3(0.701f, 0.352f, 0.243f));
            eyeRightI.createEllipsoid(0.0377f, -0.085f, 0.0725f, 0.0215f, 0.0215f, 0.0215f, 100, 100);
            objectList.Add(eyeRightI);

            woodyList.Add(eyeRightI);


            //WOODY EYE LEFT inside 2
            var eyeLeftII = new Asset3d(new Vector3(0.172f, 0.054f, 0.019f));
            eyeLeftII.createEllipsoid(-0.0415f, -0.085f, 0.083f, 0.012f, 0.012f, 0.012f, 100, 100);
            objectList.Add(eyeLeftII);

            woodyList.Add(eyeLeftII);


            //WOODY EYE RIGHT inside 2
            var eyeRightII = new Asset3d(new Vector3(0.172f, 0.054f, 0.019f));
            eyeRightII.createEllipsoid(0.0415f, -0.085f, 0.083f, 0.012f, 0.012f, 0.012f, 100, 100);
            objectList.Add(eyeRightII);

            woodyList.Add(eyeRightII);


            var nose = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            nose.createPyramid(0, -0.12f, 0.1f, 0.05f, 0.08f);
            /*            nose.rotate(nose.objectCenter, Vector3.UnitY, 180);*/
            objectList.Add(nose);

            woodyList.Add(nose);




            //WOODY NECK
            var neck = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            neck.createCylinder(0, -0.275f, 0f, 100, 0.05f, 0.05f);
            objectList.Add(neck);

            woodyList.Add(neck);


            //WOODY Scarf
            var scarf = new Asset3d(new Vector3(1f, 0f, 0f));
            scarf.createCylinder(0, -0.27f, 0f, 100, 0.052f, 0.0175f);
            objectList.Add(scarf);

            woodyList.Add(scarf);


            //WOODY BodyTOP
            /*    var bodyT = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
                bodyT.createEllipsoid(0, -0.43f, 0, 0.1f, 0.12f, 0.1f, 1000, 1000);
                objectList.Add(bodyT);*/
            //WOODY Body
            var body = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            body.createCylinder2(0, -0.5f, 0f, 100, 0.12f, 0.1f, 0.167f);
            objectList.Add(body);

            woodyList.Add(body);

            //woodie upper body
            var woodieupperbody = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            woodieupperbody.createEllipsoid(0, -0.35f, 0, 0.12f, 0.1f, 0.1f, 100, 100);
            objectList.Add(woodieupperbody);

            woodyList.Add(woodieupperbody);

            //WOODY BODYTOP
            //var bodyTop = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            //bodyTop.createEllipsoid(0, -0.3f, 0, 0.12f, 0, 0.1f, 100, 100);
            //objectList.Add(bodyTop);

            //woodyList.Add(bodyTop);


            //WOODY BELT
            var belt = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            belt.createCylinder2(0, -0.5f, 0f, 100, 0.1201f, 0.101f, 0.03f);
            objectList.Add(belt);

            woodyList.Add(belt);


            //WOODY BELT MIDDLE
            var beltM = new Asset3d(new Vector3(0.964f, 0.905f, 0.352f));
            beltM.createEllipsoid(0, -0.485f, 0.101f, 0.03f, 0.01f, 0f, 100, 100);
            objectList.Add(beltM);

            woodyList.Add(beltM);

            //WOODY sekat
            /*   var beltS1 = new Asset3d(new Vector3(0.090f, 0.517f, 0.909f));
               beltS1.createCylinder2(-0.48f, 0.07f, 0.08f, 100, 0.02f, 0.02f, 0.033f);
               beltS1.rotate(beltS1.objectCenter, Vector3.UnitZ, 90);
               beltS1.rotate(beltS1.objectCenter, Vector3.UnitX, 25);
               objectList.Add(beltS1);*/


            //WOODY BodyBot
            var bodyB = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
            bodyB.createEllipsoid(0, -0.48f, 0, 0.12f, 0.12f, 0.10f, 100, 100);
            objectList.Add(bodyB);

            woodyList.Add(bodyB);


            //WOODY LEG LEFT
            var legL = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
            legL.createCylinder(-0.047f, -0.8f, 0f, 100, 0.03f, 0.3f);
            objectList.Add(legL);

            woodyList.Add(legL);
            woodyLegLeft.Add(legL);
            woodyLeftLegCylinder = legL;


            //WOODY LEG RIGHT
            var legR = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
            legR.createCylinder(0.047f, -0.8f, 0f, 100, 0.03f, 0.3f);
            objectList.Add(legR);

            woodyList.Add(legR);
            woodyLegRight.Add(legR);
            woodyRightLegCylinder = legR;


            //WOODY BOOTS UPPER LEFT
            var booUpL = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booUpL.createCylinder(-0.046f, -0.9f, 0f, 100, 0.035f, 0.1f);
            objectList.Add(booUpL);

            woodyList.Add(booUpL);
            woodyLegLeft.Add(booUpL);

            //WOODY BOOTS UPPER RIGHT
            var booUpR = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booUpR.createCylinder(0.046f, -0.9f, 0f, 100, 0.035f, 0.1f);
            objectList.Add(booUpR);

            woodyList.Add(booUpR);
            woodyLegRight.Add(booUpR);


            //WOODY BOOTS BOTTOM LEFT
            var booDL = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDL.createCylinder2(-0.048f, -0.03f, 0.9f, 100, 0.030f, 0.02f, 0.1f);
            booDL.rotate(booDL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(booDL);

            woodyList.Add(booDL);
            woodyLegLeft.Add(booDL);

            //WOODY BOOTS BOTTOM RIGHT
            var booRL = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booRL.createCylinder2(0.048f, -0.03f, 0.9f, 100, 0.030f, 0.02f, 0.1f);
            booRL.rotate(booRL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(booRL);

            woodyList.Add(booRL);
            woodyLegRight.Add(booRL);



            //WOODY BOOTS BOTTOM LEFT FRONT
            var booDLF = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDLF.createEllipticParaboloid(-0.048f, -0.9f, 0.09f, 0.018f, 0.013f, 0.011f, 100, 100);
            booDLF.rotate(booDLF.objectCenter, Vector3.UnitX, 180);
            objectList.Add(booDLF);

            woodyList.Add(booDLF);
            woodyLegLeft.Add(booDLF);



            //WOODY BOOTS BOTTOM RIGHT FRONT
            var booDRF = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDRF.createEllipticParaboloid(0.048f, -0.9f, 0.09f, 0.018f, 0.013f, 0.011f, 100, 100);
            booDRF.rotate(booDRF.objectCenter, Vector3.UnitX, 180);
            objectList.Add(booDRF);

            woodyList.Add(booDRF);
            woodyLegRight.Add(booDRF);

            //WOODY HAND LEFT
            var handL = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            /*handL.createCylinder(0.072f, -0.472f, 0f, 100, 0.02f, 0.15f);*/
            handL.createCylinder(0.015f, -0.485f, 0f, 100, 0.02f, 0.15f);
            handL.rotate(handL.objectCenter, Vector3.UnitZ, -20);
            objectList.Add(handL);

            woodyList.Add(handL);



            //WOODY HAND LEFT bottom
            var handLB = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            handLB.createCylinder(0.058f, -0.63f, 0f, 100, 0.02f, 0.15f);
            handLB.rotate(handLB.objectCenter, Vector3.UnitZ, -25);
            objectList.Add(handLB);

            woodyList.Add(handLB);


            //WOODY PALM LEFT
            var palmL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            palmL.createCylinder2(0.058f, -0.665f, 0f, 100, 0.02f, 0.020f, 0.035f);
            palmL.rotate(palmL.objectCenter, Vector3.UnitZ, -25);
            objectList.Add(palmL);

            woodyList.Add(palmL);


            //WOODY THUMB LEFT
            var thumbL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            thumbL.createEllipsoid(-0.245f, -0.63f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            thumbL.rotate(thumbL.objectCenter, Vector3.UnitZ, 100);
            objectList.Add(thumbL);

            woodyList.Add(thumbL);



            //WOODY TELUNJUK LEFT
            var telL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            telL.createEllipsoid(-0.215f, -0.643f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            telL.rotate(telL.objectCenter, Vector3.UnitZ, 155);
            objectList.Add(telL);

            woodyList.Add(telL);


            //WOODY JARI TENGAH LEFT
            var tenL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            tenL.createEllipsoid(-0.235f, -0.643f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            tenL.rotate(tenL.objectCenter, Vector3.UnitZ, 155);
            objectList.Add(tenL);

            woodyList.Add(tenL);


            //WOODY JARI MANIS LEFT
            var manL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            manL.createEllipsoid(-0.253f, -0.638f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            manL.rotate(manL.objectCenter, Vector3.UnitZ, 155);
            objectList.Add(manL);

            woodyList.Add(manL);


            //WOODY JARI KELINGKING LEFT
            var kelL = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            kelL.createEllipsoid(-0.205f, -0.64f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            kelL.rotate(kelL.objectCenter, Vector3.UnitZ, 180);
            objectList.Add(kelL);

            woodyList.Add(kelL);


            //WOODY HAND RIGHT
            var handR = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            handR.createCylinder(-0.32f, -0.22f, 0f, 100, 0.02f, 0.15f);
            handR.rotate(handR.objectCenter, Vector3.UnitZ, 90);
            objectList.Add(handR);

            woodyList.Add(handR);
            woodyHandRList.Add(handR);

            /*var bola3 = new Asset3d(new Vector3(1, 1, 1));
            bola3.createEllipsoid(0.12f, -0.32f, 0f, 0.03f, 0.03f, 0.03f, 100, 100);
            objectList.Add(bola3);
            woodyList.Add(bola3);*/



            //WOODY HAND RIGHT UPPER
            var handRU = new Asset3d(new Vector3(0.992f, 0.756f, 0.345f));
            handRU.createCylinder(-0.385f, -0.185f, 0f, 100, 0.02f, 0.2f);
            handRU.rotate(handRU.objectCenter, Vector3.UnitZ, 125);
            objectList.Add(handRU);

            woodyList.Add(handRU);

            woodyArmHandList.Add(handRU);
            woodyHandRList.Add(handRU);




            //WOODY PALM RIGHT
            var palmR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            palmR.createCylinder2(-0.385f, -0.219f, 0f, 100, 0.02f, 0.020f, 0.035f);
            palmR.rotate(palmR.objectCenter, Vector3.UnitZ, 125);
            objectList.Add(palmR);

            woodyList.Add(palmR);

            woodyArmHandList.Add(palmR);
            woodyHandRList.Add(palmR);



            //WOODY THUMB RIGHT
            var thumbR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            thumbR.createEllipsoid(0.37f, -0.176f, 0, 0.01f, 0.02f, 0.01f, 100, 100);
            /*thumbR.rotate(thumbR.objectCenter, Vector3.UnitZ, 125);*/
            objectList.Add(thumbR);

            woodyList.Add(thumbR);

            woodyArmHandList.Add(thumbR);
            woodyHandRList.Add(thumbR);




            //WOODY TELUNJUK RIGHT
            var telR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            telR.createEllipsoid(0.388f, -0.178f, 0, 0.01f, 0.03f, 0.01f, 100, 100);
            telR.rotate(telR.objectCenter, Vector3.UnitZ, 125);
            objectList.Add(telR);

            woodyList.Add(telR);

            woodyArmHandList.Add(telR);
            woodyHandRList.Add(telR);


            //WOODY JARI TENGAH RIGHT
            var tenR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            tenR.createEllipsoid(0.396f, -0.193f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            tenR.rotate(tenR.objectCenter, Vector3.UnitZ, 125);
            objectList.Add(tenR);

            woodyList.Add(tenR);

            woodyArmHandList.Add(tenR);
            woodyHandRList.Add(tenR);



            //WOODY JARI MANIS RIGHT
            var manR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            manR.createEllipsoid(0.412f, -0.202f, 0, 0.01f, 0.033f, 0.01f, 100, 100);
            manR.rotate(manR.objectCenter, Vector3.UnitZ, 125);
            objectList.Add(manR);

            woodyList.Add(manR);

            woodyArmHandList.Add(manR);
            woodyHandRList.Add(manR);



            //WOODY JARI KELINGKING RIGHT
            var kelR = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            kelR.createEllipsoid(0.412f, -0.215f, 0, 0.01f, 0.03f, 0.01f, 100, 100);
            kelR.rotate(kelR.objectCenter, Vector3.UnitZ, 100);
            objectList.Add(kelR);

            woodyList.Add(kelR);
            woodyArmHandList.Add(kelR);
            woodyHandRList.Add(kelR);





            /* //WOODY LEG RIGHT
             var coba = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
             coba.createCylinder2(0.05f, 0.5f, 0f, 100, 0.035f, 0.015f, 0.2f);
             objectList.Add(coba);*/


            //WOODY HAT
            var hatBottom = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            hatBottom.createEllipsoid(0, 0, 0, 0.25f, 0.01f, 0.25f, 100, 100);
            objectList.Add(hatBottom);

            woodyList.Add(hatBottom);
            woodyHatList.Add(hatBottom);


            var hatline = new Asset3d(new Vector3(0.231f, 0.098f, 0.070f));
            hatline.createCylinder(0, 0, 0, 100, 0.101f, 0.03f);
            objectList.Add(hatline);

            woodyList.Add(hatline);
            woodyHatList.Add(hatline);


            var hatMiddle = new Asset3d(new Vector3(0.450f, 0.231f, 0.082f));
            hatMiddle.createCylinder(0, 0, 0, 100, 0.1f, 0.1f);
            objectList.Add(hatMiddle);

            woodyList.Add(hatMiddle);
            woodyHatList.Add(hatMiddle);


            var hatTop = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            hatTop.createEllipsoid(0, 0.1f, 0, 0.1f, 0, 0.1f, 100, 100);
            objectList.Add(hatTop);

            woodyList.Add(hatTop);
            woodyHatList.Add(hatTop);


         /*   var curve = new Asset2d(
                            new float[]
                            {
                               0,1,2,
                               3,4,5,

                               
                            },
                            new uint[]
                            {
                                0,1,2,
                               3,4,5,
                               6,7,8
                            }
                        );
            curve.createCurveBezier();
            objectList2d.Add(curve);*/

            





            /*            //WOODY Cheek right
                        var cheekRight = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
                        cheekRight.createEllipsoid(0.042f, -0.14f, 0.09f, 0.025f, 0.025f, 0.025f, 1000, 1000);
                        objectList.Add(cheekRight);*/

            //WOODY nose
            /*var nose = new Asset3d(new Vector3(0.992f, 0.929f, 0.760f));
            nose.createCuboid(0, -0.1f, 0.1f, 0.1f);
            *//*nose.rotate(nose.objectCenter, Vector3.UnitX, 115);*/
            /*            nose.rotate(nose.objectCenter, Vector3.UnitY, 45);
                        nose.rotate(nose.objectCenter, Vector3.UnitZ, 45);*//*
                        objectList.Add(nose);*/



            //ANDY'S ROOM WALL
            var leftWall = new Asset3d(new Vector3(0.270f, 0.376f, 0.474f));
            leftWall.createRectangle(-0.1f, 2.95f, -5.2f, 10.5f, 8f, 0.1f);
            leftWall.rotate(leftWall.objectCenter, Vector3.UnitY, 90);
            objectList.Add(leftWall);

            var backWall = new Asset3d(new Vector3(0.376f, 0.521f, 0.694f));
            backWall.createRectangle(-0f, 2.95f, -5.2f, 10.5f, 8f, 0.1f);
            backWall.rotate(backWall.objectCenter, Vector3.UnitY, 0);
            objectList.Add(backWall);

            var rightWall = new Asset3d(new Vector3(0.270f, 0.376f, 0.474f));
            rightWall.createRectangle(-0f, 2.95f, -5.3f, 10.5f, 8f, 0.1f);
            rightWall.rotate(rightWall.objectCenter, Vector3.UnitY, -90);
            objectList.Add(rightWall);

            var frontWall = new Asset3d(new Vector3(0.376f, 0.521f, 0.694f));
            frontWall.createRectangle(-0.1f, 2.95f, -5.3f, 10.5f, 8f, 0.1f);
            frontWall.rotate(frontWall.objectCenter, Vector3.UnitY, 180);
            objectList.Add(frontWall);

            var bottomWall = new Asset3d(new Vector3(0.831f, 0.756f, 0.576f));
            bottomWall.createRectangle(0f, -1f, 0f, 10.5f, 0.1f, 10.5f);
            //bottomWall.rotate(bottomWall.objectCenter, Vector3.UnitX, -90);
            //bottomWall.rotate(bottomWall.objectCenter, Vector3.UnitY, 45);
            objectList.Add(bottomWall);

            //ANDY'S RUG
            var innerRug = new Asset3d(new Vector3(0.250f, 0.419f, 0.564f));
            innerRug.createEllipsoid(0, -0.942f, 0, 0.9f, 0, 1.2f, 100, 100);
            objectList.Add(innerRug);

            var middleRug = new Asset3d(new Vector3(0.603f, 0.627f, 0.678f));
            middleRug.createEllipsoid(0, -0.9425f, 0, 1.2f, 0, 1.6f, 100, 100);
            objectList.Add(middleRug);

            var outerRug = new Asset3d(new Vector3(0.250f, 0.419f, 0.564f));
            outerRug.createEllipsoid(0, -0.943f, 0, 1.5f, 0, 2f, 100, 100);
            objectList.Add(outerRug);

            //ANDY'S BED
            var bedFrontWood = new Asset3d(new Vector3(0.325f, 0.211f, 0.137f));
            bedFrontWood.createRectangle(-3.45f, -0.85f, 0f, 3, 0.2f, 0.2f);
            objectList.Add(bedFrontWood);

            var bedBackWood = new Asset3d(new Vector3(0.325f, 0.211f, 0.137f));
            bedBackWood.createRectangle(-3.45f, -0.85f, -4.848f, 3, 0.2f, 0.2f);
            objectList.Add(bedBackWood);

            var bedMiddleWood = new Asset3d(new Vector3(0.325f, 0.211f, 0.137f));
            bedMiddleWood.createRectangle(-3.45f, -0.65f, -2.425f, 3, 0.2f, 5.05f);
            objectList.Add(bedMiddleWood);

            var bedBlue = new Asset3d(new Vector3(0.105f, 0.458f, 0.674f));
            bedBlue.createRectangle(-3.45f, 0.31f, -(1f / 3f) * 4.67f - 0.095f, 3, 1.725f, (2f / 3f) * 4.67f);
            objectList.Add(bedBlue);

            var bedWhite = new Asset3d(new Vector3(1, 1, 1));
            bedWhite.createRectangle(-3.45f, 0.3f, -(5f / 6f) * 4.67f - 0.095f, 3, 1.7f, (1f / 3f) * 4.67f);
            objectList.Add(bedWhite);

            var bedUpFrontWood = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedUpFrontWood.createRectangle(-3.45f, 0.445f, 0f, 3, 2f, 0.2f);
            objectList.Add(bedUpFrontWood);

            var bedUpBackWood = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedUpBackWood.createRectangle(-3.45f, 0.945f, -4.858f, 3, 3f, 0.178f);
            objectList.Add(bedUpBackWood);

            var bedFrontCurve = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedFrontCurve.createEllipticParaboloid(-3.45f, 1.935f, 0, 0.05f, 0.5f, 0.2f, 100, 100);
            bedFrontCurve.rotate(bedFrontCurve.objectCenter, Vector3.UnitX, 90);
            bedFrontCurve.rotate(bedFrontCurve.objectCenter, Vector3.UnitY, 90);
            objectList.Add(bedFrontCurve);

            var bedBackCurve = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedBackCurve.createEllipticParaboloid(-3.45f, 2.935f, -4.858f, 0.05f, 0.5f, 0.2f, 100, 100);
            bedBackCurve.rotate(bedBackCurve.objectCenter, Vector3.UnitX, 90);
            bedBackCurve.rotate(bedBackCurve.objectCenter, Vector3.UnitY, 90);
            objectList.Add(bedBackCurve);

            var bedRightBotTower = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedRightBotTower.createRectangle(-2.05f, 1.695f, 0, 0.2f, 0.5f, 0.2f);
            objectList.Add(bedRightBotTower);

            var bedRightBotBall = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedRightBotBall.createEllipsoid(-2.05f, 1.695f, 0, 0.2f, 0.2f, 0.2f, 100, 100);
            objectList.Add(bedRightBotBall);

            var bedLeftBotTower = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedLeftBotTower.createRectangle(-4.85f, 1.695f, 0, 0.2f, 0.5f, 0.2f);
            objectList.Add(bedLeftBotTower);

            var bedLeftBotBall = new Asset3d(new Vector3(0.454f, 0.294f, 0.192f));
            bedLeftBotBall.createEllipsoid(-4.85f, 1.695f, 0, 0.2f, 0.2f, 0.2f, 100, 100);
            objectList.Add(bedLeftBotBall);

            var bedRightTopTower = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedRightTopTower.createRectangle(-2.05f, 2.695f, -4.858f, 0.2f, 0.5f, 0.178f);
            objectList.Add(bedRightTopTower);

            var bedRightTopCone = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedRightTopCone.createCone(-2.05f, 3.095f, -4.858f, 0.2f, 0.2f, 0.2f, 100, 100);
            bedRightTopCone.rotate(bedRightTopCone.objectCenter, Vector3.UnitX, 180);
            objectList.Add(bedRightTopCone);

            var bedLeftTopTower = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedLeftTopTower.createRectangle(-4.85f, 2.695f, -4.858f, 0.2f, 0.5f, 0.178f);
            objectList.Add(bedLeftTopTower);

            var bedLeftTopCone = new Asset3d(new Vector3(0.513f, 0.325f, 0.203f));
            bedLeftTopCone.createCone(-4.85f, 3.095f, -4.858f, 0.2f, 0.2f, 0.2f, 100, 100);
            bedLeftTopCone.rotate(bedLeftTopCone.objectCenter, Vector3.UnitX, 180);
            objectList.Add(bedLeftTopCone);

            var pillow = new Asset3d(new Vector3(0.964f, 0.952f, 0.952f));
            pillow.createRectangle(-3.45f, 1.275f, -(5f / 6f) * 4.67f - 0.095f, 1.75f, 0.25f, 1.2f);
            objectList.Add(pillow);

            //ANDY'S TREASURE BOX
            var treasureCurve = new Asset3d(new Vector3(0.792f, 0.725f, 0.552f));
            treasureCurve.createCylinder3(-3.45f, 0.6f, 1.2f, 1, 0.6f, 1, 300, 300);
            treasureCurve.rotate(treasureCurve.objectCenter, Vector3.UnitX, 90);
            treasureCurve.rotate(treasureCurve.objectCenter, Vector3.UnitY, 90);
            objectList.Add(treasureCurve);

            var treasureRightClose = new Asset3d(new Vector3(1,1,1));
            treasureRightClose.createEllipsoid(-2.52f, 0.6f, 1.2f, 0, 1, 1f, 100, 100);
            treasureRightClose.rotate(treasureRightClose.objectCenter, Vector3.UnitX, 90);
            objectList.Add(treasureRightClose);

            var treasureLeftClose = new Asset3d(new Vector3(1, 1, 1));
            treasureLeftClose.createEllipsoid(-4.38f, 0.6f, 1.2f, 0, 1, 1f, 100, 100);
            treasureLeftClose.rotate(treasureLeftClose.objectCenter, Vector3.UnitX, 90);
            objectList.Add(treasureLeftClose);

            var treasureBoxGreen = new Asset3d(new Vector3(0.223f, 0.517f, 0.164f));
            treasureBoxGreen.createRectangle(-3.45f, 0.05f, 1.2f, 1.89f, (2f/3f)*1.5f, 2f);
            objectList.Add(treasureBoxGreen);

            var treasureBoxBlue = new Asset3d(new Vector3(0.282f, 0.552f, 0.835f));
            treasureBoxBlue.createRectangle(-3.45f, -0.7f, 1.2f, 1.89f, (1f/3f)*1.5f, 2f);
            objectList.Add(treasureBoxBlue);

            //ANDY'S Window
            var windowRBottom = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            windowRBottom.createRectangle(1.3f, 2f, -5.125f, 2.7f, 0.2f, 0.05f);
            objectList.Add(windowRBottom);
            /*  var windowRBottomL = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
              windowRBottomL.createRectangle(1.3f, 2f, -5.1f, 2.7f, 0.25f, 0f);
              objectList.Add(windowRBottomL);*/

            var windowRBottomU = new Asset3d(new Vector3(0.682f, 0.670f, 0.635f));
            windowRBottomU.createRectangle(1.289f, 2.1f, -5.075f, 2.8f, 0.1f, 0.15f);
            objectList.Add(windowRBottomU);

            var windowRtop = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            windowRtop.createRectangle(1.289f, 5.4f, -5.125f, 2.8f, 0.2f, 0.05f);
            objectList.Add(windowRtop);

            var windowRLuar = new Asset3d(new Vector3(0.870f, 0.870f, 0.874f));
            windowRLuar.createRectangle(1.3f, 3.8f, -5.1f, 2.7f, 3.3f, 0.03f);
            objectList.Add(windowRLuar);

            var windowRLuar2 = new Asset3d(new Vector3(0.960f, 0.960f, 0.960f));
            windowRLuar2.createRectangle(1.305f, 3.7f, -5.075f, 2.5f, 2.9f, 0.025f);
            objectList.Add(windowRLuar2);

            var windowRDalam1 = new Asset3d(new Vector3(0.819f, 0.819f, 0.823f));
            windowRDalam1.createRectangle(1.31f, 3.7f, -5.05f, 2.2f, 2.7f, 0.025f);
            objectList.Add(windowRDalam1);

            var windowRDalamA = new Asset3d(new Vector3(0.803f, 0.882f, 0.960f));
            windowRDalamA.createRectangle(1.31f, 4.35f, -5.05f, 2.0f, 1.2f, 0.029f);
            objectList.Add(windowRDalamA);

            var windowRDalamB = new Asset3d(new Vector3(0.803f, 0.882f, 0.960f));
            windowRDalamB.createRectangle(1.31f, 3.05f, -5.05f, 2.0f, 1.2f, 0.029f);
            objectList.Add(windowRDalamB);

            //ANDY'S Window L
            var windowLBottom = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            windowLBottom.createRectangle(1.3f, 2f, -5.125f, 2.7f, 0.2f, 0.05f);
            objectList.Add(windowLBottom);
            windowList.Add(windowLBottom);
            /*  var windowRBottomL = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
              windowRBottomL.createRectangle(1.3f, 2f, -5.1f, 2.7f, 0.25f, 0f);
              objectList.Add(windowRBottomL);*/

            var windowLBottomU = new Asset3d(new Vector3(0.682f, 0.670f, 0.635f));
            windowLBottomU.createRectangle(1.289f, 2.1f, -5.075f, 2.8f, 0.1f, 0.15f);
            objectList.Add(windowLBottomU);
            windowList.Add(windowLBottomU);

            var windowLtop = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            windowLtop.createRectangle(1.289f, 5.4f, -5.125f, 2.8f, 0.2f, 0.05f);
            objectList.Add(windowLtop);
            windowList.Add(windowLtop);

            var windowLLuar = new Asset3d(new Vector3(0.870f, 0.870f, 0.874f));
            windowLLuar.createRectangle(1.3f, 3.8f, -5.1f, 2.7f, 3.3f, 0.03f);
            objectList.Add(windowLLuar);
            windowList.Add(windowLLuar);

            var windowLLuar2 = new Asset3d(new Vector3(0.960f, 0.960f, 0.960f));
            windowLLuar2.createRectangle(1.305f, 3.7f, -5.075f, 2.5f, 2.9f, 0.025f);
            objectList.Add(windowLLuar2);
            windowList.Add(windowLLuar2);

            var windowLDalam1 = new Asset3d(new Vector3(0.819f, 0.819f, 0.823f));
            windowLDalam1.createRectangle(1.31f, 3.7f, -5.05f, 2.2f, 2.7f, 0.025f);
            objectList.Add(windowLDalam1);
            windowList.Add(windowLDalam1);

            var windowLDalamA = new Asset3d(new Vector3(0.803f, 0.882f, 0.960f));
            windowLDalamA.createRectangle(1.31f, 4.35f, -5.05f, 2.0f, 1.2f, 0.029f);
            objectList.Add(windowLDalamA);
            windowList.Add(windowLDalamA);

            var windowLDalamB = new Asset3d(new Vector3(0.803f, 0.882f, 0.960f));
            windowLDalamB.createRectangle(1.31f, 3.05f, -5.05f, 2.0f, 1.2f, 0.029f);
            objectList.Add(windowLDalamB);
            windowList.Add(windowLDalamB);


            //ANDY'S BOX
            var boxB = new Asset3d(new Vector3(0.435f, 0.294f, 0.184f));
            boxB.createRectangle(4.15f, -0.945f, -4f,0.5f,0f,0.5f);
            objectList.Add(boxB);
            var box1 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box1.createRectangle(4.15f, -0.7f, -4.25f, 0.5f, 0.5f, 0f);
            objectList.Add(box1);
            var box2 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box2.createRectangle(4.15f, -0.7f, -3.75f, 0.5f, 0.5f, 0f);
            objectList.Add(box2);
            var box3 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box3.createRectangle(3.9f, -0.7f, -4f, 0f, 0.5f, 0.5f);
            objectList.Add(box3);
            var box4 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box4.createRectangle(4.40f, -0.7f, -4f, 0f, 0.5f, 0.5f);
            objectList.Add(box4);
            
            //outside
            var box5 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box5.createRectangle(2.31f, -3.077f, -4f, 0.25f, 0f, 0.5f);
            box5.rotate(box5.objectCenter, Vector3.UnitZ, 45);
            objectList.Add(box5);



            //ANDY'S BOX
            var boxB2 = new Asset3d(new Vector3(0.435f, 0.294f, 0.184f));
            boxB2.createRectangle(4.15f, -0.945f, -4f, 0.5f, 0f, 0.5f);
            objectList.Add(boxB2);
            boxList.Add(boxB2);
            var box12 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box12.createRectangle(4.15f, -0.7f, -4.25f, 0.5f, 0.5f, 0f);
            objectList.Add(box12);
            boxList.Add(box12);
            var box22 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box22.createRectangle(4.15f, -0.7f, -3.75f, 0.5f, 0.5f, 0f);
            objectList.Add(box22);
            boxList.Add(box22);
            var box32 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box32.createRectangle(3.9f, -0.7f, -4f, 0f, 0.5f, 0.5f);
            objectList.Add(box32);
            boxList.Add(box32);
            var box42 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box42.createRectangle(4.40f, -0.7f, -4f, 0f, 0.5f, 0.5f);
            objectList.Add(box42);
            boxList.Add(box42);

            //outside
            var box52 = new Asset3d(new Vector3(0.588f, 0.356f, 0.180f));
            box52.createRectangle(2.31f, -3.077f, -4f, 0.25f, 0f, 0.5f);
            box52.rotate(box52.objectCenter, Vector3.UnitZ, 45);
            objectList.Add(box52);
            boxList.Add(box52);

            //ANDY'S TRASH CAN
            var trashCan = new Asset3d(new Vector3(0.490f, 0.376f, 0.274f));
            trashCan.createCylinder(4.35f, -0.913f, -2.35f, 100, 0.5f, 1.2f);
            objectList.Add(trashCan);

            var trashCanTutup = new Asset3d(new Vector3(0.407f, 0.313f, 0.231f));
            trashCanTutup.createEllipsoid(4.35f, -0.913f, -2.35f, 0.5f, 0, 0.5f, 100, 100);
            objectList.Add(trashCanTutup);

            //ANDY'S BLOCK TOY
            //var block1 = new Asset3d(new Vector3(0.709f, 0.588f, 0.392f));
            var block1 = new Asset3d(new Vector3(0,0,1));
            block1.createCuboid(-1.7f, -0.8f, 0.6f, 0.3f);
            objectList.Add(block1);

            var block2 = new Asset3d(new Vector3(0,1,0));
            block2.createCuboid(-2.1f, -0.8f, 0.8f, 0.3f);
            objectList.Add(block2);

            var block3 = new Asset3d(new Vector3(1,0,0));
            block3.createCuboid(-1.9f, -0.5f, 0.7f, 0.3f);
            objectList.Add(block3);

            //ANDY'S SMALL TABLE
            var smallTableTop = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            smallTableTop.createRectangle(-1, 1.3f, -4.3f, 1.5f, 0.1f, 1.5f);
            objectList.Add(smallTableTop);

            var smallTableTopBot = new Asset3d(new Vector3(0.756f, 0.733f, 0.662f));
            smallTableTopBot.createRectangle(-1, 1.2f, -4.3f, 1.4f, 0.1f, 1.4f);
            objectList.Add(smallTableTopBot);

            //var smallTableTopBot2Mid = new Asset3d(new Vector3(0.717f, 0.698f, 0.643f));
            var smallTableTopBot2Mid = new Asset3d(new Vector3(0.854f, 0.843f, 0.807f));
            smallTableTopBot2Mid.createRectangle(-1, 1f, -4.3f, 1.3f, 0.3f, 1.1f);
            objectList.Add(smallTableTopBot2Mid);

            var smallTableTopBot2Front = new Asset3d(new Vector3(0.854f, 0.843f, 0.807f));
            smallTableTopBot2Front.createRectangle(-1, 1f, -3.7f, 1.1f, 0.3f, 0.1f);
            objectList.Add(smallTableTopBot2Front);

            var smallTableTopBot2Back = new Asset3d(new Vector3(0.854f, 0.843f, 0.807f));
            smallTableTopBot2Back.createRectangle(-1, 1f, -4.9f, 1.1f, 0.3f, 0.1f);
            objectList.Add(smallTableTopBot2Back);

            var smallTableFrontRightTower = new Asset3d(new Vector3(0.949f, 0.937f, 0.913f));
            smallTableFrontRightTower.createRectangle(-0.4f, 0.10f, -3.7f, 0.1f, 2.1f, 0.1f);
            objectList.Add(smallTableFrontRightTower);

            var smallTableFrontLeftTower = new Asset3d(new Vector3(0.949f, 0.937f, 0.913f));
            smallTableFrontLeftTower.createRectangle(-1.6f, 0.10f, -3.7f, 0.1f, 2.1f, 0.1f);
            objectList.Add(smallTableFrontLeftTower);

            var smallTableBackRightTower = new Asset3d(new Vector3(0.949f, 0.937f, 0.913f));
            smallTableBackRightTower.createRectangle(-0.4f, 0.10f, -4.9f, 0.1f, 2.1f, 0.1f);
            objectList.Add(smallTableBackRightTower);

            var smallTableBackLeftTower = new Asset3d(new Vector3(0.949f, 0.937f, 0.913f));
            smallTableBackLeftTower.createRectangle(-1.6f, 0.10f, -4.9f, 0.1f, 2.1f, 0.1f);
            objectList.Add(smallTableBackLeftTower);
            
            var smallTableHandle = new Asset3d(new Vector3(0.901f, 0.713f, 0.509f));
            smallTableHandle.createEllipsoid(-1, 1, -3.64f, (1f / 4f) * 1.1f, 0.1f, 0, 100, 100);
            objectList.Add(smallTableHandle);

            var smallTableHandleTorus = new Asset3d(new Vector3(0.909f, 0.670f, 0.407f));
            smallTableHandleTorus.createTorus(-1, 1, -3.62f, 0.15f, 0.025f, 100, 100);
            objectList.Add(smallTableHandleTorus);

            //BIG TABLE
            var bigTableDraw = new Asset3d(new Vector3(0.949f, 0.129f, 0.207f));
            bigTableDraw.createRectangle(4.5f, 1.1f, 0, 0.5f, 0.05f, 0.7f);
            objectList.Add(bigTableDraw);
            drawingList.Add(bigTableDraw);
            var bigTableDrawI = new Asset3d(new Vector3(1, 1, 1f));
            bigTableDrawI.createRectangle(4.55f, 1.11f, 0, 0.3f, 0.05f, 0.5f);
            objectList.Add(bigTableDrawI);
            drawingList.Add(bigTableDrawI);

            var bigTableDrawEdgeR = new Asset3d(new Vector3(1, 1, 1f));
            bigTableDrawEdgeR.createEllipsoid(4.33f, 1.13f, -0.25f, 0.04f, 0f, 0.04f, 100, 100);
            objectList.Add(bigTableDrawEdgeR);
            drawingList.Add(bigTableDrawEdgeR);

            var bigTableDrawEdgeL = new Asset3d(new Vector3(1, 1, 1f));
            bigTableDrawEdgeL.createEllipsoid(4.33f, 1.13f, 0.25f, 0.04f, 0f, 0.04f, 100, 100);
            objectList.Add(bigTableDrawEdgeL);
            drawingList.Add(bigTableDrawEdgeL);

            var bigTableDrawingL = new Asset3d(new Vector3(0, 0, 0f));
            bigTableDrawingL.createEllipsoid(4.5f, 1.14f, 0.1f, 0.03f, 0f, 0.03f, 100, 100);
            objectList.Add(bigTableDrawingL);
            drawingList.Add(bigTableDrawingL);

            /*            var bigTableDrawingR = new Asset3d(new Vector3(0, 0, 0f));
                        bigTableDrawingR.createEllipsoid(4.5f, 1.4f, 0.2f, 0.03f, 0f, 0.03f, 100, 100);
                        objectList.Add(bigTableDrawingR);*/
            var bigTableDrawingR = new Asset3d(new Vector3(0, 0, 0f));
            bigTableDrawingR.createEllipsoid(4.5f, 1.14f, -0.1f, 0.03f, 0f, 0.03f, 100, 100);
            objectList.Add(bigTableDrawingR);
            drawingList.Add(bigTableDrawingR);



            var bigTableTop = new Asset3d(new Vector3(0.803f, 0.658f, 0.419f));
            bigTableTop.createRectangle(4.5f, 1, 0, 1.5f, 0.15f, 3);
            objectList.Add(bigTableTop);

            var bigTableRedTop = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableRedTop.createRectangle(4.5f, 0.725f, 0, 1.3f, 0.4f, 2.7f);
            objectList.Add(bigTableRedTop);

            var bigTableRedBox = new Asset3d(new Vector3(0.490f, 0.184f, 0.168f));
            bigTableRedBox.createRectangle(4.5f, -0.075f, -1f, 1.3f, 1.2f, 0.7f);
            objectList.Add(bigTableRedBox);

            var bigTableDrawer1 = new Asset3d(new Vector3(0.568f, 0.227f, 0.211f));
            bigTableDrawer1.createRectangle(4.49f, 0.17f, -1f, 1.3f, 0.5f, 0.5f);
            objectList.Add(bigTableDrawer1);

            var bigTableDrawer2 = new Asset3d(new Vector3(0.568f, 0.227f, 0.211f));
            bigTableDrawer2.createRectangle(4.49f, -0.35f, -1f, 1.3f, 0.4f, 0.5f);
            objectList.Add(bigTableDrawer2);

            var bigTableRedBack = new Asset3d(new Vector3(0.403f, 0.149f, 0.137f));
            bigTableRedBack.createRectangle(5.05f, -0.075f, 0.35f, 0.2f, 1.2f, 2f);
            objectList.Add(bigTableRedBack);

            var bigTableFrontLeft = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableFrontLeft.createRectangle(3.95f, -0.813f, -1.25f, 0.2f, 0.2725f, 0.2f);
            objectList.Add(bigTableFrontLeft);

            var bigTableBackLeft = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableBackLeft.createRectangle(5.05f, -0.813f, -1.25f, 0.2f, 0.2725f, 0.2f);
            objectList.Add(bigTableBackLeft);

            var bigTableBackRight = new Asset3d(new Vector3(0.403f, 0.149f, 0.137f));
            bigTableBackRight.createRectangle(5.05f, -0.813f, 1.25f, 0.2f, 0.2725f, 0.2f);
            objectList.Add(bigTableBackRight);

            var bigTableFrontRight = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableFrontRight.createRectangle(3.95f, -0.212f, 1.25f, 0.2f, 1.475f, 0.2f);
            objectList.Add(bigTableFrontRight);

            var bigTableHandle1 = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableHandle1.createCylinder(0.2f, -3.85f, -1f, 100, 0.01f, 0.05f);
            bigTableHandle1.rotate(bigTableHandle1.objectCenter, Vector3.UnitZ, 90);
            objectList.Add(bigTableHandle1);

            var bigTableBall1 = new Asset3d(new Vector3(0.721f, 0.149f, 0.117f));
            bigTableBall1.createEllipsoid(3.775f, 0.2f, -1, 0.05f, 0.05f, 0.05f, 100, 100);
            objectList.Add(bigTableBall1);

            var bigTableHandle2 = new Asset3d(new Vector3(0.611f, 0.176f, 0.168f));
            bigTableHandle2.createCylinder(-0.35f, -3.85f, -1f, 100, 0.01f, 0.05f);
            bigTableHandle2.rotate(bigTableHandle1.objectCenter, Vector3.UnitZ, 90);
            objectList.Add(bigTableHandle2);

            var bigTableBall2 = new Asset3d(new Vector3(0.721f, 0.149f, 0.117f));
            bigTableBall2.createEllipsoid(3.775f, -0.35f, -1, 0.05f, 0.05f, 0.05f, 100, 100);
            objectList.Add(bigTableBall2);

            //JESSIE
            var rambut = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut.createTorus(0, -0.004f, 0, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut);

            jessieList.Add(rambut);

            var rambut1 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut1.createTorus(0, -0.04f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut1);

            jessieList.Add(rambut1);

            var rambut101 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut101.createTorus(0.02f, -0.03f, -0.025f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut101);

            jessieList.Add(rambut101);


            var rambut102 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut102.createTorus(-0.02f, -0.03f, -0.025f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut102);

            jessieList.Add(rambut102);


            var rambut11 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut11.createTorus(0.02f, -0.04f, -0.025f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut11);

            jessieList.Add(rambut11);


            var rambut12 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut12.createTorus(-0.02f, -0.04f, -0.025f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut12);

            jessieList.Add(rambut12);


            //===================================================

            var rambut2 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut2.createTorus(0, -0.07f, -0.03f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut2);

            jessieList.Add(rambut2);

            var rambut201 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut201.createTorus(0.025f, -0.06f, -0.03f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut201);

            jessieList.Add(rambut201);


            var rambut202 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut202.createTorus(-0.025f, -0.06f, -0.03f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut202);

            jessieList.Add(rambut202);

            var rambut21 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut21.createTorus(0.025f, -0.07f, -0.03f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut21);

            jessieList.Add(rambut21);


            var rambut211 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut211.createTorus(-0.025f, -0.07f, -0.03f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut211);

            jessieList.Add(rambut211);


            //===================================


            var rambut3 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut3.createTorus(0, -0.1f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut3);

            jessieList.Add(rambut3);

            var rambut31 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut31.createTorus(0.025f, -0.1f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut31);

            jessieList.Add(rambut31);


            var rambut32 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut32.createTorus(-0.025f, -0.1f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut32);

            jessieList.Add(rambut32);



            var rambut301 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut301.createTorus(0.025f, -0.08f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut301);

            jessieList.Add(rambut301);


            var rambut302 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut302.createTorus(-0.025f, -0.08f, -0.02f, 0.085f, 0.02f, 100, 100);
            objectList.Add(rambut302);

            jessieList.Add(rambut302);

            //=======================================

            var rambut4 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut4.createTorus(0, -0.13f, -0.01f, 0.08f, 0.02f, 100, 100);
            objectList.Add(rambut4);

            jessieList.Add(rambut4);

            var rambut41 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut41.createTorus(0.02f, -0.13f, -0.01f, 0.075f, 0.02f, 100, 100);
            objectList.Add(rambut41);

            jessieList.Add(rambut41);


            var rambut42 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut42.createTorus(-0.02f, -0.13f, -0.01f, 0.075f, 0.02f, 100, 100);
            objectList.Add(rambut42);

            jessieList.Add(rambut42);

            //=====================================

            var rambut5 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            rambut5.createTorus(0, -0.16f, -0.02f, 0.06f, 0.02f, 100, 100);
            objectList.Add(rambut5);

            jessieList.Add(rambut5);


            //kepang
            var kepang1 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang1.createEllipsoid(0, -0.16f, -0.11f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang1);

            jessieList.Add(kepang1);

            jessieKepangList.Add(kepang1);


            var kepang2 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang2.createEllipsoid(0, -0.188f, -0.12f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang2);

            jessieList.Add(kepang2);

            jessieKepangList.Add(kepang2);



            var kepang3 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang3.createEllipsoid(0, -0.216f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang3);

            jessieList.Add(kepang3);

            jessieKepangList.Add(kepang3);



            var kepang4 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang4.createEllipsoid(0.01f, -0.244f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang4);

            jessieList.Add(kepang4);

            jessieKepangList.Add(kepang4);



            var kepang5 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang5.createEllipsoid(0.02f, -0.272f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang5);

            jessieList.Add(kepang5);

            jessieKepangList.Add(kepang5);



            var kepang6 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang6.createEllipsoid(0.04f, -0.29f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang6);

            jessieList.Add(kepang6);

            jessieKepangList.Add(kepang6);



            var kepang7 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang7.createEllipsoid(0.064f, -0.3f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang7);

            jessieList.Add(kepang7);

            jessieKepangList.Add(kepang7);



            var kepang8 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang8.createEllipsoid(0.09f, -0.305f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang8);

            jessieList.Add(kepang8);
            jessieKepangList.Add(kepang8);




            var kepang9 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang9.createEllipsoid(0.116f, -0.3f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang9);

            jessieList.Add(kepang9);

            jessieKepangList.Add(kepang9);



            var kepang10 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang10.createEllipsoid(0.142f, -0.295f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang10);

            jessieList.Add(kepang10);

            jessieKepangList.Add(kepang10);



            var kepang11 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang11.createEllipsoid(0.168f, -0.285f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang11);

            jessieList.Add(kepang11);

            jessieKepangList.Add(kepang11);



            var kepang12 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang12.createEllipsoid(0.194f, -0.27f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang12);

            jessieList.Add(kepang12);

            jessieKepangList.Add(kepang12);



            var kepang13 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang13.createEllipsoid(0.22f, -0.26f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang13);

            jessieList.Add(kepang13);

            jessieKepangList.Add(kepang13);



            var ikatkepang = new Asset3d(new Vector3(1f, 0.956f, 0.121f));
            ikatkepang.createCylinder(-0.29f, -0.2f, -0.13f, 100, 0.015f, 0.015f);
            ikatkepang.rotate(ikatkepang.objectCenter, Vector3.UnitZ, 100);
            objectList.Add(ikatkepang);

            jessieList.Add(ikatkepang);

            jessieKepangList.Add(ikatkepang);



            var kepang14 = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            kepang14.createEllipsoid(0.257f, -0.245f, -0.13f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(kepang14);

            jessieList.Add(kepang14);

            jessieKepangList.Add(kepang14);



            //Jessie HEAD JAW
            var headJawJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            headJawJes.createEllipsoid(0, -0.09f, 0, 0.13f, 0.12f, 0.1f, 100, 100);
            objectList.Add(headJawJes);

            jessieList.Add(headJawJes);


            //jessie ALIS LEFT
            var alisLJes = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            alisLJes.createRectangle(-0.055f, -0.035f, 0.06f, 0.055f, 0.01f, 0.055f);
            /*     alisL.rotate(alisL.objectCenter, Vector3.UnitZ, -15);*/
            objectList.Add(alisLJes);

            jessieList.Add(alisLJes);


            //jessie ALIS RIGHT
            var alisJes = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            alisJes.createRectangle(0.055f, -0.035f, 0.06f, 0.055f, 0.01f, 0.055f);
            objectList.Add(alisJes);

            jessieList.Add(alisJes);


            //Jessie EYE LEFT
            var eyeLeftJes = new Asset3d(new Vector3(1, 1, 1));
            eyeLeftJes.createEllipsoid(-0.04f, -0.08f, 0.06f, 0.05f, 0.040f, 0.040f, 100, 100);
            objectList.Add(eyeLeftJes);

            jessieList.Add(eyeLeftJes);


            //Jessie EYE RIGHT
            var eyeRightJes = new Asset3d(new Vector3(1, 1, 1));
            eyeRightJes.createEllipsoid(0.04f, -0.08f, 0.06f, 0.05f, 0.040f, 0.040f, 100, 100);
            objectList.Add(eyeRightJes);

            jessieList.Add(eyeRightJes);

            //Jessie EYE LEFT inside
            var eyeLeftIJes = new Asset3d(new Vector3(0.057f, 0.5f, 0.012f));
            eyeLeftIJes.createEllipsoid(-0.04f, -0.077f, 0.082f, 0.020f, 0.020f, 0.020f, 100, 100);
            objectList.Add(eyeLeftIJes);

            jessieList.Add(eyeLeftIJes);


            //Jessie EYE RIGHT inside
            var eyeRightIJes = new Asset3d(new Vector3(0.057f, 0.5f, 0.012f));
            eyeRightIJes.createEllipsoid(0.047f, -0.077f, 0.082f, 0.020f, 0.020f, 0.020f, 100, 100);
            objectList.Add(eyeRightIJes);

            jessieList.Add(eyeRightIJes);


            //Jessie EYE LEFT inside 2
            var eyeLeftIIJes = new Asset3d(new Vector3(0f, 0f, 0f));
            eyeLeftIIJes.createEllipsoid(-0.04f, -0.076f, 0.09f, 0.013f, 0.013f, 0.013f, 100, 100);
            objectList.Add(eyeLeftIIJes);

            jessieList.Add(eyeLeftIIJes);


            //Jessie EYE RIGHT inside 2
            var eyeRightIIJes = new Asset3d(new Vector3(0f, 0f, 0f));
            eyeRightIIJes.createEllipsoid(0.048f, -0.075f, 0.09f, 0.013f, 0.013f, 0.013f, 100, 100);
            objectList.Add(eyeRightIIJes);

            jessieList.Add(eyeRightIIJes);


            //jessie nose
            var noseJes = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            noseJes.createPyramid(0, -0.08f, 0.09f, 0.05f, 0.08f);
            //noseJes.rotate(noseJes.objectCenter, Vector3.UnitY, 180);
            objectList.Add(noseJes);

            jessieList.Add(noseJes);


            //Jessie NECK
            var neckJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            neckJes.createCylinder(0, -0.23f, 0f, 100, 0.05f, 0.05f);
            objectList.Add(neckJes);

            jessieList.Add(neckJes);


            //Jessie HAT
            var hatBottomJes = new Asset3d(new Vector3(0.75f, 0.023f, 0.023f));
            hatBottomJes.createEllipsoid(0, 0, 0, 0.25f, 0.01f, 0.25f, 100, 100);
            objectList.Add(hatBottomJes);

            jessieList.Add(hatBottomJes);


            var hatlineJes = new Asset3d(new Vector3(1f, 1f, 1f));
            hatlineJes.createCylinder(0, 0, 0, 100, 0.101f, 0.03f);
            objectList.Add(hatlineJes);

            jessieList.Add(hatlineJes);


            var hatMiddleJes = new Asset3d(new Vector3(0.75f, 0.023f, 0.023f));
            hatMiddleJes.createCylinder(0, 0, 0, 100, 0.1f, 0.1f);
            objectList.Add(hatMiddleJes);

            jessieList.Add(hatMiddleJes);


            var hatTopJes = new Asset3d(new Vector3(0.9f, 0.023f, 0.023f));
            hatTopJes.createEllipsoid(0, 0.1f, 0, 0.1f, 0, 0.1f, 100, 100);
            objectList.Add(hatTopJes);

            jessieList.Add(hatTopJes);


            //jessie EAR RIGHT
            var earRJes = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            earRJes.createEllipsoid(0.14f, -0.11f, 0f, 0.03f, 0.04f, 0.01f, 100, 100);
            objectList.Add(earRJes);

            jessieList.Add(earRJes);


            //jessie EAR LEFT
            var earLJes = new Asset3d(new Vector3(0.905f, 0.670f, 0.352f));
            earLJes.createEllipsoid(-0.14f, -0.11f, 0f, 0.03f, 0.04f, 0.01f, 100, 100);
            objectList.Add(earLJes);

            jessieList.Add(earLJes);


            //jessie upper body
            var upperbody = new Asset3d(new Vector3(1f, 1f, 1f));
            upperbody.createEllipsoid(0, -0.30f, 0, 0.1f, 0.1f, 0.1f, 100, 100);
            objectList.Add(upperbody);

            jessieList.Add(upperbody);


            //jessie middle body
            var middlebody = new Asset3d(new Vector3(1f, 1f, 1f));
            middlebody.createCylinder(0, -0.475f, 0f, 100, 0.1f, 0.16f);
            objectList.Add(middlebody);

            jessieList.Add(middlebody);


            //jessie belt
            var beltJes = new Asset3d(new Vector3(0.541f, 0.278f, 0.098f));
            beltJes.createTorus(0, -0.475f, 0, 0.085f, 0.02f, 100, 100);
            objectList.Add(beltJes);

            jessieList.Add(beltJes);


            //jessie middle belt
            var beltMJes = new Asset3d(new Vector3(0.964f, 0.905f, 0.352f));
            beltMJes.createEllipsoid(0, -0.475f, 0.1055f, 0.03f, 0.01f, 0f, 100, 100);
            objectList.Add(beltMJes);

            jessieList.Add(beltMJes);


            //Jessie lower body
            var lowerbody = new Asset3d(new Vector3(0.035f, 0.368f, 0.674f));
            lowerbody.createEllipsoid(0, -0.48f, 0, 0.1f, 0.1f, 0.1f, 100, 100);
            objectList.Add(lowerbody);

            jessieList.Add(lowerbody);


            //Jessie LEG LEFT
            var legLJes = new Asset3d(new Vector3(1f, 1f, 1f));
            legLJes.createCylinder(-0.047f, -0.85f, 0f, 100, 0.03f, 0.31f);
            objectList.Add(legLJes);

            jessieList.Add(legLJes);
            jessieLegLeft.Add(legLJes);
            jessLeftLegCylinder = legLJes;

            //Jessie LEG RIGHT
            var legRJes = new Asset3d(new Vector3(1f, 1f, 1f));
            legRJes.createCylinder(0.047f, -0.85f, 0f, 100, 0.03f, 0.31f);
            objectList.Add(legRJes);

            jessieList.Add(legRJes);
            jessieLegRight.Add(legRJes);
            jessRightLegCylinder = legRJes;


            //JESSIE BOOTS UPPER LEFT
            var booUpLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booUpLJes.createCylinder(-0.046f, -0.9f, 0f, 100, 0.035f, 0.05f);
            objectList.Add(booUpLJes);

            jessieList.Add(booUpLJes);
            jessieLegLeft.Add(booUpLJes);


            //JESSIE BOOTS UPPER RIGHT
            var booUpRJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booUpRJes.createCylinder(0.046f, -0.9f, 0f, 100, 0.035f, 0.05f);
            objectList.Add(booUpRJes);

            jessieList.Add(booUpRJes);
            jessieLegRight.Add(booUpRJes);


            //JESSIE BOOTS BOTTOM LEFT
            var booDLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDLJes.createCylinder2(-0.048f, -0.03f, 0.9f, 100, 0.030f, 0.02f, 0.1f);
            booDLJes.rotate(booDLJes.objectCenter, Vector3.UnitX, 90);
            objectList.Add(booDLJes);

            jessieList.Add(booDLJes);
            jessieLegLeft.Add(booDLJes);

            //JESSIE BOOTS BOTTOM RIGHT
            var booRLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booRLJes.createCylinder2(0.048f, -0.03f, 0.9f, 100, 0.030f, 0.02f, 0.1f);
            booRLJes.rotate(booRLJes.objectCenter, Vector3.UnitX, 90);
            objectList.Add(booRLJes);

            jessieList.Add(booRLJes);
            jessieLegRight.Add(booRLJes);




            //JESSIE BOOTS BOTTOM LEFT FRONT
            var booDLFJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDLFJes.createEllipticParaboloid(-0.048f, -0.9f, 0.09f, 0.018f, 0.013f, 0.011f, 100, 100);
            booDLFJes.rotate(booDLFJes.objectCenter, Vector3.UnitX, 180);
            objectList.Add(booDLFJes);

            jessieList.Add(booDLFJes);
            jessieLegLeft.Add(booDLFJes);




            //JESSIE BOOTS BOTTOM RIGHT FRONT
            var booDRFJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            booDRFJes.createEllipticParaboloid(0.048f, -0.9f, 0.09f, 0.018f, 0.013f, 0.011f, 100, 100);
            booDRFJes.rotate(booDRFJes.objectCenter, Vector3.UnitX, 180);
            objectList.Add(booDRFJes);

            jessieList.Add(booDRFJes);
            jessieLegRight.Add(booDRFJes);



            ////jessie BOOTS UPPER LEFT
            //var booUpLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booUpLJes.createCylinder(-0.046f, -0.85f, 0f, 100, 0.035f, 0.03f);
            //objectList.Add(booUpLJes);

            //jessieList.Add(booUpLJes);

            ////jessie BOOTS UPPER RIGHT
            //var booUpRJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booUpRJes.createCylinder(0.046f, -0.8f, 0f, 100, 0.035f, 0.03f);
            //objectList.Add(booUpRJes);

            //jessieList.Add(booUpRJes);


            ////Jessie BOOTS BOTTOM LEFT
            //var booDLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booDLJes.createCylinder2(-0.048f, -0.08f, 0.85f, 100, 0.030f, 0.02f, 0.1f);
            //booDLJes.rotate(booDLJes.objectCenter, Vector3.UnitX, 90);
            //objectList.Add(booDLJes);

            //jessieList.Add(booDLJes);


            ////Jessie BOOTS BOTTOM RIGHT
            //var booRLJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booRLJes.createCylinder2(0.048f, -0.03f, 0.8f, 100, 0.030f, 0.02f, 0.1f);
            //booRLJes.rotate(booRLJes.objectCenter, Vector3.UnitX, 90);
            //objectList.Add(booRLJes);

            //jessieList.Add(booRLJes);


            ////jessie BOOTS BOTTOM LEFT FRONT
            //var booDLFJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booDLFJes.createEllipticParaboloid(-0.048f, -0.83f, 0.08f, 0.02f, 0.02f, 0.01f, 100, 100);
            //booDLFJes.rotate(booDLFJes.objectCenter, Vector3.UnitX, 90);
            //objectList.Add(booDLFJes);

            //jessieList.Add(booDLFJes);


            ////jessie BOOTS BOTTOM right FRONT
            //var booDRFJes = new Asset3d(new Vector3(0.529f, 0.301f, 0.149f));
            //booDRFJes.createEllipticParaboloid(0.048f, -0.78f, 0.08f, 0.02f, 0.02f, 0.01f, 100, 100);
            //booDRFJes.rotate(booDRFJes.objectCenter, Vector3.UnitX, 90);
            //objectList.Add(booDRFJes);

            //jessieList.Add(booDRFJes);

            //jessie HAND LEFT
            var handLJes = new Asset3d(new Vector3(1f, 1f, 1f));
            handLJes.createCylinder(-0.315f, -0.045f, 0f, 100, 0.02f, 0.15f);
            handLJes.rotate(handLJes.objectCenter, Vector3.UnitZ, 65);
            objectList.Add(handLJes);

            jessieList.Add(handLJes);


            //jessie HAND LEFT inside
            var handLI = new Asset3d(new Vector3(1f, 1f, 1f));
            handLI.createCylinder(-0.322f, -0.078f, 0f, 100, 0.02f, 0.15f);
            handLI.rotate(handLI.objectCenter, Vector3.UnitZ, 35);
            objectList.Add(handLI);

            jessieList.Add(handLI);


            //jessie HAND RIGHT
            var handRJes = new Asset3d(new Vector3(1f, 1f, 1f));
            handRJes.createCylinder(0.16f, 0.27f, 0f, 100, 0.02f, 0.15f);
            handRJes.rotate(handRJes.objectCenter, Vector3.UnitZ, 225);
            objectList.Add(handRJes);

            jessieList.Add(handRJes);


            //jessie HAND RIGHT inside
            var handRI = new Asset3d(new Vector3(1f, 1f, 1f));
            handRI.createCylinder(0.16f, 0.35f, 0f, 100, 0.02f, 0.15f);
            handRI.rotate(handRI.objectCenter, Vector3.UnitZ, 225);
            objectList.Add(handRI);

            jessieList.Add(handRI);


            //==================== RIGHT FINGERS =====================

            //jessie PALM RIGHT
            var palmRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            palmRJes.createCylinder2(0.16f, 0.5f, 0f, 100, 0.02f, 0.020f, 0.035f);
            palmRJes.rotate(palmRJes.objectCenter, Vector3.UnitZ, 225);
            objectList.Add(palmRJes);

            jessieList.Add(palmRJes);


            //jessie THUMB RIGHT
            var thumbRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            thumbRJes.createEllipsoid(0.245f, -0.51f, 0, 0.01f, 0.02f, 0.01f, 100, 100);
            thumbRJes.rotate(thumbRJes.objectCenter, Vector3.UnitZ, 10);
            objectList.Add(thumbRJes);

            jessieList.Add(thumbRJes);


            //jessie TELUNJUK RIGHT
            var telRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            telRJes.createEllipsoid(0.285f, -0.485f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            telRJes.rotate(telRJes.objectCenter, Vector3.UnitZ, 50);
            objectList.Add(telRJes);

            jessieList.Add(telRJes);


            //jessie JARI TENGAH RIGHT
            var tenRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            tenRJes.createEllipsoid(0.275f, -0.5f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            tenRJes.rotate(tenRJes.objectCenter, Vector3.UnitZ, 45);
            objectList.Add(tenRJes);

            jessieList.Add(tenRJes);


            //jessie JARI MANIS RIGHT
            var manRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            manRJes.createEllipsoid(0.265f, -0.515f, 0, 0.01f, 0.038f, 0.01f, 100, 100);
            manRJes.rotate(manRJes.objectCenter, Vector3.UnitZ, 40);
            objectList.Add(manRJes);

            jessieList.Add(manRJes);


            //jessie JARI KELINGKING RIGHT
            var kelRJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            kelRJes.createEllipsoid(0.285f, -0.47f, 0, 0.01f, 0.03f, 0.01f, 100, 100);
            kelRJes.rotate(kelRJes.objectCenter, Vector3.UnitZ, 70);
            objectList.Add(kelRJes);

            jessieList.Add(kelRJes);


            //==================== LEFT FINGERS =====================

            //jessie PALM LEFT
            var palmLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            palmLJes.createCylinder2(-0.322f, 0.072f, 0f, 100, 0.02f, 0.020f, 0.035f);
            palmLJes.rotate(palmLJes.objectCenter, Vector3.UnitZ, 35);
            objectList.Add(palmLJes);

            jessieList.Add(palmLJes);


            //jessie THUMB RIGHT
            var thumbLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            thumbLJes.createEllipsoid(-0.307f, -0.07f, 0, 0.01f, 0.02f, 0.01f, 100, 100);
            thumbLJes.rotate(thumbLJes.objectCenter, Vector3.UnitZ, 0);
            objectList.Add(thumbLJes);

            jessieList.Add(thumbLJes);


            //jessie TELUNJUK Left
            var telLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            telLJes.createEllipsoid(-0.325f, -0.065f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            telLJes.rotate(telLJes.objectCenter, Vector3.UnitZ, 30);
            objectList.Add(telLJes);

            jessieList.Add(telLJes);


            //jessie JARI TENGAH Left
            var tenLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            tenLJes.createEllipsoid(-0.34f, -0.075f, 0, 0.01f, 0.04f, 0.01f, 100, 100);
            tenLJes.rotate(tenLJes.objectCenter, Vector3.UnitZ, 35);
            objectList.Add(tenLJes);

            jessieList.Add(tenLJes);


            //jessie JARI MANIS Left
            var manLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            manLJes.createEllipsoid(-0.355f, -0.085f, 0, 0.01f, 0.038f, 0.01f, 100, 100);
            manLJes.rotate(manLJes.objectCenter, Vector3.UnitZ, 40);
            objectList.Add(manLJes);

            jessieList.Add(manLJes);


            //jessie JARI KELINGKING Left
            var kelLJes = new Asset3d(new Vector3(0.937f, 0.741f, 0.478f));
            kelLJes.createEllipsoid(-0.36f, -0.1f, 0, 0.01f, 0.03f, 0.01f, 100, 100);
            kelLJes.rotate(kelLJes.objectCenter, Vector3.UnitZ, 60);
            objectList.Add(kelLJes);

            jessieList.Add(kelLJes);

            //MS POTATO HAT TOP
            var potatoHatT = new Asset3d(new Vector3(1, 1, 1f));
            potatoHatT.createEllipsoid(-0.58f, -0.44f, 0, 0.11f, 0.15f, 0.11f, 100, 100);
            objectList.Add(potatoHatT);
            mspotatoheadList.Add(potatoHatT);

            //MS POTATO HAT
            var potatoHat = new Asset3d(new Vector3(1, 1, 1f));
            potatoHat.createTorus(-0.58f, -0.4f, 0, 0.1f, 0.02f, 100, 100);
            objectList.Add(potatoHat);
            mspotatoheadList.Add(potatoHat);

            //MS POTATO HAT FLOWER MIDDLE
            var potatoHatFM = new Asset3d(new Vector3(0.929f, 0.501f, 0.349f));
            potatoHatFM.createEllipsoid(-0.58f, -0.35f, 0.093f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatFM);
            mspotatoheadList.Add(potatoHatFM);

            //MS POTATO HAT FLOWER Up 1
            var potatoHatUp1 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp1.createEllipsoid(-0.58f, -0.335f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp1);
            mspotatoheadList.Add(potatoHatUp1);

            //MS POTATO HAT FLOWER Up 2
            var potatoHatUp2 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp2.createEllipsoid(-0.595f, -0.342f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp2);
            mspotatoheadList.Add(potatoHatUp2);

            //MS POTATO HAT FLOWER Up 3
            var potatoHatUp3 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp3.createEllipsoid(-0.592f, -0.355f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp3);
            mspotatoheadList.Add(potatoHatUp3);

            //MS POTATO HAT FLOWER Up 4
            var potatoHatUp4 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp4.createEllipsoid(-0.565f, -0.342f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp4);
            mspotatoheadList.Add(potatoHatUp4);

            //MS POTATO HAT FLOWER Up 5
            var potatoHatUp5 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp5.createEllipsoid(-0.568f, -0.355f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp5);
            mspotatoheadList.Add(potatoHatUp5);

            //MS POTATO HAT FLOWER Up 6
            var potatoHatUp6 = new Asset3d(new Vector3(0.984f, 0.905f, 0.858f));
            potatoHatUp6.createEllipsoid(-0.58f, -0.36f, 0.091f, 0.015f, 0.015f, 0.005f, 100, 100);
            objectList.Add(potatoHatUp6);
            mspotatoheadList.Add(potatoHatUp6);

            //MS POTATO EAR LEFT
            var potatoEarL = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            potatoEarL.createEllipsoid(-0.75f, -0.52f, 0f, 0.03f, 0.06f, 0.01f, 100, 100);
            objectList.Add(potatoEarL);
            mspotatoheadList.Add(potatoEarL);

            //MS POTATO EAR RIGHT
            var potatoEarR = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            potatoEarR.createEllipsoid(-0.41f, -0.52f, 0f, 0.03f, 0.06f, 0.01f, 100, 100);
            objectList.Add(potatoEarR);
            mspotatoheadList.Add(potatoEarR);

            //MS POTATO EARING LEFT
            var potatoEaringL = new Asset3d(new Vector3(0.752f, 0.674f, 0.262f));
            potatoEaringL.createEllipsoid(-0.75f, -0.54f, 0.01f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(potatoEaringL);
            mspotatoheadList.Add(potatoEaringL);



            //MS POTATO EARING RIGHT
            var potatoEaringR = new Asset3d(new Vector3(0.752f, 0.674f, 0.262f));
            potatoEaringR.createEllipsoid(-0.41f, -0.54f, 0.01f, 0.015f, 0.015f, 0.015f, 100, 100);
            objectList.Add(potatoEaringR);
            mspotatoheadList.Add(potatoEaringR);


            //MS POTATO HAND RIGHT
            var potatoHandR = new Asset3d(new Vector3(1, 1, 1f));
            potatoHandR.createCylinder2(-0.7f, -0.5f, 0f, 100, 0.01f, 0.01f, 0.15f);
            potatoHandR.rotate(potatoHandR.objectCenter, Vector3.UnitZ, 30);
            objectList.Add(potatoHandR);
            mspotatoheadList.Add(potatoHandR);

            //MS POTATO HAND RIGHT 2
            var potatoHandR2 = new Asset3d(new Vector3(1, 1, 1f));
            potatoHandR2.createCylinder2(0.217f, 0.73f, 0f, 100, 0.01f, 0.01f, 0.1f);
            potatoHandR2.rotate(potatoHandR2.objectCenter, Vector3.UnitZ, 170);
            objectList.Add(potatoHandR2);
            mspotatoheadList.Add(potatoHandR2);

            //ms potato fingers right
            var potatoFR = new Asset3d(new Vector3(1, 1, 1f));
            potatoFR.createEllipsoid(-0.34f, -0.68f, 0.01f, 0.05f, 0.03f, 0.03f, 100, 100);
            potatoFR.rotate(potatoFR.objectCenter, Vector3.UnitZ, 170);
            objectList.Add(potatoFR);
            mspotatoheadList.Add(potatoFR);

            //MS POTATO HAND left
            var potatoHandL = new Asset3d(new Vector3(1, 1, 1f));
            potatoHandL.createCylinder2(0.3f, 0.94f, 0f, 100, 0.01f, 0.01f, 0.15f);
            potatoHandL.rotate(potatoHandL.objectCenter, Vector3.UnitZ, 150);
            objectList.Add(potatoHandL);
            mspotatoheadList.Add(potatoHandL);

            //MS POTATO HAND left 2
            var potatoHandL2 = new Asset3d(new Vector3(1, 1, 1f));
            potatoHandL2.createCylinder2(1.028f, 0.37f, 0f, 100, 0.01f, 0.01f, 0.1f);
            potatoHandL2.rotate(potatoHandL2.objectCenter, Vector3.UnitZ, 200);
            objectList.Add(potatoHandL2);
            mspotatoheadList.Add(potatoHandL2);

            //ms potato fingers left
            var potatoFL = new Asset3d(new Vector3(1, 1, 1f));
            potatoFL.createEllipsoid(-0.85f, -0.675f, 0.01f, 0.05f, 0.03f, 0.03f, 100, 100);
            potatoFL.rotate(potatoFL.objectCenter, Vector3.UnitZ, 200);
            objectList.Add(potatoFL);
            mspotatoheadList.Add(potatoFL);



            //MS POTATO HEAD
            var potatoHead = new Asset3d(new Vector3(0.843f, 0.466f, 0.309f));
            potatoHead.createEllipsoid(-0.58f, -0.55f, 0, 0.15f, 0.2f, 0.15f, 100, 100);
            objectList.Add(potatoHead);
            mspotatoheadList.Add(potatoHead);


            //MS POTATO HEAD BOTTOM
            var potatoHeadB = new Asset3d(new Vector3(0.843f, 0.466f, 0.309f));
            potatoHeadB.createEllipsoid(-0.58f, -0.65f, 0, 0.17f, 0.2f, 0.17f, 100, 100);
            objectList.Add(potatoHeadB);
            mspotatoheadList.Add(potatoHeadB);

            //EYES LEFT
            var potatoHeadEyeL = new Asset3d(new Vector3(1, 1, 1));
            potatoHeadEyeL.createEllipsoid(-0.6f, -0.50f, 0.14f, 0.03f, 0.05f, 0.03f, 100, 100);
            objectList.Add(potatoHeadEyeL);
            mspotatoheadList.Add(potatoHeadEyeL);

            //EYES LEFT INSIDE
            var potatoHeadEyeLI = new Asset3d(new Vector3(0, 0, 0));
            potatoHeadEyeLI.createEllipsoid(-0.6f, -0.48f, 0.165f, 0.013f, 0.018f, 0.008f, 100, 100);
            objectList.Add(potatoHeadEyeLI);
            mspotatoheadList.Add(potatoHeadEyeLI);

            //EYES RIGHT
            var potatoHeadEyeR = new Asset3d(new Vector3(1, 1, 1));
            potatoHeadEyeR.createEllipsoid(-0.51f, -0.50f, 0.14f, 0.03f, 0.05f, 0.03f, 100, 100);
            objectList.Add(potatoHeadEyeR);
            mspotatoheadList.Add(potatoHeadEyeR);
            //EYES RIGHT INSIDE
            var potatoHeadEyeRI = new Asset3d(new Vector3(0, 0, 0));
            potatoHeadEyeRI.createEllipsoid(-0.512f, -0.48f, 0.165f, 0.013f, 0.018f, 0.008f, 100, 100);
            objectList.Add(potatoHeadEyeRI);
            mspotatoheadList.Add(potatoHeadEyeRI);

            //MS POTATO NOSE TOP
            var potatoNoseT = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            potatoNoseT.createEllipsoid(-0.561f, -0.583f, 0.15f, 0.02f, 0.03f, 0.02f, 100, 100);
            objectList.Add(potatoNoseT);
            mspotatoheadList.Add(potatoNoseT);

            //MS POTATO NOSE
            var potatoNose = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            potatoNose.createEllipsoid(-0.56f, -0.6f, 0.15f, 0.03f, 0.02f, 0.03f, 100, 100);
            objectList.Add(potatoNose);
            mspotatoheadList.Add(potatoNose);

            //MS POTATO LIPS
            var potatolips = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            potatolips.createTorus(-0.56f, -0.7f, 0.15f, 0.03f, 0.03f, 100, 100);
            objectList.Add(potatolips);
            mspotatoheadList.Add(potatolips);

            //LEG LEFT
            var potatoLegL = new Asset3d(new Vector3(0.713f, 0.086f, 0.164f));
            potatoLegL.createEllipticParaboloid(-0.5f, -0.8f, 0, 0.05f, 0.1f, 0.05f, 100, 100);
            potatoLegL.rotate(potatoLegL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(potatoLegL);
            mspotatoheadList.Add(potatoLegL);

            //LEG RIGHT
            var potatoLegR = new Asset3d(new Vector3(0.713f, 0.086f, 0.164f));
            potatoLegR.createEllipticParaboloid(-0.65f, -0.8f, 0, 0.05f, 0.1f, 0.05f, 100, 100);
            potatoLegR.rotate(potatoLegL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(potatoLegR);
            mspotatoheadList.Add(potatoLegR);


            //MRS POTATO HAT TOP
            var mrpotatoHatT = new Asset3d(new Vector3(0,0,0f));
            mrpotatoHatT.createEllipsoid(-0.58f, -0.44f, 0, 0.11f, 0.15f, 0.11f, 100, 100);
            objectList.Add(mrpotatoHatT);
            mrspotatoheadList.Add(mrpotatoHatT);

            //MS POTATO HAT
            var mrpotatoHat = new Asset3d(new Vector3(0,0,0f));
            mrpotatoHat.createTorus(-0.58f, -0.4f, 0, 0.1f, 0.02f, 100, 100);
            objectList.Add(mrpotatoHat);
            mrspotatoheadList.Add(mrpotatoHat);

  

            //MS POTATO EAR LEFT
            var mrpotatoEarL = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            mrpotatoEarL.createEllipsoid(-0.75f, -0.52f, 0f, 0.03f, 0.06f, 0.01f, 100, 100);
            objectList.Add(mrpotatoEarL);
            mrspotatoheadList.Add(mrpotatoEarL);

            //MS POTATO EAR RIGHT
            var mrpotatoEarR = new Asset3d(new Vector3(0.929f, 0.470f, 0.627f));
            mrpotatoEarR.createEllipsoid(-0.41f, -0.52f, 0f, 0.03f, 0.06f, 0.01f, 100, 100);
            objectList.Add(mrpotatoEarR);
            mrspotatoheadList.Add(mrpotatoEarR);

            //MS POTATO HAND RIGHT
            var mrpotatoHandR = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoHandR.createCylinder2(-0.7f, -0.5f, 0f, 100, 0.01f, 0.01f, 0.15f);
            mrpotatoHandR.rotate(mrpotatoHandR.objectCenter, Vector3.UnitZ, 30);
            objectList.Add(mrpotatoHandR);
            mrspotatoheadList.Add(mrpotatoHandR);

            //MS POTATO HAND RIGHT 2
            var mrpotatoHandR2 = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoHandR2.createCylinder2(0.217f, 0.73f, 0f, 100, 0.01f, 0.01f, 0.1f);
            mrpotatoHandR2.rotate(mrpotatoHandR2.objectCenter, Vector3.UnitZ, 170);
            objectList.Add(mrpotatoHandR2);
            mrspotatoheadList.Add(mrpotatoHandR2);


            //ms potato fingers right
            var mrpotatoFR = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoFR.createEllipsoid(-0.34f, -0.68f, 0.01f, 0.05f, 0.03f, 0.03f, 100, 100);
            mrpotatoFR.rotate(mrpotatoFR.objectCenter, Vector3.UnitZ, 170);
            objectList.Add(mrpotatoFR);
            mrspotatoheadList.Add(mrpotatoFR);

            //MS POTATO HAND left
            var mrpotatoHandL = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoHandL.createCylinder2(0.3f, 0.94f, 0f, 100, 0.01f, 0.01f, 0.15f);
            mrpotatoHandL.rotate(mrpotatoHandL.objectCenter, Vector3.UnitZ, 150);
            objectList.Add(mrpotatoHandL);
            mrspotatoheadList.Add(mrpotatoHandL);

            //MS POTATO HAND left 2
            var mrpotatoHandL2 = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoHandL2.createCylinder2(1.028f, 0.37f, 0f, 100, 0.01f, 0.01f, 0.1f);
            mrpotatoHandL2.rotate(mrpotatoHandL2.objectCenter, Vector3.UnitZ, 200);
            objectList.Add(mrpotatoHandL2);
            mrspotatoheadList.Add(mrpotatoHandL2);

            //ms potato fingers left
            var mrpotatoFL = new Asset3d(new Vector3(1, 1, 1f));
            mrpotatoFL.createEllipsoid(-0.85f, -0.675f, 0.01f, 0.05f, 0.03f, 0.03f, 100, 100);
            mrpotatoFL.rotate(mrpotatoFL.objectCenter, Vector3.UnitZ, 200);
            objectList.Add(mrpotatoFL);
            mrspotatoheadList.Add(mrpotatoFL);



            //MS POTATO HEAD
            var mrpotatoHead = new Asset3d(new Vector3(0.843f, 0.466f, 0.309f));
            mrpotatoHead.createEllipsoid(-0.58f, -0.55f, 0, 0.15f, 0.2f, 0.15f, 100, 100);
            objectList.Add(mrpotatoHead);
            mrspotatoheadList.Add(mrpotatoHead);


            //MS POTATO HEAD BOTTOM
            var mrpotatoHeadB = new Asset3d(new Vector3(0.843f, 0.466f, 0.309f));
            mrpotatoHeadB.createEllipsoid(-0.58f, -0.65f, 0, 0.17f, 0.2f, 0.17f, 100, 100);
            objectList.Add(mrpotatoHeadB);
            mrspotatoheadList.Add(mrpotatoHeadB);

            //EYES LEFT
            var mrpotatoHeadEyeL = new Asset3d(new Vector3(1, 1, 1));
            mrpotatoHeadEyeL.createEllipsoid(-0.6f, -0.50f, 0.14f, 0.03f, 0.05f, 0.03f, 100, 100);
            objectList.Add(mrpotatoHeadEyeL);
            mrspotatoheadList.Add(mrpotatoHeadEyeL);

            //EYES LEFT INSIDE
            var mrpotatoHeadEyeLI = new Asset3d(new Vector3(0, 0, 0));
            mrpotatoHeadEyeLI.createEllipsoid(-0.6f, -0.48f, 0.165f, 0.013f, 0.018f, 0.008f, 100, 100);
            objectList.Add(mrpotatoHeadEyeLI);
            mrspotatoheadList.Add(mrpotatoHeadEyeLI);

            //EYES RIGHT
            var mrpotatoHeadEyeR = new Asset3d(new Vector3(1, 1, 1));
            mrpotatoHeadEyeR.createEllipsoid(-0.51f, -0.50f, 0.14f, 0.03f, 0.05f, 0.03f, 100, 100);
            objectList.Add(mrpotatoHeadEyeR);
            mrspotatoheadList.Add(mrpotatoHeadEyeR);
            //EYES RIGHT INSIDE
            var mrpotatoHeadEyeRI = new Asset3d(new Vector3(0, 0, 0));
            mrpotatoHeadEyeRI.createEllipsoid(-0.512f, -0.48f, 0.165f, 0.013f, 0.018f, 0.008f, 100, 100);
            objectList.Add(mrpotatoHeadEyeRI);
            mrspotatoheadList.Add(mrpotatoHeadEyeRI);
            //MS POTATO NOSE TOP
            var mrpotatoNoseT = new Asset3d(new Vector3(0.972f, 0.662f, 0.290f));
            mrpotatoNoseT.createEllipsoid(-0.561f, -0.583f, 0.15f, 0.02f, 0.03f, 0.02f, 100, 100);
            objectList.Add(mrpotatoNoseT);
            mrspotatoheadList.Add(mrpotatoNoseT);
            //MS POTATO NOSE
            var mrpotatoNose = new Asset3d(new Vector3(0.972f, 0.662f, 0.290f));
            mrpotatoNose.createEllipsoid(-0.56f, -0.6f, 0.15f, 0.03f, 0.02f, 0.03f, 100, 100);
            objectList.Add(mrpotatoNose);
            mrspotatoheadList.Add(mrpotatoNose);

            var mrpotatomustache = new Asset3d(new Vector3(0,0,0f));
            /*mrpotatomustache.createEllipticParaboloid(-0.56f, -0.6f, 0.15f, 0.07f, 0.05f, 0.07f, 100, 100);*/
            mrpotatomustache.createEllipticParaboloid(-0.56f, -0.62f, 0.165f, 0.04f, 0.01f, 0.02f, 100, 100);
            mrpotatomustache.rotate(mrpotatomustache.objectCenter, Vector3.UnitX, 90);
            objectList.Add(mrpotatomustache);
            mrspotatoheadList.Add(mrpotatomustache);
 
            //MS POTATO LIPS
            var mrpotatolips = new Asset3d(new Vector3(0.95f, 0.023f, 0.023f));
            mrpotatolips.createTorus(-0.56f, -0.7f, 0.15f, 0.03f, 0.03f, 100, 100);
            objectList.Add(mrpotatolips);
            mrspotatoheadList.Add(mrpotatolips);

            //LEG LEFT
            var mrpotatoLegL = new Asset3d(new Vector3(0.074f, 0.372f, 0.627f));
            mrpotatoLegL.createEllipticParaboloid(-0.5f, -0.8f, 0, 0.05f, 0.1f, 0.05f, 100, 100);
            mrpotatoLegL.rotate(mrpotatoLegL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(mrpotatoLegL);
            mrspotatoheadList.Add(mrpotatoLegL);

            //LEG RIGHT
            var mrpotatoLegR = new Asset3d(new Vector3(0.074f, 0.372f, 0.627f));
            mrpotatoLegR.createEllipticParaboloid(-0.65f, -0.8f, 0, 0.05f, 0.1f, 0.05f, 100, 100);
            mrpotatoLegR.rotate(mrpotatoLegL.objectCenter, Vector3.UnitX, 90);
            objectList.Add(mrpotatoLegR);
            mrspotatoheadList.Add(mrpotatoLegR);

            //door
            var doorTop = new Asset3d(new Vector3(0.823f, 0.8f, 0.733f));
            doorTop.createRectangle(0, 4f, 5.19f, 2.8f, 0.2f, 0.05f);
            objectList.Add(doorTop);

            var door = new Asset3d(new Vector3(0.682f, 0.670f, 0.635f));
            door.createRectangle(-0f, 1.5f, 5.2f, 2.4f, 5f, 0.05f);
            objectList.Add(door);

            var doorI = new Asset3d(new Vector3(0.870f, 0.870f, 0.874f));
            doorI.createRectangle(-0f, 1.3f, 5.15f, 2.2f, 4.6f, 0.05f);
            objectList.Add(doorI);

            var doorIA = new Asset3d(new Vector3(0.741f, 0.741f, 0.737f));
            doorIA.createRectangle(-0f, 2.7f, 5.13f, 2f, 1.3f, 0.05f);
            objectList.Add(doorIA);

            var doorIB = new Asset3d(new Vector3(0.741f, 0.741f, 0.737f));
            doorIB.createRectangle(-0f, 1.3f, 5.13f, 2f, 1.3f, 0.05f);
            objectList.Add(doorIB);

            var doorIC = new Asset3d(new Vector3(0.741f, 0.741f, 0.737f));
            doorIC.createRectangle(-0f, -0.1f, 5.13f, 2f, 1.3f, 0.05f);
            objectList.Add(doorIC);

            var doorHandle = new Asset3d(new Vector3(0.490f, 0.392f, 0.247f));
            doorHandle.createEllipsoid(-0.8f, 1.3f, 5.12f, 0.1f, 0.1f, 0.1f, 100, 100);
            objectList.Add(doorHandle);

            //BOLA CEK
            //var bola = new Asset3d(new Vector3(1, 0, 0));
            //bola.createEllipsoid(0.2225f, -0.341f, 0, 0.02f, 0.02f, 0.02f, 100, 100);
            //objectList.Add(bola);

            //var bola2 = new Asset3d(new Vector3(1, 1, 1));
            //bola2.createEllipsoid(1, -0.175f, -0.096f, 0.001f, 0.001f, 0.001f, 100, 100);
            //objectList.Add(bola2);

            foreach (Asset3d i in jessieList)
            {
                i.translate(1, -0.021f, 0);
                //0, -0.09f, 0
            }

            //foreach (Asset3d i in jessieKepangList)
            //{
            //    i.translate(0, 0, 0.01f);
            //}

            foreach (Asset3d i in woodyList)
            {
                i.translate(0, -0.021f, 0);
            }

            foreach (Asset3d i in mrspotatoheadList)
            {
                i.translate(-0.65f, 0, 0);
            }


            foreach (Asset3d i in windowList)
            {
                i.translate(-1.3f, 0, 0);
                i.rotate(Vector3.Zero, Vector3.UnitY, -90);

            }

            foreach (Asset3d i in drawingList)
            {
                i.rotate(Vector3.Zero, Vector3.UnitY, -10);

            }

            foreach (Asset3d i in boxList)
            {
                i.rotate(Vector3.Zero, Vector3.UnitY, 10);

            }


            foreach (Asset3d i in objectList)
            {
                i.load(Size.X, Size.Y);
            }
            /* foreach (Asset2d i in objectList2d)
             {
                 i.load(Size.X, Size.Y);
             }
 */
           
            var object1 = new Asset3d(
            new float[1080],
            new uint[] { }, new Vector3(0,0,0)
            );
            objectList2dWoody.Add(object1);
            var object2 = new Asset3d(
                new float[] { },
                new uint[] { }, new Vector3(0,0,0)
            );
            objectList2dWoody.Add(object2);
            objectList2dWoody[0].loadCurve(Size.X,Size.Y);
            objectList2dWoody[1].loadCurve(Size.X, Size.Y);


            objectList2dWoody[0].updateMousePosition(-0.05f, -0.2f, 0.08f);


            objectList2dWoody[0].updateMousePosition(0f, -0.25f, 0.084f);
            

            objectList2dWoody[0].updateMousePosition(0.05f, -0.2f, 0.08f);


            var object3 = new Asset3d(
           new float[1080],
           new uint[] { }, new Vector3(0, 0, 0)
           );
            objectList2dJessie.Add(object3);
            var object4 = new Asset3d(
                new float[] { },
                new uint[] { }, new Vector3(0, 0, 0)
            );
            objectList2dJessie.Add(object4);
            objectList2dJessie[0].loadCurve(Size.X, Size.Y);
            objectList2dJessie[1].loadCurve(Size.X, Size.Y);


            objectList2dJessie[0].updateMousePosition(-0.05f, -0.2f, 0.08f);


            objectList2dJessie[0].updateMousePosition(0f, -0.25f, 0.084f);


            objectList2dJessie[0].updateMousePosition(0.05f, -0.2f, 0.08f);
            objectList2dJessie[1].translate(1, 0.05f, 0.005f);


/*
            var bigTableDrawingR = new Asset3d(new Vector3(0, 0, 0f));
            bigTableDrawingR.createEllipsoid(4.5f, 1.14f, -0.1f, 0.03f, 0f, 0.03f, 100, 100);
            objectList.Add(bigTableDrawingR);*/

            var object5 = new Asset3d(
            new float[1080],
            new uint[] { }, new Vector3(0, 0, 0)
            );
            objectcurveDraw.Add(object5);
            var object6 = new Asset3d(
                new float[] { },
                new uint[] { }, new Vector3(0, 0, 0)
            );
            objectcurveDraw.Add(object6);
            objectcurveDraw[0].loadCurve(Size.X, Size.Y);
            objectcurveDraw[1].loadCurve(Size.X, Size.Y);


            objectcurveDraw[0].updateMousePosition(4.55f, 1.14f, 0.1f);


            objectcurveDraw[0].updateMousePosition(4.75f, 1.14f, 0f);


            objectcurveDraw[0].updateMousePosition(4.55f, 1.14f, -0.1f);
            foreach (Asset3d i in objectcurveDraw)
            {
                i.rotate(Vector3.Zero, Vector3.UnitY, -10);

            }



            _camera = new Camera(new Vector3(0, 0, 1), Size.X / Size.Y); //kemungkinan error
            CursorGrabbed = true;
            GL.Enable(EnableCap.DepthTest);




        }


        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            float time = (float)args.Time;

         



            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // DepthBufferBit juga harus di clear karena kita memakai depth testing.

         

            foreach (Asset3d i in objectList)
            {
                i.render(_camera.GetViewMatrix(), _camera.GetProjectionMatrix());
                /*i.rotate(Vector3.Zero, Vector3.UnitY, 95 * time);
                foreach (Asset3d j in i.child)
                {
                    j.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
                }*/
            }


            //foreach (Asset2d i in objectList2d)
            //{
            //    i.render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            //    /*i.rotate(Vector3.Zero, Vector3.UnitY, 95 * time);
            //    foreach (Asset3d j in i.child)
            //    {
            //        j.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
            //    }*/
            //}

            if (objectList2dWoody[0].getVerticesLength())
            {
                List<float> _verticesTemp = objectList2dWoody[0].createCurveBezier();
                objectList2dWoody[1].setVertices(_verticesTemp.ToArray());
                objectList2dWoody[1].loadCurve(Size.X, Size.Y);
                objectList2dWoody[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            objectList2dJessie[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (objectList2dJessie[0].getVerticesLength())
            {
                List<float> _verticesTemp = objectList2dJessie[0].createCurveBezier();
                objectList2dJessie[1].setVertices(_verticesTemp.ToArray());
                objectList2dJessie[1].loadCurve(Size.X, Size.Y);
                objectList2dJessie[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            objectList2dJessie[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (objectcurveDraw[0].getVerticesLength())
            {
                List<float> _verticesTemp = objectcurveDraw[0].createCurveBezier();
                objectcurveDraw[1].setVertices(_verticesTemp.ToArray());
                objectcurveDraw[1].loadCurve(Size.X, Size.Y);
                objectcurveDraw[1].render(3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            objectcurveDraw[0].render(2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            Console.WriteLine("ini resize");
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

       /* float MinusTime = ;*/
        float woodyByeTime = 0;
        float jessieKepangTime = 0;
        float jessieJumpTime = 0;
        int woodyTotalTime = 0;
        int potatoTime = 0;
        Vector3 jessieKepangCoor = new Vector3(1, -0.175f, -0.096f);

        float mul = 2.5f;
        

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            // This gets called every 1/60 of a second.
            base.OnUpdateFrame(args);
            float time = (float)args.Time;
            var input = KeyboardState;
            var mouse_input = MouseState;

            potatoTime++;


            foreach (Asset3d i in mrspotatoheadList)
            {
                if (potatoTime <= 90)
                {
                    i.rotate(new Vector3(-1.23f, -0.55f, 0), Vector3.UnitY, 1f);

                }
                else if (potatoTime >= 150 && potatoTime < 240)
                {
                    i.rotate(new Vector3(-1.23f, -0.55f, 0), Vector3.UnitY, -1f);

                }
                else if (potatoTime >= 245)
                {
                    potatoTime = 0;
                }
            }

            foreach (Asset3d i in mspotatoheadList)
            {
                if (potatoTime <= 90)
                {
                    i.rotate(new Vector3(-0.58f, -0.55f, 0), Vector3.UnitY, -1f);

                }
                else if (potatoTime >= 150 && potatoTime < 240)
                {
                    i.rotate(new Vector3(-0.58f, -0.55f, 0), Vector3.UnitY, 1f);

                }
            }




            //woody bye bye animation
            if (woodyTotalTime < 800f / mul)
            {
                woodyByeTime++;

                foreach (Asset3d i in woodyArmHandList)
                {
                    if (woodyByeTime <= 200 / mul)
                    {
                        i.rotate(new Vector3(0.2225f, -0.341f, 0), Vector3.UnitZ, 0.2f * mul);


                    }
                    else
                    {
                        if (woodyByeTime >= (int)(401 / mul) + 1)
                        {
                            woodyByeTime = 1;

                            i.rotate(new Vector3(0.2225f, -0.341f, 0), Vector3.UnitZ, 0.2f * mul);
                        }
                        else
                        {

                            i.rotate(new Vector3(0.2225f, -0.341f, 0), Vector3.UnitZ, -0.2f * mul);
                        }

                    }
                }
            }

            woodyTotalTime++;


            foreach (Asset3d i in woodyHandRList)
            {
                if (woodyTotalTime >= 1700 / mul && woodyTotalTime < 1710 / mul)
                {
                    i.rotate(new Vector3(0.12f, -0.32f, 0f), Vector3.UnitZ, 3.75f * mul);
                }
                else if (woodyTotalTime >= 1930 / mul && woodyTotalTime < 1940 / mul)
                {
                    i.rotate(new Vector3(0.12f, -0.32f, 0f), Vector3.UnitZ, -3.75f * mul);
                }
            }

            foreach (Asset3d i in woodyHatList)
            {
                if (woodyTotalTime >= 1700 / mul && woodyTotalTime < 1710 / mul)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitZ, -0.5f * mul);
                }
                else if (woodyTotalTime >= 1930 / mul && woodyTotalTime < 1940 / mul)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitZ, 0.5f * mul);
                }
            }



            foreach (Asset3d i in woodyList)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 1600 / mul)
                {
                    i.translate(0, 0, 0.001f * mul);

                }

                else if (woodyTotalTime >= 2400 / mul && woodyTotalTime < 2490 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0.8f), Vector3.UnitY, 1 * mul);
                }
                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2950 / mul)
                {
                    i.translate(0.001f * mul, 0, 0f);
                }

                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3700 / mul)
                {
                    i.translate(-0.001f * mul, 0, 0f);
                }
                else if (woodyTotalTime >= 3700 / mul && woodyTotalTime < 3790 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0.8f), Vector3.UnitY, 1 * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 4600 / mul)
                {
                    i.translate(0, 0, -0.001f * mul);

                }
                else if (woodyTotalTime >= 4610 / mul && woodyTotalTime < 4790 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0f), Vector3.UnitY, -1 * mul);

                }
                else if (woodyTotalTime >= 4794 / mul)
                {
                    woodyTotalTime = 0;

                }






            }

            foreach (Asset3d i in woodyLegLeft)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 912 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 912 / mul && woodyTotalTime < 1024 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1024 / mul && woodyTotalTime < 1136 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1136 / mul && woodyTotalTime < 1248 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1248 / mul && woodyTotalTime < 1360 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                    /* i.translate(0,0.01f,0);*/
                }
                else if (woodyTotalTime >= 1360 / mul && woodyTotalTime < 1472 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2812 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitZ, 0.05f * mul);
                }
                else if (woodyTotalTime >= 2812 / mul && woodyTotalTime < 2924 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitZ, -0.05f * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 3912 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3912 / mul && woodyTotalTime < 4024 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4024 / mul && woodyTotalTime < 4136 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4136 / mul && woodyTotalTime < 4248 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4248 / mul && woodyTotalTime < 4360 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                    /* i.translate(0,0.01f,0);*/
                }
                else if (woodyTotalTime >= 4360 / mul && woodyTotalTime < 4472 / mul)
                {
                    i.rotate(new Vector3(woodyLeftLegCylinder.objectCenter.X, woodyLeftLegCylinder.objectCenter.Y, woodyLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }

            }

            foreach (Asset3d i in woodyLegRight)
            {
                if (woodyTotalTime >= 912 / mul && woodyTotalTime < 1024 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1024 / mul && woodyTotalTime < 1136 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1136 / mul && woodyTotalTime < 1248 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1248 / mul && woodyTotalTime < 1360 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1360 / mul && woodyTotalTime < 1472 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1472 / mul && woodyTotalTime < 1584 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3562 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitZ, -0.05f * mul);
                }
                else if (woodyTotalTime >= 3562 / mul && woodyTotalTime < 3674 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitZ, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3912 / mul && woodyTotalTime < 4024 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4024 / mul && woodyTotalTime < 4136 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4136 / mul && woodyTotalTime < 4248 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4248 / mul && woodyTotalTime < 4360 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4360 / mul && woodyTotalTime < 4472 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4472 / mul && woodyTotalTime < 4584 / mul)
                {
                    i.rotate(new Vector3(woodyRightLegCylinder.objectCenter.X, woodyRightLegCylinder.objectCenter.Y, woodyRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }


            }

            foreach (Asset3d i in objectList2dWoody)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 1600 / mul)
                {
                    i.translate(0, 0, 0.001f * mul);

                }

                else if (woodyTotalTime >= 2400 / mul && woodyTotalTime < 2490 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0.8f), Vector3.UnitY, 1 * mul);
                }
                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2950 / mul)
                {
                    i.translate(0.001f * mul, 0, 0f);
                }

                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3700 / mul)
                {
                    i.translate(-0.001f * mul, 0, 0f);
                }
                else if (woodyTotalTime >= 3700 / mul && woodyTotalTime < 3790 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0.8f), Vector3.UnitY, 1 * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 4600 / mul)
                {
                    i.translate(0, 0, -0.001f * mul);

                }
                else if (woodyTotalTime >= 4610 / mul && woodyTotalTime < 4790 / mul)
                {
                    i.rotate(new Vector3(0, 0, 0f), Vector3.UnitY, -1 * mul);

                }
                else if (woodyTotalTime >= 4794 / mul && woodyTotalTime < 4795 / mul)
                {
                    woodyTotalTime = 0;

                }






            }



            /*    foreach (Asset3d i in woodyAr)
                {
                    if (woodyTotalTime >= 1700 && woodyTotalTime < 1710)
                    {
                        i.rotate(Vector3.Zero, Vector3.UnitZ, -0.5f);
                    }
                    else if (woodyTotalTime >= 1930 && woodyTotalTime < 1940)
                    {
                        i.rotate(Vector3.Zero, Vector3.UnitZ, 0.5f);
                    }
                }*/

            /*     foreach (Asset3d i in woodyArmHandList)
                 {
                     if (woodyTotalTime >= 800 && woodyTotalTime < 900)
                     {
                         i.translate(0.001f, 0, 0);

                     }
                     else if (woodyTotalTime >= 900)
                     {
                         if (woodyTotalTime > 1000)
                         {
                             woodyTotalTime = 0;
                             Console.WriteLine("here");


                         }
                         else
                         {
                             i.translate(-0.001f, 0, 0);

                         }

                     }
                 }
     */


            //jessie kepang animation

            jessieKepangTime++;


            //foreach (Asset3d i in jessieKepangList)
            //{
            //    if (jessieKepangTime <= 150)
            //    {
            //        i.rotate(jessieKepangCoor, Vector3.UnitX, 0.2f);
            //    }
            //    else
            //    {
            //        if (jessieKepangTime >= 301)
            //        {
            //            jessieKepangTime = 1;
            //            i.rotate(jessieKepangCoor, Vector3.UnitX, 0.2f);

            //        }
            //        else
            //        {
            //            i.rotate(jessieKepangCoor, Vector3.UnitX, -0.2f);

            //        }

            //    }
            //}

            //jessie jumping animation
            jessieJumpTime++;

            if (woodyTotalTime < 800 / mul)
            {



                foreach (Asset3d i in objectList2dJessie)
                {

                    if (jessieJumpTime <= 100 / mul)
                    {
                        i.translate(0, 0.003f * mul, 0);
                        //jessieKepangCoor.X += 0.005f;
                    }
                    else
                    {
                        if (jessieJumpTime >= (int)(201 / mul) + 1)
                        {
                            jessieJumpTime = 1;
                            i.translate(0, 0.003f * mul, 0);
                            //jessieKepangCoor.X += 0.005f;

                        }
                        else
                        {
                            i.translate(0, -0.003f * mul, 0);
                            //jessieKepangCoor.X -= 0.005f;

                        }

                    }

                }
            }

            if (woodyTotalTime < 800 / mul)
            {



                foreach (Asset3d i in jessieList)
                {

                    if (jessieJumpTime <= 100 / mul)
                    {
                        i.translate(0, 0.003f * mul, 0);
                        //jessieKepangCoor.X += 0.005f;
                    }
                    else
                    {
                        if (jessieJumpTime >= (int)(201 / mul) + 1)
                        {
                            jessieJumpTime = 1;
                            i.translate(0, 0.003f * mul, 0);
                            //jessieKepangCoor.X += 0.005f;

                        }
                        else
                        {
                            i.translate(0, -0.003f * mul, 0);
                            //jessieKepangCoor.X -= 0.005f;

                        }

                    }

                }
            }
            foreach (Asset3d i in jessieList)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 1600 / mul)
                {
                    i.translate(0, 0, 0.001f * mul);

                }

                else if (woodyTotalTime >= 2400 / mul && woodyTotalTime < 2490 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0.8f), Vector3.UnitY, -1 * mul);
                }

                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2950 / mul)
                {
                    i.translate(-0.001f * mul, 0, 0f);
                }

                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3700 / mul)
                {
                    i.translate(0.001f * mul, 0, 0f);
                }
                else if (woodyTotalTime >= 3700 / mul && woodyTotalTime < 3790 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0.8f), Vector3.UnitY, -1 * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 4600 / mul)
                {
                    i.translate(0, 0, -0.001f * mul);

                }
                else if (woodyTotalTime >= 4610 / mul && woodyTotalTime < 4790 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0f), Vector3.UnitY, 1 * mul);
                }



            }
            foreach (Asset3d i in objectList2dJessie)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 1600 / mul)
                {
                    i.translate(0, 0, 0.001f * mul);

                }

                else if (woodyTotalTime >= 2400 / mul && woodyTotalTime < 2490 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0.8f), Vector3.UnitY, -1 * mul);
                }

                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2950 / mul)
                {
                    i.translate(-0.001f * mul, 0, 0f);
                }

                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3700 / mul)
                {
                    i.translate(0.001f * mul, 0, 0f);
                }
                else if (woodyTotalTime >= 3700 / mul && woodyTotalTime < 3790 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0.8f), Vector3.UnitY, -1 * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 4600 / mul)
                {
                    i.translate(0, 0, -0.001f * mul);

                }
                else if (woodyTotalTime >= 4610 / mul && woodyTotalTime < 4790 / mul)
                {
                    i.rotate(new Vector3(1, -0.021f, 0f), Vector3.UnitY, 1 * mul);
                }



            }


            foreach (Asset3d i in jessieLegLeft)
            {
                if (woodyTotalTime >= 800 / mul && woodyTotalTime < 912 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 912 / mul && woodyTotalTime < 1024 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1024 / mul && woodyTotalTime < 1136 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1136 / mul && woodyTotalTime < 1248 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1248 / mul && woodyTotalTime < 1360 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                    /* i.translate(0,0.01f,0);*/
                }
                else if (woodyTotalTime >= 1360 / mul && woodyTotalTime < 1472 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 2700 / mul && woodyTotalTime < 2812 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitZ, -0.05f * mul);
                }
                else if (woodyTotalTime >= 2812 / mul && woodyTotalTime < 2924 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitZ, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3800 / mul && woodyTotalTime < 3912 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3912 / mul && woodyTotalTime < 4024 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4024 / mul && woodyTotalTime < 4136 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4136 / mul && woodyTotalTime < 4248 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4248 / mul && woodyTotalTime < 4360 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                    /* i.translate(0,0.01f,0);*/
                }
                else if (woodyTotalTime >= 4360 / mul && woodyTotalTime < 4472 / mul)
                {
                    i.rotate(new Vector3(jessLeftLegCylinder.objectCenter.X, jessLeftLegCylinder.objectCenter.Y, jessLeftLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }

            }

            foreach (Asset3d i in jessieLegRight)
            {
                if (woodyTotalTime >= 912 / mul && woodyTotalTime < 1024 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1024 / mul && woodyTotalTime < 1136 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1136 / mul && woodyTotalTime < 1248 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1248 / mul && woodyTotalTime < 1360 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 1360 / mul && woodyTotalTime < 1472 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 1472 / mul && woodyTotalTime < 1584 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3450 / mul && woodyTotalTime < 3562 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitZ, 0.05f * mul);
                }
                else if (woodyTotalTime >= 3562 / mul && woodyTotalTime < 3674 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitZ, -0.05f * mul);
                }
                else if (woodyTotalTime >= 3912 / mul && woodyTotalTime < 4024 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4024 / mul && woodyTotalTime < 4136 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4136 / mul && woodyTotalTime < 4248 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4248 / mul && woodyTotalTime < 4360 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }
                else if (woodyTotalTime >= 4360 / mul && woodyTotalTime < 4472 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, 0.05f * mul);
                }
                else if (woodyTotalTime >= 4472 / mul && woodyTotalTime < 4584 / mul)
                {
                    i.rotate(new Vector3(jessRightLegCylinder.objectCenter.X, jessRightLegCylinder.objectCenter.Y, jessRightLegCylinder.objectCenter.Z), Vector3.UnitX, -0.05f * mul);
                }


            }


            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float cameraSpeed = 2.5f;

            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (KeyboardState.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }
            if (KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }

            var mouse = MouseState;
            var sensitivity = 0.2f;
            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;

            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Position = Vector3.Transform(
                    _camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position
                    - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed)
                    .ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
           /* if (KeyboardState.IsKeyDown(Keys.J))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitY, -95 * time);
                    foreach (Asset3d j in i.child)
                    {
                        j.rotate(Vector3.Zero, Vector3.UnitY, -720 * time);
                    }
                }
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                foreach (Asset3d i in objectList)
                {
                    i.rotate(Vector3.Zero, Vector3.UnitY, 95 * time);
                    foreach (Asset3d j in i.child)
                    {
                        j.rotate(Vector3.Zero, Vector3.UnitY, 720 * time);
                    }
                }
            }*/
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }

        //protected override void OnMouseDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    if(e.Button == MouseButton.Left)
        //    {
        //        float _x = (MousePosition.X - Size.X/2)/(Size.X/2);
        //        float _y = -(MousePosition.Y - Size.Y/2)/(Size.Y/2);

        //        Console.WriteLine("x = " + _x + " y = " + _y);
        //        _object[6].updateMousePos(_x, _y);

        //    }
        //}
    }
}
