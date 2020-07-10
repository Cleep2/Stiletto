﻿using KKAPI.Studio;
using RootMotion.FinalIK;
using System.Linq;
using UnityEngine;
using static ChaFileDefine;

namespace Stiletto
{
    public class HeelInfo : MonoBehaviour
    {
        public HeelFlags flags;

        public string heelName = "-- NONE --";

        public ChaControl cc;
        internal Vector3 height;
        internal Quaternion angleA;
        private Quaternion angleB;
        internal Quaternion angleLeg;

        private bool active;

        private Vector3 Height => active && flags.ACTIVE && flags.HEIGHT ? height : Vector3.zero;
        private Quaternion AngleA => active && flags.ACTIVE && flags.ANKLE_ROLL ? angleA : Quaternion.identity;
        private Quaternion AngleB => active && flags.ACTIVE && flags.TOE_ROLL ? angleB : Quaternion.identity;
        private Quaternion AngleLeg => active && flags.ACTIVE ? angleLeg : Quaternion.identity;

        public float AnkleAnglef
        {
            get => AngleA.eulerAngles.x;
            set
            {
                angleA = Quaternion.Euler(value, 0f, 0f);
                angleB = Quaternion.Euler(-value, 0f, 0f);
            }
        }

        public float LegAnglef
        {
            get => angleLeg.eulerAngles.x;
            set => angleLeg = Quaternion.Euler(value, 0f, 0f);
        }

        public float Heightf
        {
            get => Height.y;
            set => height = new Vector3(0, value, 0);
        }

        private void Awake()
        {
            flags = new HeelFlags();
            cc = gameObject.GetComponent<ChaControl>();

            //Stiletto.RegisterHeelInfo(this);
        }

        //void OnDisable()
        //{
        //    //Stiletto.UnregisterHeelInfo(this);
        //}

        //private bool registered = false;
        //private NPC npc = null;

        private void Start()
        {
            //npc = Singleton<Manager.Game>.Instance.actScene.npcList.FirstOrDefault(x => x.chaCtrl.chaID == cc.chaID);
            //if (!npc)
            //TODO: cry
            Stiletto.RegisterHeelInfo(this);
        }

        private void OnDestroy()
        {
            //Console.WriteLine("ONDESTROY - " + cc.fileParam.fullname);
            Stiletto.UnregisterHeelInfo(this);
        }

        private void Update()
        {
            var currentShoes = (int)(cc.fileStatus.shoesType == 0 ? ClothesKind.shoes_inner : ClothesKind.shoes_outer);
            active = (cc.fileStatus.clothesState[currentShoes] == 0);
            if(animBody == null) return;
            var aci = animBody.GetCurrentAnimatorClipInfo(0);
            if(aci.Length == 0) return;


            var first = aci[0];
            animationName = first.clip.name;

            pathName = animBody.runtimeAnimatorController.name;
#warning optimise by detecting animation change?
            flags = Stiletto.FetchFlags(key);
        }

        private void LateUpdate()
        {
            if(solver == null)
            {
                OnPreRead();
                PostUpdate();
            }
        }

        private void UpdateValues(float height, float angleAnkle, float angleLeg)
        {
            this.height = new Vector3(0, height, 0);
            angleA = Quaternion.Euler(angleAnkle, 0f, 0f);
            angleB = Quaternion.Euler(-angleAnkle, 0f, 0f);
            this.angleLeg = Quaternion.Euler(angleLeg, 0f, 0f);
            StilettoGui.UpdateMakerValues(this);
        }

        internal void Setup(string heelName, ChaControl chaControl, float height, float angleAnkle, float angleLeg)
        {
            animBody = chaControl.animBody;
            this.heelName = heelName;
            cc = chaControl;
            body = cc.objBodyBone.transform.parent;
            UpdateValues(height, angleAnkle, angleLeg);

            var waist = body.Find("cf_j_root/cf_n_height/cf_j_hips/cf_j_waist01/cf_j_waist02");
            if(waist == null) return;

            var legl3 = waist.Find("cf_j_thigh00_L/cf_j_leg01_L");
            leg_L = legl3.Find("cf_j_leg03_L");
            footL = leg_L.Find("cf_j_foot_L");
            toesL = footL.Find("cf_j_toes_L");

            var legr3 = waist.Find("cf_j_thigh00_R/cf_j_leg01_R");
            leg_R = legr3.Find("cf_j_leg03_R");
            footR = leg_R.Find("cf_j_foot_R");
            toesR = footR.Find("cf_j_toes_R");

            SetFBBIK(animBody.GetComponent<FullBodyBipedIK>());
        }

        private IKSolverFullBodyBiped solver;
        private Transform body = null;

        private Transform leg_L = null;
        private Transform footL = null;
        private Transform toesL = null;

        private Transform leg_R = null;
        private Transform footR = null;
        private Transform toesR = null;

        private Animator animBody;

        public string animationName { get; private set; } = "-- NONE --";
        public string pathName { get; private set; } = "-- NONE --";

        public string key => $"{pathName}/{animationName}";

        private void OnPreRead()
        {
#warning fix this
            if(flags.KNEE_BEND && solver != null)
            {
                solver.bodyEffector.positionOffset = -Height;
            }
            else
            {
                body.localPosition = Height;
            }
        }

        private void PostUpdate()
        {
            if(flags.KNEE_BEND && solver != null)
            {
                solver.rightFootEffector.target.position += Height;
                solver.leftFootEffector.target.position += Height;
                body.localPosition = Vector3.zero;
            }

            footL.localRotation *= AngleA;
            footR.localRotation *= AngleA;
            toesL.localRotation *= AngleB;
            toesR.localRotation *= AngleB;

            //leg_L.localRotation = Quaternion.identity;
            //leg_R.localRotation = Quaternion.identity;

            leg_L.localRotation *= AngleLeg;
            leg_R.localRotation *= AngleLeg;
        }


        private void SetFBBIK(FullBodyBipedIK fbbik)
        {
            if(fbbik != null) solver = fbbik.solver;

            if(solver != null)
            {

                if(!StudioAPI.InsideStudio)
                {
                    var currentSceneName = fbbik.gameObject.scene.name;
                    if(!new[] { SceneNames.CustomScene, SceneNames.H, SceneNames.MyRoom }.Contains(currentSceneName))
                    {
                        //Disable arm weights, we only affect feet/knees.
                        fbbik.GetIKSolver().Initiate(fbbik.transform);
                        fbbik.solver.leftHandEffector.positionWeight = 0f;
                        fbbik.solver.rightHandEffector.positionWeight = 0f;
                        fbbik.solver.leftArmChain.bendConstraint.weight = 0f;
                        fbbik.solver.rightArmChain.bendConstraint.weight = 0f;
                        fbbik.solver.leftFootEffector.rotationWeight = 0f;
                        fbbik.solver.rightFootEffector.rotationWeight = 0f;
                    }
                    solver.IKPositionWeight = 1f;
                    fbbik.enabled = true;
                }
                solver.OnPreRead = OnPreRead;
                solver.OnPostUpdate = PostUpdate;
            }
#warning Detect overworld and adjust weights?

            if(StudioAPI.InsideStudio)
            {
                Update();
                OnPreRead();
                PostUpdate();
            }
        }
    }
}
