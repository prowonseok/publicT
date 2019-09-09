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
using Mozart.SeePlan.Simulation;
using Mozart.SeePlan.Optimization;
using SAPS.Planning;
using Mozart.SeePlan.StatModel;

namespace NewJenkinsTest
{
    
    /// <summary>
    /// Scheduling execution model class
    /// </summary>
    public partial class Scheduling_Module : ExecutionModule
    {
        public override string Name
        {
            get
            {
                return "Scheduling";
            }
        }
        protected override System.Type ExecutorType
        {
            get
            {
                return typeof(Mozart.SeePlan.Simulation.LoadingSimulator);
            }
        }
        protected override void Configure()
        {
            Mozart.Task.Execution.ServiceLocator.RegisterController(new EqpInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FactoryInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FactoryEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new WipInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InputBatchInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new RouteImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ForwardPegImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InOutControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MergeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new TransferControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new TransferSystemInterfaceImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new QueueControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new FilterControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new DispatcherControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ProcessControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SetupControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new DownControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new MiscImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new EqpEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new BucketEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ToolControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new ToolEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new AgentInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobProfileControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobTradeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobChangeControlImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new JobChangeEventsImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new InitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new RunImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SimInitImpl());
            Mozart.Task.Execution.ServiceLocator.RegisterController(new SimRunImpl());
            new StatSheetsImpl().Configure();
            new WeightsImpl().Configure();
            new CustomEventsImpl().Configure();
            new FiltersImpl().Configure();
        }
        /// <summary>
        /// EqpInit execution control implementation
        /// </summary>
        internal partial class EqpInitImpl : Mozart.SeePlan.Simulation.EquipmentInitiator
        {
            private SAPS.Planning.Logic.Simulation.EqpInit fpEqpInit = new SAPS.Planning.Logic.Simulation.EqpInit();
            protected override System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.Resource> GetEqpList()
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.Resource> returnValue = null;
                returnValue = this.fpEqpInit.GET_EQP_LIST0(ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.FactoryLogic fpFactoryLogic = new Mozart.SeePlan.Simulation.FactoryLogic();
            protected override string GetDispatcherType(Mozart.SeePlan.DataModel.Resource eqp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpFactoryLogic.GET_DISPATCHER_TYPE_DEF(eqp, ref handled, returnValue);
                return returnValue;
            }
            protected override string GetEqpSimType(Mozart.SeePlan.DataModel.Resource eqp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpFactoryLogic.GET_EQP_SIM_TYPE_DEF(eqp, ref handled, returnValue);
                return returnValue;
            }
            protected override System.DateTime GetEqpUpTime(Mozart.SeePlan.DataModel.Resource resource, System.DateTime stateChangeTime)
            {
                bool handled = false;
                System.DateTime returnValue = default(System.DateTime);
                returnValue = this.fpEqpInit.GET_EQP_UP_TIME0(resource, stateChangeTime, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// BucketInit execution control implementation
        /// </summary>
        internal partial class BucketInitImpl : Mozart.SeePlan.Simulation.BucketInit
        {
        }
        /// <summary>
        /// FactoryInit execution control implementation
        /// </summary>
        internal partial class FactoryInitImpl : Mozart.SeePlan.Simulation.FactoryInit
        {
            private SAPS.Planning.Logic.Simulation.FactoryInit fpFactoryInit = new SAPS.Planning.Logic.Simulation.FactoryInit();
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.WeightPreset> GetWeightPresets(Mozart.SeePlan.Simulation.AoFactory factory)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.WeightPreset> returnValue = null;
                returnValue = this.fpFactoryInit.GET_WEIGHT_PRESETS0(factory, ref handled, returnValue);
                return returnValue;
            }
            public override void InitializeWipGroup(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IWipManager wipManager)
            {
                bool handled = false;
                this.fpFactoryInit.INITIALIZE_WIP_GROUP0(factory, wipManager, ref handled);
            }
        }
        /// <summary>
        /// FactoryEvents execution control implementation
        /// </summary>
        internal partial class FactoryEventsImpl : Mozart.SeePlan.Simulation.FactoryEvents
        {
            private SAPS.Planning.Logic.Simulation.FactoryEvents fpFactoryEvents = new SAPS.Planning.Logic.Simulation.FactoryEvents();
            public override void OnDone(Mozart.SeePlan.Simulation.AoFactory aoFactory)
            {
                bool handled = false;
                this.fpFactoryEvents.ON_DONE0(aoFactory, ref handled);
            }
        }
        /// <summary>
        /// WipInit execution control implementation
        /// </summary>
        internal partial class WipInitImpl : Mozart.SeePlan.Simulation.WipInitiator
        {
            private SAPS.Planning.Logic.Simulation.WipInit fpWipInit = new SAPS.Planning.Logic.Simulation.WipInit();
            protected override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> GetWips()
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpWipInit.GET_WIPS0(ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            protected override int CompareWip(Mozart.SeePlan.Simulation.IHandlingBatch x, Mozart.SeePlan.Simulation.IHandlingBatch y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpEntityLogic.COMPARE_WIP_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            protected override void LocateForDispatch(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpEntityLogic.LOCATE_FOR_DISPATCH_DEF(factory, hb, ref handled);
            }
            protected override void LocateForRun(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpEntityLogic.LOCATE_FOR_RUN_DEF(factory, hb, ref handled);
            }
            public override string GetLoadingEquipment(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpWipInit.GET_LOADING_EQUIPMENT0(hb, ref handled, returnValue);
                return returnValue;
            }
            public override bool CheckTrackOut(Mozart.SeePlan.Simulation.AoFactory factory, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpWipInit.CHECK_TRACK_OUT0(factory, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.Simulation.Engine.ISimEntity FixBatch(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.Simulation.Engine.ISimEntity entity)
            {
                bool handled = false;
                Mozart.Simulation.Engine.ISimEntity returnValue = null;
                returnValue = this.fpEntityLogic.FIX_BATCH_DEF(aeqp, entity, ref handled, returnValue);
                return returnValue;
            }
            public override System.DateTime FixStartTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                System.DateTime returnValue = default(System.DateTime);
                returnValue = this.fpWipInit.FIX_START_TIME0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// InputBatchInit execution control implementation
        /// </summary>
        internal partial class InputBatchInitImpl : Mozart.SeePlan.Simulation.BatchInitiator
        {
            private SAPS.Planning.Logic.Simulation.InputBatchInit fpInputBatchInit = new SAPS.Planning.Logic.Simulation.InputBatchInit();
            protected override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.ILot> Instancing()
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.ILot> returnValue = null;
                returnValue = this.fpInputBatchInit.INSTANCING0(ref handled, returnValue);
                if (handled)
                {
                    return returnValue;
                }
                returnValue = this.fpInputBatchInit.INSTANCING1(ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            protected override void DoReserve(System.Collections.Generic.List<Mozart.SeePlan.Simulation.ILot> lots)
            {
                bool handled = false;
                this.fpEntityLogic.DO_RESERVE_DEF(lots, ref handled);
            }
            public override void ReserveOne(System.Collections.Generic.List<Mozart.SeePlan.Simulation.ILot> lots, ref int index)
            {
                bool handled = false;
                this.fpEntityLogic.RESERVE_ONE_DEF(lots, ref index, ref handled);
            }
            protected override int CompareLot(Mozart.SeePlan.Simulation.ILot x, Mozart.SeePlan.Simulation.ILot y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpEntityLogic.COMPARE_LOT_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// Route execution control implementation
        /// </summary>
        internal partial class RouteImpl : Mozart.SeePlan.Simulation.EntityControl
        {
            private SAPS.Planning.Logic.Simulation.Route fpRoute = new SAPS.Planning.Logic.Simulation.Route();
            public override System.Collections.Generic.IList<string> GetLoadableEqpList(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                System.Collections.Generic.IList<string> returnValue = null;
                returnValue = this.fpRoute.GET_LOADABLE_EQP_LIST0(da, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.Step GetNextStep(Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.LoadInfo loadInfo, Mozart.SeePlan.DataModel.Step step, System.DateTime now)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.Step returnValue = null;
                returnValue = this.fpRoute.GET_NEXT_STEP0(lot, loadInfo, step, now, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.LoadInfo CreateLoadInfo(Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.Step task)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.LoadInfo returnValue = null;
                returnValue = this.fpRoute.CREATE_LOAD_INFO0(lot, task, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EntityLogic fpEntityLogic = new Mozart.SeePlan.Simulation.EntityLogic();
            public override bool IsDone(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpEntityLogic.IS_DONE_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// ForwardPeg execution control implementation
        /// </summary>
        internal partial class ForwardPegImpl : Mozart.SeePlan.Simulation.ForwardPeg
        {
            private SAPS.Planning.Logic.Simulation.ForwardPeg fpForwardPeg = new SAPS.Planning.Logic.Simulation.ForwardPeg();
            public override System.Collections.Generic.IEnumerable<System.Tuple<Mozart.SeePlan.DataModel.Step, object>> GetStepPlanKeys(Mozart.SeePlan.Simulation.ILot lot)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<System.Tuple<Mozart.SeePlan.DataModel.Step, object>> returnValue = null;
                returnValue = this.fpForwardPeg.GET_STEP_PLAN_KEYS0(lot, ref handled, returnValue);
                return returnValue;
            }
            public override double GetForwardPeggingQty(Mozart.SeePlan.Simulation.ILot lot)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpForwardPeg.GET_FORWARD_PEGGING_QTY0(lot, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// InOutControl execution control implementation
        /// </summary>
        internal partial class InOutControlImpl : Mozart.SeePlan.Simulation.InOutControl
        {
        }
        /// <summary>
        /// MergeControl execution control implementation
        /// </summary>
        internal partial class MergeControlImpl : Mozart.SeePlan.Simulation.EntityMergeControl
        {
            private SAPS.Planning.Logic.Simulation.MergeControl fpMergeControl = new SAPS.Planning.Logic.Simulation.MergeControl();
            public override object GetMergeableKey(Mozart.Simulation.Engine.ISimEntity entity)
            {
                bool handled = false;
                object returnValue = null;
                returnValue = this.fpMergeControl.GET_MERGEABLE_KEY0(entity, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> Merge(object key, System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> entitys)
            {
                bool handled = false;
                System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> returnValue = null;
                returnValue = this.fpMergeControl.MERGE0(key, entitys, ref handled, returnValue);
                if (handled)
                {
                    return returnValue;
                }
                returnValue = this.fpMergeControl.MERGE1(key, entitys, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> DisposeEntities(System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> entitys)
            {
                bool handled = false;
                System.Collections.Generic.List<Mozart.Simulation.Engine.ISimEntity> returnValue = null;
                returnValue = this.fpMergeControl.DISPOSE_ENTITIES0(entitys, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// TransferControl execution control implementation
        /// </summary>
        internal partial class TransferControlImpl : Mozart.SeePlan.Simulation.TransferControl
        {
            private SAPS.Planning.Logic.Simulation.TransferControl fpTransferControl = new SAPS.Planning.Logic.Simulation.TransferControl();
            public override Mozart.Simulation.Engine.Time GetTransferTime(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpTransferControl.GET_TRANSFER_TIME0(hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// TransferSystemInterface execution control implementation
        /// </summary>
        internal partial class TransferSystemInterfaceImpl : Mozart.SeePlan.Simulation.TransferExtControl
        {
            private Mozart.SeePlan.Simulation.TransferLogic fpTransferLogic = new Mozart.SeePlan.Simulation.TransferLogic();
            public override void OnDelivered(Mozart.SeePlan.Simulation.TransportAdapter ta, string key, string sourceLocation, string targetLocation)
            {
                bool handled = false;
                this.fpTransferLogic.ON_DELIVERED_DEF(ta, key, sourceLocation, targetLocation, ref handled);
            }
        }
        /// <summary>
        /// QueueControl execution control implementation
        /// </summary>
        internal partial class QueueControlImpl : Mozart.SeePlan.Simulation.QueueControl
        {
            private SAPS.Planning.Logic.Simulation.QueueControl fpQueueControl = new SAPS.Planning.Logic.Simulation.QueueControl();
            public override bool InterceptIn(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpQueueControl.INTERCEPT_IN0(da, hb, ref handled, returnValue);
                return returnValue;
            }
            public override void OnNotFoundDestination(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb, int destCount)
            {
                bool handled = false;
                this.fpQueueControl.ON_NOT_FOUND_DESTINATION0(da, hb, destCount, ref handled);
            }
        }
        /// <summary>
        /// FilterControl execution control implementation
        /// </summary>
        internal partial class FilterControlImpl : Mozart.SeePlan.Simulation.DispatchFilterControl
        {
            private SAPS.Planning.Logic.Simulation.FilterControl fpFilterControl = new SAPS.Planning.Logic.Simulation.FilterControl();
            public override bool IsPreventDispatching(Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.Simulation.Engine.Time waitDownTime)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpFilterControl.IS_PREVENT_DISPATCHING0(aeqp, wips, waitDownTime, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Simulation.IHandlingBatch[] CheckReservation(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.IHandlingBatch[] returnValue = null;
                returnValue = this.fpFilterControl.CHECK_RESERVATION0(da, aeqp, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.DispatchingLogic fpDispatchingLogic = new Mozart.SeePlan.Simulation.DispatchingLogic();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> DoFilter(Mozart.SeePlan.Simulation.AoEquipment eqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpDispatchingLogic.DO_FILTER_DEF(eqp, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsLoadable(Mozart.SeePlan.Simulation.AoEquipment eqp, Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpFilterControl.IS_LOADABLE0(eqp, hb, ctx, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// DispatcherControl execution control implementation
        /// </summary>
        internal partial class DispatcherControlImpl : Mozart.SeePlan.Simulation.DispatchControl
        {
            private Mozart.SeePlan.Simulation.DispatchingLogic fpDispatchingLogic = new Mozart.SeePlan.Simulation.DispatchingLogic();
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> SortLotGroupContents(Mozart.SeePlan.Simulation.DispatcherBase db, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> list, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpDispatchingLogic.SORT_LOT_GROUP_CONTENTS_DEF(db, list, ctx, ref handled, returnValue);
                return returnValue;
            }
            private SAPS.Planning.Logic.Simulation.DispatcherControl fpDispatcherControl = new SAPS.Planning.Logic.Simulation.DispatcherControl();
            public override System.Type GetLotBatchType()
            {
                bool handled = false;
                System.Type returnValue = null;
                returnValue = this.fpDispatcherControl.GET_LOT_BATCH_TYPE0(ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Simulation.IHandlingBatch[] DoSelect(Mozart.SeePlan.Simulation.DispatcherBase db, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.IHandlingBatch[] returnValue = null;
                returnValue = this.fpDispatchingLogic.DO_SELECT_DEF(db, aeqp, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> Evaluate(Mozart.SeePlan.Simulation.DispatcherBase db, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips, Mozart.SeePlan.Simulation.IDispatchContext ctx)
            {
                bool handled = false;
                System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> returnValue = null;
                returnValue = this.fpDispatcherControl.EVALUATE0(db, wips, ctx, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.Simulation.IHandlingBatch[] Select(Mozart.SeePlan.Simulation.DispatcherBase db, Mozart.SeePlan.Simulation.AoEquipment aeqp, System.Collections.Generic.IList<Mozart.SeePlan.Simulation.IHandlingBatch> wips)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.IHandlingBatch[] returnValue = null;
                returnValue = this.fpDispatchingLogic.SELECT_DEF(db, aeqp, wips, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsWriteDispatchLog(Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpDispatcherControl.IS_WRITE_DISPATCH_LOG0(aeqp, ref handled, returnValue);
                return returnValue;
            }
            public override string AddDispatchWipLog(Mozart.SeePlan.DataModel.Resource eqp, Mozart.SeePlan.Simulation.EntityDispatchInfo info, Mozart.SeePlan.Simulation.ILot lot, Mozart.SeePlan.DataModel.WeightPreset wp)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpDispatcherControl.ADD_DISPATCH_WIP_LOG0(eqp, info, lot, wp, ref handled, returnValue);
                return returnValue;
            }
            public override string GetSelectedWipLog(Mozart.SeePlan.DataModel.Resource eqp, Mozart.SeePlan.Simulation.IHandlingBatch[] sels)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpDispatchingLogic.GET_SELECTED_WIP_LOG_DEF(eqp, sels, ref handled, returnValue);
                return returnValue;
            }
            public override void WriteDispatchLog(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.EqpDispatchInfo info)
            {
                bool handled = false;
                this.fpDispatcherControl.WRITE_DISPATCH_LOG0(da, info, ref handled);
            }
            public override void OnDispatched(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch[] wips)
            {
                bool handled = false;
                this.fpDispatcherControl.ON_DISPATCHED0(da, aeqp, wips, ref handled);
            }
        }
        /// <summary>
        /// ProcessControl execution control implementation
        /// </summary>
        internal partial class ProcessControlImpl : Mozart.SeePlan.Simulation.EqpProcessControl
        {
            private SAPS.Planning.Logic.Simulation.ProcessControl fpProcessControl = new SAPS.Planning.Logic.Simulation.ProcessControl();
            public override void OnCustomLoad(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpProcessControl.ON_CUSTOM_LOAD0(aeqp, hb, ref handled);
            }
            public override bool IsNeedSetup(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpProcessControl.IS_NEED_SETUP0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.ProcTimeInfo GetProcessTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.ProcTimeInfo returnValue = default(Mozart.SeePlan.DataModel.ProcTimeInfo);
                returnValue = this.fpProcessControl.GET_PROCESS_TIME0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override double GetProcessUnitSize(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpProcessControl.GET_PROCESS_UNIT_SIZE0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override string[] GetLoadableChambers(Mozart.SeePlan.Simulation.AoChamberProc2 cproc, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string[] returnValue = null;
                returnValue = this.fpEquipmentLogic.GET_LOADABLE_CHAMBERS_DEF(cproc, hb, ref handled, returnValue);
                return returnValue;
            }
            public override void OnEntered(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.AoProcess proc, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpEquipmentLogic.MODIFY_DOWN_SCHEDULE_DEF(aeqp, proc, hb, ref handled);
            }
            public override void OnTrackOut(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpProcessControl.ON_TRACK_OUT0(aeqp, hb, ref handled);
            }
        }
        /// <summary>
        /// SetupControl execution control implementation
        /// </summary>
        internal partial class SetupControlImpl : Mozart.SeePlan.Simulation.EqpSetupControl
        {
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override string GetSetupCrewKey(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpEquipmentLogic.GET_SETUP_CREW_KEY_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            private SAPS.Planning.Logic.Simulation.SetupControl fpSetupControl = new SAPS.Planning.Logic.Simulation.SetupControl();
            public override Mozart.Simulation.Engine.Time GetSetupTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpSetupControl.GET_SETUP_TIME0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.SeePlan.DataModel.LoadInfo SetLastLoadingInfo(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.DataModel.LoadInfo returnValue = null;
                returnValue = this.fpEquipmentLogic.SET_LAST_LOADING_INFO_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// DownControl execution control implementation
        /// </summary>
        internal partial class DownControlImpl : Mozart.SeePlan.Simulation.EqpDownControl
        {
            private SAPS.Planning.Logic.Simulation.DownControl fpDownControl = new SAPS.Planning.Logic.Simulation.DownControl();
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.PMSchedule> GetPMList(Mozart.SeePlan.Simulation.PMEvents fe, Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.DataModel.PMSchedule> returnValue = null;
                returnValue = this.fpDownControl.GET_PMLIST0(fe, aeqp, ref handled, returnValue);
                return returnValue;
            }
            public override void OnPMEvent(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.DataModel.PMSchedule fs, Mozart.SeePlan.Simulation.DownEventType det)
            {
                bool handled = false;
                this.fpDownControl.ON_PMEVENT0(aeqp, fs, det, ref handled);
            }
            public override void OnFailureEvent(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.DataModel.FailureSchedule fs, Mozart.SeePlan.Simulation.DownEventType det)
            {
                bool handled = false;
                this.fpDownControl.ON_FAILURE_EVENT0(aeqp, fs, det, ref handled);
            }
        }
        /// <summary>
        /// Misc execution control implementation
        /// </summary>
        internal partial class MiscImpl : Mozart.SeePlan.Simulation.EqpMisc
        {
            private Mozart.SeePlan.Simulation.EquipmentLogic fpEquipmentLogic = new Mozart.SeePlan.Simulation.EquipmentLogic();
            public override bool IsBatchType(Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpEquipmentLogic.IsBatchType(aeqp, ref handled, returnValue);
                return returnValue;
            }
            private SAPS.Planning.Logic.Simulation.Misc fpMisc = new SAPS.Planning.Logic.Simulation.Misc();
            public override bool UseCustomLoad(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpMisc.USE_CUSTOM_LOAD0(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// EqpEvents execution control implementation
        /// </summary>
        internal partial class EqpEventsImpl : Mozart.SeePlan.Simulation.EqpEvents
        {
            private SAPS.Planning.Logic.Simulation.EqpEvents fpEqpEvents = new SAPS.Planning.Logic.Simulation.EqpEvents();
            public override void LoadingStateChanged(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.LoadingStates state)
            {
                bool handled = false;
                this.fpEqpEvents.LOADING_STATE_CHANGED0(aeqp, hb, state, ref handled);
            }
        }
        /// <summary>
        /// BucketControl execution control implementation
        /// </summary>
        internal partial class BucketControlImpl : Mozart.SeePlan.Simulation.BucketControl
        {
            private Mozart.SeePlan.Simulation.BucketingLogic fpBucketingLogic = new Mozart.SeePlan.Simulation.BucketingLogic();
            public override void AddBucketMove(Mozart.SeePlan.Simulation.CapacityBucket cb, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpBucketingLogic.ADD_BUCKET_MOVE_DEF(cb, hb, ref handled);
            }
            private SAPS.Planning.Logic.Simulation.BucketControl fpBucketControl = new SAPS.Planning.Logic.Simulation.BucketControl();
            public override Mozart.Simulation.Engine.Time GetBucketTime(Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.AoBucketer bucketer)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpBucketControl.GET_BUCKET_TIME0(hb, bucketer, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.Simulation.Engine.Time GetBucketInputDelay(Mozart.SeePlan.Simulation.IHandlingBatch hb, Mozart.SeePlan.Simulation.AoBucketer bucketer)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpBucketingLogic.GET_BUCKET_INPUT_DELAY_DEF(hb, bucketer, ref handled, returnValue);
                return returnValue;
            }
            public override void BucketRolling(Mozart.SeePlan.Simulation.CapacityBucket cb, System.DateTime now, bool atBoundary, bool atDayChanged)
            {
                bool handled = false;
                this.fpBucketingLogic.BUCKET_ROLLING_DEF(cb, now, atBoundary, atDayChanged, ref handled);
            }
        }
        /// <summary>
        /// BucketEvents execution control implementation
        /// </summary>
        internal partial class BucketEventsImpl : Mozart.SeePlan.Simulation.BucketEvents
        {
        }
        /// <summary>
        /// ToolControl execution control implementation
        /// </summary>
        internal partial class ToolControlImpl : Mozart.SeePlan.Simulation.ToolControl
        {
            private SAPS.Planning.Logic.Simulation.ToolControl fpToolControl = new SAPS.Planning.Logic.Simulation.ToolControl();
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.ToolItem> BuildToolItems(Mozart.SeePlan.Simulation.ToolSettings tool)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.ToolItem> returnValue = null;
                returnValue = this.fpToolControl.BUILD_TOOL_ITEMS0(tool, ref handled, returnValue);
                return returnValue;
            }
            private Mozart.SeePlan.Simulation.SecondResourceLogic fpSecondResourceLogic = new Mozart.SeePlan.Simulation.SecondResourceLogic();
            public override Mozart.SeePlan.Simulation.ToolSettings GetLastToolSettings(Mozart.SeePlan.Simulation.AoEquipment aeqp)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.ToolSettings returnValue = null;
                returnValue = this.fpSecondResourceLogic.GET_LAST_TOOL_SETTINGS_DEF(aeqp, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsValidToolInfo(Mozart.SeePlan.Simulation.ToolSettings tool, Mozart.SeePlan.Simulation.ToolItem current)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSecondResourceLogic.IS_VALID_TOOL_INFO_DEF(tool, current, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsReadyTool(Mozart.SeePlan.Simulation.ToolSettings tool, Mozart.SeePlan.Simulation.ToolItem current, Mozart.SeePlan.Simulation.ToolItem last)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSecondResourceLogic.IS_READY_TOOL_DEF(tool, current, last, ref handled, returnValue);
                return returnValue;
            }
            public override void AttachTool(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpSecondResourceLogic.ATTACH_TOOL_DEF(hb, ref handled);
            }
            public override void DetachTool(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                this.fpSecondResourceLogic.DETACH_TOOL_DEF(hb, ref handled);
            }
        }
        /// <summary>
        /// ToolEvents execution control implementation
        /// </summary>
        internal partial class ToolEventsImpl : Mozart.SeePlan.Simulation.ToolEvents
        {
        }
        /// <summary>
        /// AgentInit execution control implementation
        /// </summary>
        internal partial class AgentInitImpl : Mozart.SeePlan.Simulation.JobChangeInit
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override void InitializeWorkManager(Mozart.SeePlan.Simulation.WorkManager wmanager)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.INITIALIZE_WORK_MANAGER_DEF(wmanager, ref handled);
            }
            public override Mozart.SeePlan.Simulation.WorkStep AddWorkLot(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkStep returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.ADD_WORK_LOT_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
            public override void InitializeWorkStep(Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.INITIALIZE_WORK_STEP_DEF(wstep, ref handled);
            }
        }
        /// <summary>
        /// JobProfileControl execution control implementation
        /// </summary>
        internal partial class JobProfileControlImpl : Mozart.SeePlan.Simulation.JobProfileControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override Mozart.SeePlan.Simulation.WorkEqp SelectProfileEqp(Mozart.SeePlan.Simulation.WorkLoader wl)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkEqp returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_PROFILE_EQP_DEF(wl, ref handled, returnValue);
                return returnValue;
            }
            public override int CompareProfileEqp(Mozart.SeePlan.Simulation.WorkEqp x, Mozart.SeePlan.Simulation.WorkEqp y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpJobChangeAgentLogic.COMPARE_PROFILE_EQP_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            public override void SortProfileLot(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.WorkEqp weqp, System.Collections.Generic.List<Mozart.SeePlan.Simulation.WorkLot> list)
            {
                bool handled = false;
                this.fpJobChangeAgentLogic.SORT_PROFILE_LOT_DEF(wstep, weqp, list, ref handled);
            }
            public override Mozart.SeePlan.Simulation.WorkLot CreateDummyWorkLot(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.WorkEqp weqp, Mozart.SeePlan.Simulation.WorkLot wlot, Mozart.SeePlan.Simulation.WorkLotType type, Mozart.Simulation.Engine.Time startTime, Mozart.Simulation.Engine.Time endTime, object stepKey, Mozart.SeePlan.DataModel.Step step)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkLot returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.CREATE_DUMMY_WORK_LOT_DEF(wstep, weqp, wlot, type, startTime, endTime, stepKey, step, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobTradeControl execution control implementation
        /// </summary>
        internal partial class JobTradeControlImpl : Mozart.SeePlan.Simulation.JobTradeControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override Mozart.SeePlan.Simulation.WorkStep SelectUpStep(System.Collections.Generic.List<Mozart.SeePlan.Simulation.WorkStep> upWorkSteps, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                Mozart.SeePlan.Simulation.WorkStep returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_UP_STEP_DEF(upWorkSteps, context, ref handled, returnValue);
                return returnValue;
            }
            public override int CompareUpStep(Mozart.SeePlan.Simulation.WorkStep x, Mozart.SeePlan.Simulation.WorkStep y)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpJobChangeAgentLogic.COMPARE_UP_STEP_PRIORITY_DEF(x, y, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> SelectAssignEqp(Mozart.SeePlan.Simulation.WorkStep upWorkStep, System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> assignEqps, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                System.Collections.Generic.List<Mozart.SeePlan.Simulation.AssignEqp> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_ASSIGN_EQP_DEF(upWorkStep, assignEqps, context, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> SelectDownEqp(Mozart.SeePlan.Simulation.WorkStep wstep, Mozart.SeePlan.Simulation.JobChangeContext context)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_DOWN_EQP_T_DEF(wstep, context, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobChangeControl execution control implementation
        /// </summary>
        internal partial class JobChangeControlImpl : Mozart.SeePlan.Simulation.JobChangeControl
        {
            private Mozart.SeePlan.Simulation.JobChangeAgentLogic fpJobChangeAgentLogic = new Mozart.SeePlan.Simulation.JobChangeAgentLogic();
            public override bool IsNeedDownStep(Mozart.SeePlan.Simulation.WorkStep ws)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.IS_NEED_DOWN_STEP_DEF(ws, ref handled, returnValue);
                return returnValue;
            }
            public override System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> SelectDownEqp(Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                System.Collections.Generic.IEnumerable<Mozart.SeePlan.Simulation.AoEquipment> returnValue = null;
                returnValue = this.fpJobChangeAgentLogic.SELECT_DOWN_EQP_DEF(wstep, ref handled, returnValue);
                return returnValue;
            }
            public override bool IsNeedUpStep(Mozart.SeePlan.Simulation.WorkStep ws)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.IS_NEED_UP_STEP_DEF(ws, ref handled, returnValue);
                return returnValue;
            }
            public override bool CanUp(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.WorkStep wstep)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpJobChangeAgentLogic.CAN_UP_DEF(aeqp, wstep, ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// JobChangeEvents execution control implementation
        /// </summary>
        internal partial class JobChangeEventsImpl : Mozart.SeePlan.Simulation.JobChangeEvents
        {
        }
        /// <summary>
        /// Init execution control implementation
        /// </summary>
        internal partial class InitImpl : Mozart.SeePlan.Optimization.InitializeOptimizerControl
        {
        }
        /// <summary>
        /// Run execution control implementation
        /// </summary>
        internal partial class RunImpl : Mozart.SeePlan.Optimization.RunOptimizerControl
        {
        }
        /// <summary>
        /// SimInit execution control implementation
        /// </summary>
        internal partial class SimInitImpl : SAPS.Planning.SimInit
        {
            private SAPS.Planning.SimulationPredefines fpSimulationPredefines = new SAPS.Planning.SimulationPredefines();
            public override SAPS.Planning.DataModel.SAPSLot OnCreateLot(SAPS.Planning.DataModel.SAPSWipInfo info, bool isWip)
            {
                bool handled = false;
                SAPS.Planning.DataModel.SAPSLot returnValue = null;
                returnValue = this.fpSimulationPredefines.CREATE_LOT_DEF(info, isWip, ref handled, returnValue);
                return returnValue;
            }
            public override int OnGetLotSize(SAPS.Planning.DataModel.SAPSProduct prod)
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpSimulationPredefines.GET_LOT_SIZE_DEF(prod, ref handled, returnValue);
                return returnValue;
            }
            public override double OnGetReleaseTerm(int lotSize)
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpSimulationPredefines.GET_RELEASE_TERM_DEF(lotSize, ref handled, returnValue);
                return returnValue;
            }
            public override System.DateTime OnGetStateTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                System.DateTime returnValue = default(System.DateTime);
                returnValue = this.fpSimulationPredefines.GET_STATE_TIME_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override string OnGetReleaseTimeOption()
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpSimulationPredefines.GET_RELEASE_TIME_OPTION_DEF(ref handled, returnValue);
                return returnValue;
            }
            public override int OnGetReleaseTimeBuffer()
            {
                bool handled = false;
                int returnValue = 0;
                returnValue = this.fpSimulationPredefines.GET_RELEASE_TIME_BUFFER_DEF(ref handled, returnValue);
                return returnValue;
            }
        }
        /// <summary>
        /// SimRun execution control implementation
        /// </summary>
        internal partial class SimRunImpl : SAPS.Planning.SimRun
        {
            private SAPS.Planning.SimulationPredefines fpSimulationPredefines = new SAPS.Planning.SimulationPredefines();
            public override double OnGetTactTime()
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpSimulationPredefines.GET_TACT_TIME_DEF(ref handled, returnValue);
                return returnValue;
            }
            public override double OnGetProcTime()
            {
                bool handled = false;
                double returnValue = 0D;
                returnValue = this.fpSimulationPredefines.GET_PROC_TIME_DEF(ref handled, returnValue);
                return returnValue;
            }
            public override bool OnIsPartProdSplit()
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSimulationPredefines.IS_PART_PROD_SPLIT_DEF(ref handled, returnValue);
                return returnValue;
            }
            public override bool OnIsPartProdMerge()
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSimulationPredefines.IS_PART_PROD_MERGE_DEF(ref handled, returnValue);
                return returnValue;
            }
            public override string OnGetNotFoundDestOption(Mozart.SeePlan.Simulation.DispatchingAgent da, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpSimulationPredefines.GET_NOT_FOUNT_DEST_OPTION_DEF(da, hb, ref handled, returnValue);
                return returnValue;
            }
            public override string OnGetSetupOption(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                string returnValue = null;
                returnValue = this.fpSimulationPredefines.GET_SETUP_OPTION_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override Mozart.Simulation.Engine.Time OnGetEqpGroupSetupTime(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                Mozart.Simulation.Engine.Time returnValue = default(Mozart.Simulation.Engine.Time);
                returnValue = this.fpSimulationPredefines.GET_EQP_GROUP_SETUP_TIME_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override bool OnIsNeedSetup(Mozart.SeePlan.Simulation.AoEquipment aeqp, Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSimulationPredefines.IS_NEED_SETUP_DEF(aeqp, hb, ref handled, returnValue);
                return returnValue;
            }
            public override bool OnUseSimpleEqpArrange(Mozart.SeePlan.Simulation.IHandlingBatch hb)
            {
                bool handled = false;
                bool returnValue = false;
                returnValue = this.fpSimulationPredefines.USE_SIMPLE_EQP_ARRANGE_DEF(hb, ref handled, returnValue);
                return returnValue;
            }
        }
        internal class StatSheetsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                SAPS.Planning.Scheduling_Module.StatSheetsImpl baseImpl = new SAPS.Planning.Scheduling_Module.StatSheetsImpl();
                baseImpl.Configure();
            }
        }
        internal class WeightsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Simulation.WeightMethod>(this.fpWeights.DUE_DATE);
                Mozart.Task.Execution.ServiceLocator.RegisterInstance<Mozart.SeePlan.Simulation.WeightMethod>(this.fpWeights.FIFO);
            }
            private SAPS.Planning.Logic.Simulation.Weights fpWeights = new SAPS.Planning.Logic.Simulation.Weights();
        }
        internal class CustomEventsImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
                SAPS.Planning.Scheduling_Module.CustomEventsImpl baseImpl = new SAPS.Planning.Scheduling_Module.CustomEventsImpl();
                baseImpl.Configure();
            }
        }
        internal class FiltersImpl : IModelConfigurable
        {
            public virtual void Configure()
            {
            }
        }
    }
}
