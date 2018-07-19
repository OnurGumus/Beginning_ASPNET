using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Layout.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string emailTo = context.AllAttributes["mailTo"].Value.ToString();
            output.TagName = "a";
            output.Attributes.Add("href", "mailto:" + emailTo);
            output.Content.SetContent("Drop us a mail");
        }
    }

}
