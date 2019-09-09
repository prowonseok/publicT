using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Mozart.Common;
using Mozart.Collections;
using Mozart.Extensions;
using Mozart.Mapping;
using Mozart.Data;
using Mozart.Data.Entity;
using Mozart.Task.Execution;
using NewJenkinsTest.DataModel;
using NewJenkinsTest.Inputs;
using NewJenkinsTest.Outputs;
using Mozart.SeePlan.Pegging;
using SAPS.Planning;
using Mozart.SeePlan.General.Pegging;

namespace NewJenkinsTest
{
    
    /// <summary>
    /// Pegging execution model class
    /// </summary>
    public partial class Pegging_Module : ExecutionModule
    {
        public override string Name
        {
            get
            {
                return "Pegging";
            }
        }
        protected override System.Type ExecutorType
        {
            get
            {
                return typeof(Mozart.SeePlan.Pegging.Pegger);
            }
        }
        protected override void Configure()
        {
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ModelBuildImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ModelRunImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PegInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PegOutputMapperImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PegPostImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new APPLY_ACTImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new APPLY_YIELDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BUILD_INPLANImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new CHANGE_PARTImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FILTER_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MANIPULATE_DEMANDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PEG_WIPImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PREPARE_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new PREPARE_WIPImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SHIFT_TATImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SMOOTH_DEMANDImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WRITE_TARGETImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WRITE_UNPEGImpl());
            new RulesImpl().Configure();
            new RulePresetsImpl().Configure();
            new PegModelsImpl().Configure();
        }
        /// <summary>
        /// ModelBuild execution control implementation
        /// </summary>
        internal partial class ModelBuildImpl : Mozart.SeePlan.Pegging.PeggerModelBuildInterface
        {
        }
        /// <summary>
        /// ModelRun execution control implementation
        /// </summary>
        internal partial class ModelRunImpl : Mozart.SeePlan.Pegging.PeggerModelRunInterface
        {
            private Mozart.SeePlan.General.Pegging.PeggerModelControl fpPeggerModelControl = new Mozart.SeePlan.General.Pegging.PeggerModelControl();
            public override int ComparePegTarget(Mozart.SeePlan.Pegging.PegTarget x, Mozart.SeePlan.Pegging.PegTarget y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpPeggerModelControl.COMPARE_PEG_TARGET(x, y, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// PegInit execution control implementation
        /// </summary>
        internal partial class PegInitImpl : SAPS.Planning.PegInit
        {
        }
        /// <summary>
        /// PegOutputMapper execution control implementation
        /// </summary>
        internal partial class PegOutputMapperImpl : SAPS.Planning.PegOutputMapper
        {
        }
        /// <summary>
        /// PegPost execution control implementation
        /// </summary>
        internal partial class PegPostImpl : SAPS.Planning.PegPost
        {
            private SAPS.Planning.PeggingPredefines fpPeggingPredefines = new SAPS.Planning.PeggingPredefines();
            public override int OnGetInputBatchSize(SAPS.Planning.DataModel.SAPSProduct prod)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpPeggingPredefines.GET_INPUT_BATCH_SIZE_DEF(prod, ref handled, returnValue);
                return returnValue;
            }
            public override int OnGetLotSize(SAPS.Planning.DataModel.SAPSProduct prod)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpPeggingPredefines.GET_LOT_SIZE_DEF(prod, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// APPLY_ACT execution control implementation
        /// </summary>
        internal partial class APPLY_ACTImpl : Mozart.SeePlan.Pegging.ApplyActControl
        {
        }
        /// <summary>
        /// APPLY_YIELD execution control implementation
        /// </summary>
        internal partial class APPLY_YIELDImpl : Mozart.SeePlan.Pegging.ApplyYieldControl
        {
            private SAPS.Planning.Logic.Pegging.APPLY_YIELD fpAPPLY_YIELD = new SAPS.Planning.Logic.Pegging.APPLY_YIELD();
            public override double GetYield(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpAPPLY_YIELD.GET_YIELD0(pegPart, ref handled, returnValue);
                return returnValue;
            }
            public override bool UseTargetYield(Mozart.SeePlan.Pegging.PegPart pegPart, Mozart.SeePlan.Pegging.PegStage stage)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpAPPLY_YIELD.USE_TARGET_YIELD0(pegPart, stage, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// BUILD_INPLAN execution control implementation
        /// </summary>
        internal partial class BUILD_INPLANImpl : Mozart.SeePlan.General.Pegging.BuildInPlanControl
        {
            private SAPS.Planning.Logic.Pegging.BUILD_INPLAN fpBUILD_INPLAN = new SAPS.Planning.Logic.Pegging.BUILD_INPLAN();
            public override Mozart.SeePlan.Pegging.PegPart BuildInPlan(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fpBUILD_INPLAN.BUILD_IN_PLAN0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// CHANGE_PART execution control implementation
        /// </summary>
        internal partial class CHANGE_PARTImpl : Mozart.SeePlan.Pegging.ChangePartControl
        {
            private SAPS.Planning.Logic.Pegging.CHANGE_PART fpCHANGE_PART = new SAPS.Planning.Logic.Pegging.CHANGE_PART();
            public override System.Collections.Generic.List<object> GetPartChangeInfos(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun)
            {
                bool handled = false;
                System.Collections.Generic.List<object> returnValue = null;
                returnValue = this.fpCHANGE_PART.GET_PART_CHANGE_INFOS0(pegPart, isRun, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Pegging.PegPart ApplyPartChangeInfo(Mozart.SeePlan.Pegging.PegPart pegPart, object partChangeInfo, bool isRun)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fpCHANGE_PART.APPLY_PART_CHANGE_INFO0(pegPart, partChangeInfo, isRun, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// FILTER_TARGET execution control implementation
        /// </summary>
        internal partial class FILTER_TARGETImpl : Mozart.SeePlan.Pegging.FilterTargetControl
        {
        }
        /// <summary>
        /// MANIPULATE_DEMAND execution control implementation
        /// </summary>
        internal partial class MANIPULATE_DEMANDImpl : Mozart.SeePlan.General.Pegging.ManipulateDemandControl
        {
        }
        /// <summary>
        /// PEG_WIP execution control implementation
        /// </summary>
        internal partial class PEG_WIPImpl : Mozart.SeePlan.Pegging.PegWipControl
        {
            private SAPS.Planning.Logic.Pegging.PEG_WIP fpPEG_WIP = new SAPS.Planning.Logic.Pegging.PEG_WIP();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Pegging.IMaterial> GetWips(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Pegging.IMaterial> returnValue = null;
                returnValue = this.fpPEG_WIP.GET_WIPS0(pegPart, isRun, ref handled, returnValue);
                return returnValue;
            }
            public override void WritePeg(Mozart.SeePlan.Pegging.PegTarget target, Mozart.SeePlan.Pegging.IMaterial m, double qty)
            {
                bool handled = false;
                this.fpPEG_WIP.WRITE_PEG0(target, m, qty, ref handled);
            }
        }
        /// <summary>
        /// PREPARE_TARGET execution control implementation
        /// </summary>
        internal partial class PREPARE_TARGETImpl : Mozart.SeePlan.General.Pegging.PrepareTargetControl
        {
            private SAPS.Planning.Logic.Pegging.PREPARE_TARGET fpPREPARE_TARGET = new SAPS.Planning.Logic.Pegging.PREPARE_TARGET();
            public override Mozart.SeePlan.Pegging.PegPart PrepareTarget(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fpPREPARE_TARGET.PREPARE_TARGET0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// PREPARE_WIP execution control implementation
        /// </summary>
        internal partial class PREPARE_WIPImpl : Mozart.SeePlan.General.Pegging.PrepareWipControl
        {
            private SAPS.Planning.Logic.Pegging.PREPARE_WIP fpPREPARE_WIP = new SAPS.Planning.Logic.Pegging.PREPARE_WIP();
            public override Mozart.SeePlan.Pegging.PegPart PrepareWip(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.PegPart returnValue = null;
                returnValue = this.fpPREPARE_WIP.PREPARE_WIP0(pegPart, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// SHIFT_TAT execution control implementation
        /// </summary>
        internal partial class SHIFT_TATImpl : Mozart.SeePlan.Pegging.ShiftTatControl
        {
            private SAPS.Planning.Logic.Pegging.SHIFT_TAT fpSHIFT_TAT = new SAPS.Planning.Logic.Pegging.SHIFT_TAT();
            public override System.TimeSpan GetTat(Mozart.SeePlan.Pegging.PegPart pegPart, bool isRun)
            {
                bool handled = false;
                System.TimeSpan returnValue = default(System.TimeSpan);
                returnValue = this.fpSHIFT_TAT.GET_TAT0(pegPart, isRun, ref handled, returnValue);
                return returnValue;
            }
            public override bool UseTargetTat(Mozart.SeePlan.Pegging.PegPart pegPart, Mozart.SeePlan.Pegging.PegStage stage, bool isRun)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSHIFT_TAT.USE_TARGET_TAT0(pegPart, stage, isRun, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// SMOOTH_DEMAND execution control implementation
        /// </summary>
        internal partial class SMOOTH_DEMANDImpl : Mozart.SeePlan.Pegging.SmoothDemandControl
        {
            private Mozart.SeePlan.Pegging.PreRuleLogic fpPreRuleLogic = new Mozart.SeePlan.Pegging.PreRuleLogic();
            public override Mozart.SeePlan.Pegging.IInnerBucket CreateInnerBucket(string key, Mozart.SeePlan.Pegging.MoPlan moPlan, System.DateTime weekStartDate, bool isW00)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.IInnerBucket returnValue = null;
                returnValue = this.fpPreRuleLogic.CREATE_INNER_BUCKET_DEF(key, moPlan, weekStartDate, isW00, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Pegging.IOuterBucket CreateOuterBucket(string key)
            {
                bool handled = false;
                Mozart.SeePlan.Pegging.IOuterBucket returnValue = null;
                returnValue = this.fpPreRuleLogic.CREATE_OUTER_BUCKET_DEF(key, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// WRITE_TARGET execution control implementation
        /// </summary>
        internal partial class WRITE_TARGETImpl : Mozart.SeePlan.Pegging.WriteTargetControl
        {
            private SAPS.Planning.Logic.Pegging.WRITE_TARGET fpWRITE_TARGET = new SAPS.Planning.Logic.Pegging.WRITE_TARGET();
            public override void WriteTarget(Mozart.SeePlan.Pegging.PegPart pegPart, bool isOut)
            {
                bool handled = false;
                this.fpWRITE_TARGET.WRITE_TARGET0(pegPart, isOut, ref handled);
            }
            public override object GetStepPlanKey(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                object returnValue = null;
                returnValue = this.fpWRITE_TARGET.GET_STEP_PLAN_KEY0(pegPart, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.StepTarget CreateStepTarget(Mozart.SeePlan.Pegging.PegTarget pegTarget, object stepPlanKey, Mozart.SeePlan.DataModel.Step step, bool isRun)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.StepTarget returnValue = null;
                returnValue = this.fpWRITE_TARGET.CREATE_STEP_TARGET0(pegTarget, stepPlanKey, step, isRun, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// WRITE_UNPEG execution control implementation
        /// </summary>
        internal partial class WRITE_UNPEGImpl : Mozart.SeePlan.Pegging.WriteUnpegControl
        {
            private SAPS.Planning.Logic.Pegging.WRITE_UNPEG fpWRITE_UNPEG = new SAPS.Planning.Logic.Pegging.WRITE_UNPEG();
            public override void WriteUnpeg(Mozart.SeePlan.Pegging.PegPart pegPart)
            {
                bool handled = false;
                this.fpWRITE_UNPEG.WRITE_UNPEG0(pegPart, ref handled);
            }
        }
        internal class RulesImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
            }
        }
        internal class RulePresetsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateInit());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateRunPeg());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateWaitPeg());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreatePostPegStage());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateInPartChange());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateOutPartChange());
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.RuleFlow.IRulePreset>(this.CreateWaitPartChange());
            }
            /// <summary>
            /// Init's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateInit()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("PREPARE_TARGET");
                list.Add("PREPARE_WIP");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                return new Mozart.RuleFlow.RulePreset("Init", list, props);
            }
            /// <summary>
            /// RunPeg's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateRunPeg()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("APPLY_YIELD");
                list.Add("WRITE_TARGET");
                list.Add("PEG_WIP");
                list.Add("SHIFT_TAT");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", true);
                props.Set("Position", "\r\n                    ");
                return new Mozart.RuleFlow.RulePreset("RunPeg", list, props);
            }
            /// <summary>
            /// WaitPeg's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateWaitPeg()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("WRITE_TARGET");
                list.Add("PEG_WIP");
                list.Add("SHIFT_TAT");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", false);
                return new Mozart.RuleFlow.RulePreset("WaitPeg", list, props);
            }
            /// <summary>
            /// PostPegStage's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreatePostPegStage()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("WRITE_UNPEG");
                list.Add("BUILD_INPLAN");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                return new Mozart.RuleFlow.RulePreset("PostPegStage", list, props);
            }
            /// <summary>
            /// InPartChange's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateInPartChange()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("CHANGE_PART");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", false);
                props.Set("Position", "IN");
                return new Mozart.RuleFlow.RulePreset("InPartChange", list, props);
            }
            /// <summary>
            /// OutPartChange's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateOutPartChange()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("CHANGE_PART");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("IsRun", false);
                props.Set("Position", "OUT");
                return new Mozart.RuleFlow.RulePreset("OutPartChange", list, props);
            }
            /// <summary>
            /// WaitPartChange's RulePreset
            /// </summary>
            private Mozart.RuleFlow.RulePreset CreateWaitPartChange()
            {
                System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
                list.Add("CHANGE_PART");
                Mozart.RuleFlow.StageProperties props = new Mozart.RuleFlow.StageProperties();
                props.Set("Position", "WAIT");
                props.Set("IsRun", false);
                return new Mozart.RuleFlow.RulePreset("WaitPartChange", list, props);
            }
        }
        internal class PegModelsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Pegging.IPeggerCfg2>(this.BuildCfg());
            }
            private SAPS.Planning.Logic.Pegging.StepPegging fpStepPegging = new SAPS.Planning.Logic.Pegging.StepPegging();
            /// <summary>
            /// SAPSPegger's Pegger Model
            /// </summary>
            private Mozart.SeePlan.Pegging.IPeggerModel2 BuildSAPSPegger()
            {
                Mozart.SeePlan.Pegging.PeggerModelBuilder2 SAPSPegger = new Mozart.SeePlan.Pegging.PeggerModelBuilder2("SAPSPegger");
                Mozart.SeePlan.Pegging.PeggerAreaBuilder2 area0 = new Mozart.SeePlan.Pegging.PeggerAreaBuilder2("Start", false);
                Mozart.SeePlan.Pegging.PeggerAreaBuilder2 area1 = new Mozart.SeePlan.Pegging.PeggerAreaBuilder2("SmartFactory", false);
                Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder node0 = new Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder("PegInit");
                System.Collections.Generic.List<string> stgs0 = new System.Collections.Generic.List<string>();
                stgs0.Add("Init");
                node0.SetStages(stgs0);
                area1.AddNode(node0);
                Mozart.SeePlan.Pegging.PeggerProcessNodeBuilder node1 = new Mozart.SeePlan.Pegging.PeggerProcessNodeBuilder("StepPegging");
                node1.AddBlock("@S", "@S", Mozart.SeePlan.Pegging.BlockType.START);
                node1.AddNextBlockMap("@S", "OutPartChange");
                node1.AddFunction("@S", ((Mozart.SeePlan.Pegging.GetLastPeggingStepDelegate)(this.fpStepPegging.GETLASTPEGGINGSTEP)));
                node1.AddBlock("OutPartChange", "OutPartChange", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("OutPartChange", "RunPeg");
                node1.AddBlock("RunPeg", "RunPeg", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("RunPeg", "InPartChange");
                node1.AddBlock("InPartChange", "InPartChange", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("InPartChange", "WaitPeg");
                node1.AddBlock("WaitPeg", "WaitPeg", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("WaitPeg", "WaitPartChange");
                node1.AddBlock("WaitPartChange", "WaitPartChange", Mozart.SeePlan.Pegging.BlockType.STAGE);
                node1.AddNextBlockMap("WaitPartChange", "@E");
                node1.AddBlock("@E", "@E", Mozart.SeePlan.Pegging.BlockType.END);
                node1.AddFunction("@E", ((Mozart.SeePlan.Pegging.GetPrevPeggingStepDelegate)(this.fpStepPegging.GETPREVPEGGINGSTEP)));
                area1.AddNode(node1);
                Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder node2 = new Mozart.SeePlan.Pegging.PeggerNormalNodeBuilder("PostPeg");
                System.Collections.Generic.List<string> stgs2 = new System.Collections.Generic.List<string>();
                stgs2.Add("PostPegStage");
                node2.SetStages(stgs2);
                area1.AddNode(node2);
                area0.AddNext(area1);
                SAPSPegger.SetStart(area0);
                return SAPSPegger.Build();
            }
            /// <summary>
            /// Pegger Configuration
            /// </summary>
            private Mozart.SeePlan.Pegging.IPeggerCfg2 BuildCfg()
            {
                Mozart.SeePlan.Pegging.PeggerCfgBuilder2 cfg = new Mozart.SeePlan.Pegging.PeggerCfgBuilder2();
                cfg.AddModel(this.BuildSAPSPegger(), true);
                return cfg.Build();
            }
        }
    }
}
