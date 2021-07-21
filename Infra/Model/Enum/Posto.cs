using System.ComponentModel;

namespace Infra.Model.Enum
{
    public enum Posto
    {
        [Description("Aluno Soldado")]
        Aluno_Soldado,
        [Description("Soldado")]
        Soldado,
        [Description("Aluno Cabo")]
        Aluno_Cabo,
        [Description("Cabo")]
        Cabo,
        [Description("Aluno Sargento")]
        Aluno_Sargento,
        [Description("3º Sargento")]
        Sargento_3,
        [Description("2º Sargento")]
        Sargento_2,
        [Description("1º Sargento")]
        Sargento_1,
        [Description("Subtenente")]
        Subtenente,
        [Description("Aluno Oficial 1")]
        Aluno_Oficial_1,
        [Description("Aluno Oficial 2")]
        Aluno_Oficial_2,
        [Description("Aluno Oficial 3")]
        Aluno_Oficial_3,
        [Description("Aspirante a Oficial")]
        Aspirante_Oficial,
        [Description("2º Tenente")]
        Tenente_2,
        [Description("1º Tenente")]
        Tenente_1,
        [Description("Capitão")]
        Capitao,
        [Description("Major")]
        Major,
        [Description("Tenente-Coronel")]
        Tenente_Coronel,
        [Description("Coronel")]
        Coronel
    }
}
