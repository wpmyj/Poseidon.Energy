﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Energy.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.IDAL;

    /// <summary>
    /// 计划指标业务类
    /// </summary>
    public class PlanTargetBusiness : AbsctractBusiness<PlanTarget>
    {
        #region Constructor
        /// <summary>
        /// 计划指标业务类
        /// </summary>
        public PlanTargetBusiness()
        {
            this.baseDal = RepositoryFactory<IPlanTargetRepository>.Instance;
        }
        #endregion //Constructor
    }
}
