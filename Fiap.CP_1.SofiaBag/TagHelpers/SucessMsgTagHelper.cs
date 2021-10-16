using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.TagHelpers
{
    public class SucessMsgTagHelper : TagHelper
    {
        public string Mensagem { get; set; }

        public string Class { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!String.IsNullOrEmpty(Mensagem))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", String.IsNullOrEmpty(Class)? "alert alert-success": Class);
                output.Content.SetContent(Mensagem);

            }
        }
    }
}
