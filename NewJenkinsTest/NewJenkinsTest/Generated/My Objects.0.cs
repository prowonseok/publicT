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

namespace NewJenkinsTest
{
    
    /// <summary>
    /// Type bindings registration
    /// </summary>
    public partial class MyTypeRegistrar : ModelConfiguratorBase
    {
        protected override void Configure()
        {
            base.Configure();
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSStdStep), typeof(NewJenkinsTestSAPSStdStep), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSStep), typeof(NewJenkinsTestSAPSStep), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSWipInfo), typeof(NewJenkinsTestSAPSWipInfo), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSProcess), typeof(NewJenkinsTestSAPSProcess), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSProduct), typeof(NewJenkinsTestSAPSProduct), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSInTarget), typeof(NewJenkinsTestSAPSInTarget), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSWeightPreset), typeof(NewJenkinsTestSAPSWeightPreset), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSLotBatch), typeof(NewJenkinsTestSAPSLotBatch), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSLot), typeof(NewJenkinsTestSAPSLot), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSEqp), typeof(NewJenkinsTestSAPSEqp), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSPlanInfo), typeof(NewJenkinsTestSAPSPlanInfo), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSMoMaster), typeof(NewJenkinsTestSAPSMoMaster), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSMoPlan), typeof(NewJenkinsTestSAPSMoPlan), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSPegPart), typeof(NewJenkinsTestSAPSPegPart), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSPegTarget), typeof(NewJenkinsTestSAPSPegTarget), null);
            Mozart.Task.Execution.TypeRegistry.Register(typeof(SAPS.Planning.DataModel.SAPSPlanWip), typeof(NewJenkinsTestSAPSPlanWip), null);
        }
    }
}
