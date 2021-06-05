using IMEX.Core.Models;

namespace MEDLATEC2019.Entity
{
    /// <summary>
    /// feedback
    /// </summary>
    public class ModUnitEntity : EntityBase
    {
        #region Autogen by IMEX

        [DataInfo]
        public override int ID { get; set; }

        [DataInfo]
        public string Code { get; set; }

        [DataInfo]
        public override string Name { get; set; }

        [DataInfo]
        public string Hotline { get; set; }

        [DataInfo]
        public bool IsLock { get; set; }

        [DataInfo]
        public bool IsUnit { get; set; }
        #endregion Autogen by IMEX

    }
    public class ModUnitService : ServiceBase<ModUnitEntity>
    {
        #region Autogen by RDV

        public ModUnitService()
            : base("[CP_Role]")
        {
            DBConfigKey = "DBConnection2";
        }

        private static ModUnitService _instance;
        public static ModUnitService Instance => _instance ?? (_instance = new ModUnitService());

        #endregion Autogen by RDV

      
    }
}