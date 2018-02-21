using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Tools.Common.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    namespace ContatoAPI.Tools.Common.Types
    {
        public static class EnumHelperTest
        {
            public static string Description(this Enum value)
            {
                var field = value.GetType().GetRuntimeField(value.ToString());
                var attributes = field.GetCustomAttributes(false);
                dynamic displayAttribute = null;

                return displayAttribute?.Description ?? "erro";

                //return displayAttribute?.Description ?? "Descrição não encontrada!";

                //var field = value.GetType().GetRuntimeField(value.ToString());

                //var attributes = field.GetCustomAttributes(false);

                //dynamic displayAttribute = null;

                //if (attributes.Any())
                //{
                //    displayAttribute = attributes.ElementAt(0);
                //}

                //return displayAttribute?.Description ?? "Descrição não encontrada!";
            }

        }
    }





}
