#pragma checksum "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c7af479cdb6947fe51b46db6dccc7b7ce976bd3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cuadernoes_Index), @"mvc.1.0.view", @"/Views/Cuadernoes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c7af479cdb6947fe51b46db6dccc7b7ce976bd3", @"/Views/Cuadernoes/Index.cshtml")]
    public class Views_Cuadernoes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuickNotes.Models.Cuaderno>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCuaderno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Categoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Orden));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 31 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreCuaderno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Categoria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Color));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Orden));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1178, "\"", 1210, 1);
#nullable restore
#line 46 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
WriteAttributeValue("", 1193, item.IdCuarderno, 1193, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1263, "\"", 1295, 1);
#nullable restore
#line 47 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
WriteAttributeValue("", 1278, item.IdCuarderno, 1278, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1350, "\"", 1382, 1);
#nullable restore
#line 48 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
WriteAttributeValue("", 1365, item.IdCuarderno, 1365, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Cuadernoes\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuickNotes.Models.Cuaderno>> Html { get; private set; }
    }
}
#pragma warning restore 1591