#pragma checksum "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d7c224db024aa765ecf5df4a9714a45d784434ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\_ViewImports.cshtml"
using GeorgeSite.Models.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\_ViewImports.cshtml"
using GeorgeSite.Models.Entities;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d7c224db024aa765ecf5df4a9714a45d784434ca", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b151b767be0376ea1323ff7c11b4a2018d924c0d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GeorgeSite.Models.Entities.Item>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
  
    ViewData["Title"] = "Search results";

#line default
#line hidden
            WriteLiteral("\r\n<h1 class=\"text-center\">search results for \' ");
#line 6 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
                                        Write(ViewBag.search_term);

#line default
#line hidden
            WriteLiteral(" \'</h1>\r\n\r\n\r\n<div class=\"card-group\">\r\n");
#line 10 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            WriteLiteral("        <div class=\"card border-info\" style=\"width: 18rem;\">\r\n");
            WriteLiteral("            <div class=\"card-body\">\r\n                <p class=\"card-text text-right\">R ");
#line 15 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
                                             Write(item.Price);

#line default
#line hidden
            WriteLiteral("</p>\r\n                <p class=\"card-text font-weight-bold\">");
#line 16 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
                                                 Write(item.Name);

#line default
#line hidden
            WriteLiteral("</p>\r\n                <p class=\"card-text\">");
#line 17 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
                                Write(item.Description);

#line default
#line hidden
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n");
#line 20 "C:\Users\Melusi Mgwenya\source\repos\MELXX\GeorgeSite\GeorgeSite\Views\Home\Search.cshtml"
    }

#line default
#line hidden
            WriteLiteral("</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GeorgeSite.Models.Entities.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
