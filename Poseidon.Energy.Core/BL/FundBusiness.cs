﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poseidon.Energy.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.IDAL;

    /// <summary>
    /// 经费统计业务类
    /// </summary>
    public class FundBusiness : AbsctractBusiness<Fund>
    {
        #region Constructor
        /// <summary>
        /// 人数统计业务类
        /// </summary>
        public FundBusiness()
        {
            this.baseDal = RepositoryFactory<IFundRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 删除经费统计
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override bool Delete(Fund entity)
        {
            // delete the records
            var repo = RepositoryFactory<IFundRecordRepository>.Instance;
            repo.DeleteMany<string>("fundId", entity.Id);

            return base.Delete(entity);
        }
        #endregion //Method
    }
}