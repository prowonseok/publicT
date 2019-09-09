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
using SAPS.Planning.DataModel;

namespace NewJenkinsTest.DataModel
{
    
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSStdStep : SAPS.Planning.DataModel.SAPSStdStep
    {
        public NewJenkinsTestSAPSStdStep()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSStep : SAPS.Planning.DataModel.SAPSStep
    {
        public NewJenkinsTestSAPSStep()
        {
        }
        public NewJenkinsTestSAPSStep(string id) : 
                base(id)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSWipInfo : SAPS.Planning.DataModel.SAPSWipInfo
    {
        public NewJenkinsTestSAPSWipInfo()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSProcess : SAPS.Planning.DataModel.SAPSProcess
    {
        public NewJenkinsTestSAPSProcess()
        {
        }
        public NewJenkinsTestSAPSProcess(string processID) : 
                base(processID)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSProduct : SAPS.Planning.DataModel.SAPSProduct
    {
        public NewJenkinsTestSAPSProduct()
        {
        }
        public NewJenkinsTestSAPSProduct(string prodCode, Mozart.SeePlan.General.DataModel.Process proc) : 
                base(prodCode, proc)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSInTarget : SAPS.Planning.DataModel.SAPSInTarget
    {
        public NewJenkinsTestSAPSInTarget()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSWeightPreset : SAPS.Planning.DataModel.SAPSWeightPreset
    {
        public NewJenkinsTestSAPSWeightPreset(string name) : 
                base(name)
        {
        }
        public NewJenkinsTestSAPSWeightPreset()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSLotBatch : SAPS.Planning.DataModel.SAPSLotBatch
    {
        public NewJenkinsTestSAPSLotBatch()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSLot : SAPS.Planning.DataModel.SAPSLot
    {
        public NewJenkinsTestSAPSLot()
        {
        }
        public NewJenkinsTestSAPSLot(Mozart.SeePlan.General.DataModel.IWipInfo wip) : 
                base(wip)
        {
        }
        public NewJenkinsTestSAPSLot(string lotID, Mozart.SeePlan.General.DataModel.Product prod, string lineID) : 
                base(lotID, prod, lineID)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSEqp : SAPS.Planning.DataModel.SAPSEqp
    {
        public NewJenkinsTestSAPSEqp()
        {
        }
        public NewJenkinsTestSAPSEqp(string eqpID, System.DateTime startTime, System.DateTime endTime, string simType) : 
                base(eqpID, startTime, endTime, simType)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSPlanInfo : SAPS.Planning.DataModel.SAPSPlanInfo
    {
        public NewJenkinsTestSAPSPlanInfo(Mozart.SeePlan.General.DataModel.GeneralStep task) : 
                base(task)
        {
        }
        public NewJenkinsTestSAPSPlanInfo()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSMoMaster : SAPS.Planning.DataModel.SAPSMoMaster
    {
        public NewJenkinsTestSAPSMoMaster()
        {
        }
        public NewJenkinsTestSAPSMoMaster(Mozart.SeePlan.General.DataModel.Product prod, string customer) : 
                base(prod, customer)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSMoPlan : SAPS.Planning.DataModel.SAPSMoPlan
    {
        public NewJenkinsTestSAPSMoPlan()
        {
        }
        public NewJenkinsTestSAPSMoPlan(Mozart.SeePlan.General.Pegging.GeneralMoMaster mm, float qty, System.DateTime dueDate) : 
                base(mm, qty, dueDate)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSPegPart : SAPS.Planning.DataModel.SAPSPegPart
    {
        public NewJenkinsTestSAPSPegPart()
        {
        }
        public NewJenkinsTestSAPSPegPart(Mozart.SeePlan.General.Pegging.GeneralMoMaster moMaster, Mozart.SeePlan.General.DataModel.Product product) : 
                base(moMaster, product)
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSPegTarget : SAPS.Planning.DataModel.SAPSPegTarget
    {
        public NewJenkinsTestSAPSPegTarget(Mozart.SeePlan.General.Pegging.GeneralPegPart pp, Mozart.SeePlan.General.Pegging.GeneralMoPlan mp) : 
                base(pp, mp)
        {
        }
        public NewJenkinsTestSAPSPegTarget()
        {
        }
    }
    [System.SerializableAttribute()]
    public partial class NewJenkinsTestSAPSPlanWip : SAPS.Planning.DataModel.SAPSPlanWip
    {
        public NewJenkinsTestSAPSPlanWip()
        {
        }
        public NewJenkinsTestSAPSPlanWip(Mozart.SeePlan.General.DataModel.IWipInfo wip) : 
                base(wip)
        {
        }
    }
}
