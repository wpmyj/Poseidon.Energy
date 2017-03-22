﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Energy.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using Poseidon.Base.Framework;
    using Poseidon.Data;
    using Poseidon.Energy.Core.DL;
    using Poseidon.Energy.Core.IDAL;

    /// <summary>
    /// 能源结算记录数据访问类
    /// </summary>
    internal class SettlementRecordRepository : AbstractDALMongo<SettlementRecord>, ISettlementRecordRepository
    {
        #region Constructor
        /// <summary>
        /// 能源结算记录数据访问类
        /// </summary>
        public SettlementRecordRepository()
        {
            base.Init("energy_settlementRecord");
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// BsonDocument转实体对象
        /// </summary>
        /// <param name="doc">Bson文档</param>
        /// <returns></returns>
        protected override SettlementRecord DocToEntity(BsonDocument doc)
        {
            SettlementRecord entity = new SettlementRecord();
            entity.Id = doc["_id"].ToString();
            entity.SettlementId = doc["settlementId"].ToString();
            entity.DepartmentId = doc["departmentId"].ToString();
            entity.EnergyType = doc["energyType"].ToInt32();
            entity.UnitPrice = doc["unitPrice"].ToDecimal();
            entity.BeginQuantum = doc["beginQuantum"].ToDecimal();
            entity.BeginAmount = doc["beginAmount"].ToDecimal();
            entity.Quantum = doc["quantum"].ToDecimal();
            entity.Amount = doc["amount"].ToDecimal();
            entity.SchoolTakeAmount = doc["schoolTakeAmount"].ToDecimal();
            entity.SelfTakeAmount = doc["selfTakeAmount"].ToDecimal();

            var createBy = doc["createBy"].ToBsonDocument();
            entity.CreateBy = new UpdateStamp
            {
                UserId = createBy["userId"].ToString(),
                Name = createBy["name"].ToString(),
                Time = createBy["time"].ToLocalTime()
            };

            var updateBy = doc["updateBy"].ToBsonDocument();
            entity.UpdateBy = new UpdateStamp
            {
                UserId = updateBy["userId"].ToString(),
                Name = updateBy["name"].ToString(),
                Time = updateBy["time"].ToLocalTime()
            };

            entity.Remark = doc["remark"].ToString();
            entity.Status = doc["status"].ToInt32();

            return entity;
        }

        /// <summary>
        /// 实体对象转BsonDocument
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        protected override BsonDocument EntityToDoc(SettlementRecord entity)
        {
            BsonDocument doc = new BsonDocument
            {
                { "settlementId", entity.SettlementId },
                { "departmentId", entity.DepartmentId },
                { "energyType", entity.EnergyType },
                { "unitPrice", entity.UnitPrice },
                { "beginQuantum", entity.BeginQuantum },
                { "beginAmount", entity.BeginAmount },
                { "quantum", entity.Quantum },
                { "amount", entity.Amount },
                { "schoolTakeAmount", entity.SchoolTakeAmount },
                { "selfTakeAmount", entity.SelfTakeAmount },
                { "createBy", new BsonDocument {
                    { "userId", entity.CreateBy.UserId },
                    { "name", entity.CreateBy.Name },
                    { "time", entity.CreateBy.Time }
                }},
                { "updateBy", new BsonDocument {
                    { "userId", entity.UpdateBy.UserId },
                    { "name", entity.UpdateBy.Name },
                    { "time", entity.UpdateBy.Time }
                }},
                { "remark", entity.Remark },
                { "status", entity.Status }
            };

            return doc;
        }
        #endregion //Function
    }
}