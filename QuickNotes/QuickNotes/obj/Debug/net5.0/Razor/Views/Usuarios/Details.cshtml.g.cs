#pragma checksum "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20b24eea5ddbaebe28f59ba5be376bb22150645c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuarios_Details), @"mvc.1.0.view", @"/Views/Usuarios/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20b24eea5ddbaebe28f59ba5be376bb22150645c", @"/Views/Usuarios/Details.cshtml")]
    public class Views_Usuarios_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QuickNotes.Models.Usuario>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Usuario</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellido1));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Apellido2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Apellido2));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Correo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Correo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Contraseña));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Contraseña));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Activadad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.Activadad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TipoUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
       Write(Html.DisplayFor(model => model.TipoUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1699, "\"", 1730, 1);
#nullable restore
#line 58 "C:\Users\oscaa\Documents\Examen1_paradigmas-\QuickNotes\QuickNotes\Views\Usuarios\Details.cshtml"
WriteAttributeValue("", 1714, Model.IdUsuario, 1714, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QuickNotes.Models.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
