using IMEX.Core.Models;
using System;
using System.Collections.Generic;

namespace MEDLATEC2019.Entity
{
    /// <summary>
    /// feedback
    /// </summary>
    public class ModFeedbackEntity : EntityBase
    {
        #region Autogen by IMEX

        [DataInfo]
        public override int ID { get; set; }

        [DataInfo]
        public string UnitCode { get; set; }

        [DataInfo]
        public override string Name { get; set; }

        [DataInfo]
        public string Phone { get; set; }

        [DataInfo]
        public bool Gender { get; set; }

        [DataInfo]
        public DateTime BirthDate { get; set; }

        [DataInfo]
        public int Point { get; set; }

        [DataInfo]
        public string ContentFeedback { get; set; }// nội dung 

        #endregion Autogen by IMEX

    }
    public class ModFeedbackService : ServiceBase<ModFeedbackEntity>
    {
        #region Autogen by RDV

        public ModFeedbackService()
            : base("[Mod_Feedback]")
        {
            DBConfigKey = "DBConnection2";
        }

        private static ModFeedbackService _instance;
        public static ModFeedbackService Instance => _instance ?? (_instance = new ModFeedbackService());

        #endregion Autogen by RDV

      
    }
}