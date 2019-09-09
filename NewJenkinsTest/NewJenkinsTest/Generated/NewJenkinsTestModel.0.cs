//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a mozart.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Mozart.Task.Execution.Persists;
using NewJenkinsTest.Inputs;
using Mozart.DataActions;
using NewJenkinsTest.Outputs;

namespace NewJenkinsTest
{
    
    /// <summary>
    /// Mozart task execution parameters class
    /// </summary>
    public partial class GlobalParameters : SAPS.Planning.SAPSGlobalParameters
    {
        public static GlobalParameters Instance { get { return InputMart.Instance.GlobalParameters; }}
    }
    /// <summary>
    /// Mozart task execution parameters class
    /// </summary>
    public partial class ConfigParameters : SAPS.Planning.SAPSConfigParameters
    {
    }
    /// <summary>
    /// Input data context class
    /// </summary>
    public partial class InputMart : SAPS.Planning.SAPSInputMart
    {
        public static new InputMart Instance { get { return (InputMart)ServiceLocator.Resolve<InputRepository> (); }}
        public new EntityTable<EQUIPMENT> EQUIPMENT
        {
            get
            {
                return this.GetTable<EQUIPMENT>();
            }
        }
        public new EntityTable<LINE_INFO> LINE_INFO
        {
            get
            {
                return this.GetTable<LINE_INFO>();
            }
        }
        public new EntityTable<PRODUCT> PRODUCT
        {
            get
            {
                return this.GetTable<PRODUCT>();
            }
        }
        public new EntityTable<PROCESS> PROCESS
        {
            get
            {
                return this.GetTable<PROCESS>();
            }
        }
        public new EntityTable<PRODUCT_ROUTE> PRODUCT_ROUTE
        {
            get
            {
                return this.GetTable<PRODUCT_ROUTE>();
            }
        }
        public new EntityTable<STD_STEP_INFO> STD_STEP_INFO
        {
            get
            {
                return this.GetTable<STD_STEP_INFO>();
            }
        }
        public new EntityTable<STEP_ROUTE> STEP_ROUTE
        {
            get
            {
                return this.GetTable<STEP_ROUTE>();
            }
        }
        private EntityView<STEP_ROUTE> _STEP_ROUTEView;
        /// <summary>
        /// Key: PROCESS_ID
        /// </summary>
        public new EntityView<STEP_ROUTE> STEP_ROUTEView
        {
            get
            {
                if ((this._STEP_ROUTEView == null))
                {
                    this._STEP_ROUTEView = this.CreateView<STEP_ROUTE>(this.STEP_ROUTE, null, "PROCESS_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._STEP_ROUTEView;
            }
        }
        public new EntityTable<DEMAND> DEMAND
        {
            get
            {
                return this.GetTable<DEMAND>();
            }
        }
        private EntityView<DEMAND> _DEMANDView;
        /// <summary>
        /// Key: PRODUCT_ID
        /// </summary>
        public new EntityView<DEMAND> DEMANDView
        {
            get
            {
                if ((this._DEMANDView == null))
                {
                    this._DEMANDView = this.CreateView<DEMAND>(this.DEMAND, null, "PRODUCT_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._DEMANDView;
            }
        }
        public new EntityTable<WIP> WIP
        {
            get
            {
                return this.GetTable<WIP>();
            }
        }
        public new EntityTable<STEP_TAT> STEP_TAT
        {
            get
            {
                return this.GetTable<STEP_TAT>();
            }
        }
        private EntityView<STEP_TAT> _STEP_TATView;
        /// <summary>
        /// Keys: PRODUCT_ID, STEP_ID
        /// </summary>
        public new EntityView<STEP_TAT> STEP_TATView
        {
            get
            {
                if ((this._STEP_TATView == null))
                {
                    this._STEP_TATView = this.CreateView<STEP_TAT>(this.STEP_TAT, null, "PRODUCT_ID,STEP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._STEP_TATView;
            }
        }
        public new EntityTable<STEP_YIELD> STEP_YIELD
        {
            get
            {
                return this.GetTable<STEP_YIELD>();
            }
        }
        private EntityView<STEP_YIELD> _STEP_YIELDView;
        /// <summary>
        /// Keys: PRODUCT_ID, STEP_ID
        /// </summary>
        public new EntityView<STEP_YIELD> STEP_YIELDView
        {
            get
            {
                if ((this._STEP_YIELDView == null))
                {
                    this._STEP_YIELDView = this.CreateView<STEP_YIELD>(this.STEP_YIELD, null, "PRODUCT_ID,STEP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._STEP_YIELDView;
            }
        }
        public new EntityTable<EQP_ARRANGE> EQP_ARRANGE
        {
            get
            {
                return this.GetTable<EQP_ARRANGE>();
            }
        }
        private EntityView<EQP_ARRANGE> _EQP_ARRANGEStepView;
        /// <summary>
        /// Keys: PRODUCT_ID, PROCESS_ID, STEP_ID
        /// </summary>
        public new EntityView<EQP_ARRANGE> EQP_ARRANGEStepView
        {
            get
            {
                if ((this._EQP_ARRANGEStepView == null))
                {
                    this._EQP_ARRANGEStepView = this.CreateView<EQP_ARRANGE>(this.EQP_ARRANGE, null, "PRODUCT_ID,PROCESS_ID,STEP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._EQP_ARRANGEStepView;
            }
        }
        private EntityView<EQP_ARRANGE> _EQP_ARRANGEEqpView;
        /// <summary>
        /// Key: EQP_ID
        /// </summary>
        public new EntityView<EQP_ARRANGE> EQP_ARRANGEEqpView
        {
            get
            {
                if ((this._EQP_ARRANGEEqpView == null))
                {
                    this._EQP_ARRANGEEqpView = this.CreateView<EQP_ARRANGE>(this.EQP_ARRANGE, null, "EQP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._EQP_ARRANGEEqpView;
            }
        }
        private EntityView<EQP_ARRANGE> _EQP_ARRANGETimeView;
        /// <summary>
        /// Keys: PRODUCT_ID, PROCESS_ID, STEP_ID, EQP_ID
        /// </summary>
        public new EntityView<EQP_ARRANGE> EQP_ARRANGETimeView
        {
            get
            {
                if ((this._EQP_ARRANGETimeView == null))
                {
                    this._EQP_ARRANGETimeView = this.CreateView<EQP_ARRANGE>(this.EQP_ARRANGE, null, "PRODUCT_ID,PROCESS_ID,STEP_ID,EQP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._EQP_ARRANGETimeView;
            }
        }
        public new EntityTable<PRESET_INFO> PRESET_INFO
        {
            get
            {
                return this.GetTable<PRESET_INFO>();
            }
        }
        public new EntityTable<EXECUTION_OPTION_CONFIG> EXECUTION_OPTION_CONFIG
        {
            get
            {
                return this.GetTable<EXECUTION_OPTION_CONFIG>();
            }
        }
        private EntityView<EXECUTION_OPTION_CONFIG> _EXECUTION_OPTION_CONFIGView;
        /// <summary>
        /// Key: OPTION_ID
        /// </summary>
        public new EntityView<EXECUTION_OPTION_CONFIG> EXECUTION_OPTION_CONFIGView
        {
            get
            {
                if ((this._EXECUTION_OPTION_CONFIGView == null))
                {
                    this._EXECUTION_OPTION_CONFIGView = this.CreateView<EXECUTION_OPTION_CONFIG>(this.EXECUTION_OPTION_CONFIG, null, "OPTION_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._EXECUTION_OPTION_CONFIGView;
            }
        }
        public new EntityTable<PM_PLAN> PM_PLAN
        {
            get
            {
                return this.GetTable<PM_PLAN>();
            }
        }
        private EntityView<PM_PLAN> _PM_PLANView;
        /// <summary>
        /// Key: STATE_CODE
        /// </summary>
        public new EntityView<PM_PLAN> PM_PLANView
        {
            get
            {
                if ((this._PM_PLANView == null))
                {
                    this._PM_PLANView = this.CreateView<PM_PLAN>(this.PM_PLAN, null, "STATE_CODE", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._PM_PLANView;
            }
        }
        public new EntityTable<FACTORY_BREAK> FACTORY_BREAK
        {
            get
            {
                return this.GetTable<FACTORY_BREAK>();
            }
        }
        private EntityView<FACTORY_BREAK> _FACTORY_BREAKView;
        /// <summary>
        /// Key: STATE_CODE
        /// </summary>
        public new EntityView<FACTORY_BREAK> FACTORY_BREAKView
        {
            get
            {
                if ((this._FACTORY_BREAKView == null))
                {
                    this._FACTORY_BREAKView = this.CreateView<FACTORY_BREAK>(this.FACTORY_BREAK, null, "STATE_CODE", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._FACTORY_BREAKView;
            }
        }
        public new EntityTable<SETUP_TIME> SETUP_TIME
        {
            get
            {
                return this.GetTable<SETUP_TIME>();
            }
        }
        private EntityView<SETUP_TIME> _SETUP_TIMEView;
        /// <summary>
        /// Keys: SITE_ID, LINE_ID, EQP_GROUP, STEP_ID
        /// </summary>
        public new EntityView<SETUP_TIME> SETUP_TIMEView
        {
            get
            {
                if ((this._SETUP_TIMEView == null))
                {
                    this._SETUP_TIMEView = this.CreateView<SETUP_TIME>(this.SETUP_TIME, null, "SITE_ID,LINE_ID,EQP_GROUP,STEP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SETUP_TIMEView;
            }
        }
        public new EntityTable<SIMPLE_EQP_ARRANGE> SIMPLE_EQP_ARRANGE
        {
            get
            {
                return this.GetTable<SIMPLE_EQP_ARRANGE>();
            }
        }
        private EntityView<SIMPLE_EQP_ARRANGE> _SIMPLE_EQP_ARRANGEStepView;
        /// <summary>
        /// Key: STEP_ID
        /// </summary>
        public new EntityView<SIMPLE_EQP_ARRANGE> SIMPLE_EQP_ARRANGEStepView
        {
            get
            {
                if ((this._SIMPLE_EQP_ARRANGEStepView == null))
                {
                    this._SIMPLE_EQP_ARRANGEStepView = this.CreateView<SIMPLE_EQP_ARRANGE>(this.SIMPLE_EQP_ARRANGE, null, "STEP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SIMPLE_EQP_ARRANGEStepView;
            }
        }
        private EntityView<SIMPLE_EQP_ARRANGE> _SIMPLE_EQP_ARRANGETimeView;
        /// <summary>
        /// Keys: STEP_ID, EQP_ID
        /// </summary>
        public new EntityView<SIMPLE_EQP_ARRANGE> SIMPLE_EQP_ARRANGETimeView
        {
            get
            {
                if ((this._SIMPLE_EQP_ARRANGETimeView == null))
                {
                    this._SIMPLE_EQP_ARRANGETimeView = this.CreateView<SIMPLE_EQP_ARRANGE>(this.SIMPLE_EQP_ARRANGE, null, "STEP_ID,EQP_ID", Mozart.Data.Entity.IndexType.Hashtable);
                }
                return this._SIMPLE_EQP_ARRANGETimeView;
            }
        }
        public new EntityTable<FIRM_PLAN> FIRM_PLAN
        {
            get
            {
                return this.GetTable<FIRM_PLAN>();
            }
        }
        public new EntityTable<REPLINISH_PLAN> REPLINISH_PLAN
        {
            get
            {
                return this.GetTable<REPLINISH_PLAN>();
            }
        }
        public new EntityTable<MATERIAL> MATERIAL
        {
            get
            {
                return this.GetTable<MATERIAL>();
            }
        }
        public new EntityTable<MATERIAL_BOM> MATERIAL_BOM
        {
            get
            {
                return this.GetTable<MATERIAL_BOM>();
            }
        }
        public new EntityTable<OUT_STOCK> OUT_STOCK
        {
            get
            {
                return this.GetTable<OUT_STOCK>();
            }
        }
        protected override void ClearMyModel()
        {
            base.ClearMyModel();
            this.DisposeIfNeeds(this._STEP_ROUTEView);
            this._STEP_ROUTEView = null;
            this.DisposeIfNeeds(this._DEMANDView);
            this._DEMANDView = null;
            this.DisposeIfNeeds(this._STEP_TATView);
            this._STEP_TATView = null;
            this.DisposeIfNeeds(this._STEP_YIELDView);
            this._STEP_YIELDView = null;
            this.DisposeIfNeeds(this._EQP_ARRANGEStepView);
            this._EQP_ARRANGEStepView = null;
            this.DisposeIfNeeds(this._EQP_ARRANGEEqpView);
            this._EQP_ARRANGEEqpView = null;
            this.DisposeIfNeeds(this._EQP_ARRANGETimeView);
            this._EQP_ARRANGETimeView = null;
            this.DisposeIfNeeds(this._EXECUTION_OPTION_CONFIGView);
            this._EXECUTION_OPTION_CONFIGView = null;
            this.DisposeIfNeeds(this._PM_PLANView);
            this._PM_PLANView = null;
            this.DisposeIfNeeds(this._FACTORY_BREAKView);
            this._FACTORY_BREAKView = null;
            this.DisposeIfNeeds(this._SETUP_TIMEView);
            this._SETUP_TIMEView = null;
            this.DisposeIfNeeds(this._SIMPLE_EQP_ARRANGEStepView);
            this._SIMPLE_EQP_ARRANGEStepView = null;
            this.DisposeIfNeeds(this._SIMPLE_EQP_ARRANGETimeView);
            this._SIMPLE_EQP_ARRANGETimeView = null;
        }
        /// <summary>
        /// Global Pararamters
        /// </summary>
        public new GlobalParameters GlobalParameters
        {
            get
            {
                return ((GlobalParameters)(this.GlobalParametersCore));
            }
        }
        public new ConfigParameters GetConfigParameters(string key)
        {
            return this.GetParameters<ConfigParameters>(key);
        }
    }
    /// <summary>
    /// Input data context class
    /// </summary>
    public partial class TempMart : SAPS.Planning.SAPSTempMart
    {
        public static new TempMart Instance { get { return (TempMart)ServiceLocator.Resolve<TempRepository> (); }}
    }
    /// <summary>
    /// Output data context class
    /// </summary>
    public partial class OutputMart : SAPS.Planning.SAPSOutputMart
    {
        public static new OutputMart Instance { get { return (OutputMart)ServiceLocator.Resolve<OutputRepository> (); }}
        public new IEntityWriter<STEP_TARGET> STEP_TARGET
        {
            get
            {
                return this.GetTable<STEP_TARGET>();
            }
        }
        public new IEntityWriter<PEG_HISTORY> PEG_HISTORY
        {
            get
            {
                return this.GetTable<PEG_HISTORY>();
            }
        }
        public new IEntityWriter<UNPEG_HISTORY> UNPEG_HISTORY
        {
            get
            {
                return this.GetTable<UNPEG_HISTORY>();
            }
        }
        public new IEntityWriter<ERROR_LOG> ERROR_LOG
        {
            get
            {
                return this.GetTable<ERROR_LOG>();
            }
        }
        public new IEntityWriter<EQP_DISPATCH_LOG> EQP_DISPATCH_LOG
        {
            get
            {
                return this.GetTable<EQP_DISPATCH_LOG>();
            }
        }
        public new IEntityWriter<EQP_PLAN> EQP_PLAN
        {
            get
            {
                return this.GetTable<EQP_PLAN>();
            }
        }
        public new IEntityWriter<LOAD_STAT> LOAD_STAT
        {
            get
            {
                return this.GetTable<LOAD_STAT>();
            }
        }
        public new IEntityWriter<LOAD_HISTORY> LOAD_HISTORY
        {
            get
            {
                return this.GetTable<LOAD_HISTORY>();
            }
        }
        public new IEntityWriter<INPUT_PLAN> INPUT_PLAN
        {
            get
            {
                return this.GetTable<INPUT_PLAN>();
            }
        }
        public new IEntityWriter<RELEASE_HISTORY> RELEASE_HISTORY
        {
            get
            {
                return this.GetTable<RELEASE_HISTORY>();
            }
        }
        public new IEntityWriter<STEP_WIP> STEP_WIP
        {
            get
            {
                return this.GetTable<STEP_WIP>();
            }
        }
        public new IEntityWriter<UNKIT_REMAIN_WIPLOG> UNKIT_REMAIN_WIPLOG
        {
            get
            {
                return this.GetTable<UNKIT_REMAIN_WIPLOG>();
            }
        }
        public new IEntityWriter<MERGE_WIPLOG> MERGE_WIPLOG
        {
            get
            {
                return this.GetTable<MERGE_WIPLOG>();
            }
        }
        public new IEntityWriter<MATERIAL_HISTORY> MATERIAL_HISTORY
        {
            get
            {
                return this.GetTable<MATERIAL_HISTORY>();
            }
        }
    }
}