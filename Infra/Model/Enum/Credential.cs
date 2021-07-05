using System.ComponentModel;

namespace Infra.Model.Enum
{
    public enum Credential
    {
        [Description("Acesso DEV")]
        Master,
        [Description("Acesso Total")]
        Total,
        #region USER
        [Description("Acessar Usuários")]
        AccessUserForm,
        [Description("Criar Usuário")]
        CreateUser,
        [Description("Alterar Usuário")]
        AlterUser,
        [Description("Excluir Usuário")]
        DeleteUser,
        #endregion
        #region MATERIAL
        [Description("Acessar Materiais")]
        AccessMaterial,
        [Description("Criar Material")]
        CreateMaterial,
        [Description("Alterar Material")]
        AlterMaterial,
        [Description("Excluir Material")]
        DeleteMaterial,
        #endregion
        #region MILITAR
        [Description("Acessar Militares")]
        AccessMilitares,
        [Description("Criar Militar")]
        CreateMilitar,
        [Description("Alterar Militar")]
        AlterMilitar,
        [Description("Excluir Militar")]
        DeleteMilitar,
        #endregion
        #region CAUTELA
        [Description("Acessar Cautelas")]
        AccessCautela,
        [Description("Realizar Cautelas")]
        PerformCautela,
        [Description("Devolver Cautelas")]
        ReturnCautela,
        #endregion
        #region EXPORTS
        [Description("Exportar Relatório")]
        ExportReport,
        [Description("Exportar Relatório Full")]
        ExportFullReport,
        [Description("Backup do Banco de Dados")]
        BackupDatabase
        #endregion
    }
}
