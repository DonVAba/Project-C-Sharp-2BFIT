using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Application
{
    /// <summary>
    /// Enumération des 3 difficultés possibles pour un programme
    /// </summary>
    
    [DataContract]
    public enum Difficulte
    {
        [EnumMemberAttribute]
        DEBUTANT,

        [EnumMemberAttribute]
        INTERMEDIAIRE,

        [EnumMemberAttribute]
        EXPERT
    }
}
