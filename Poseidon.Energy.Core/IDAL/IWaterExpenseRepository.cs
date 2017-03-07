﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Energy.Core.IDAL
{
    using Poseidon.Base.Framework;
    using Poseidon.Energy.Core.DL;

    /// <summary>
    /// 水费支出数据访问接口
    /// </summary>
    internal interface IWaterExpenseRepository : IBaseDAL<WaterExpense>
    {
    }
}