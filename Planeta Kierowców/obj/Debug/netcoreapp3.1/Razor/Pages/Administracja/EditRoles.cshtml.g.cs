#pragma checksum "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5836e4bc3c954b3d1aec3fe9c4cbd5db46ac3c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Planeta_Kierowców.Pages.Administracja.Pages_Administracja_EditRoles), @"mvc.1.0.razor-page", @"/Pages/Administracja/EditRoles.cshtml")]
namespace Planeta_Kierowców.Pages.Administracja
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\_ViewImports.cshtml"
using Planeta_Kierowców;

#line default
#line hidden
#line 3 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\_ViewImports.cshtml"
using Planeta_Kierowców.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5836e4bc3c954b3d1aec3fe9c4cbd5db46ac3c7", @"/Pages/Administracja/EditRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cf6e8ee52cf0e1e836187244298b04eadef2743", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Administracja_EditRoles : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info form-control text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
  
    ViewData["Title"] = "EditRoles";
    

#line default
#line hidden
#line 7 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
   var roles = RoleManager.Roles; 

#line default
#line hidden
            WriteLiteral("\r\n<h1>Lista ról</h1>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5836e4bc3c954b3d1aec3fe9c4cbd5db46ac3c74394", async() => {
                WriteLiteral("Utwórz nową rolę");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#line 13 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
 if (roles.Any())
{


    foreach (var role in roles)
    {

#line default
#line hidden
            WriteLiteral("        <div class=\"card mb-3\">\r\n            <div class=\"card-header\">\r\n                Id Roli: ");
#line 21 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
                    Write(role.Id);

#line default
#line hidden
            WriteLiteral("\r\n            </div>\r\n            <div class=\"card-body\">\r\n                <h5 class=\"card-title\">");
#line 24 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
                                  Write(role.Name);

#line default
#line hidden
            WriteLiteral("</h5>\r\n\r\n            </div>\r\n            <div class=\"card-footer\">\r\n                <a href=\"#\" class=\"btn btn-danger\">Edytuj</a>\r\n                <a href=\"#\" class=\"btn btn-danger\">Usuń</a>\r\n\r\n\r\n\r\n\r\n            </div>\r\n        </div>\r\n");
#line 36 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
    }
}
else
{

#line default
#line hidden
            WriteLiteral("    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            Brak ról do pokazania\r\n        </div>\r\n\r\n    </div>\r\n");
#line 46 "C:\Users\Majkii\source\repos\Planeta Kierowców\Planeta Kierowców\Pages\Administracja\EditRoles.cshtml"
}

#line default
#line hidden
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public RoleManager<IdentityRole> RoleManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Planeta_Kierowców.Pages.Administracja.EditRolesModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Planeta_Kierowców.Pages.Administracja.EditRolesModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Planeta_Kierowców.Pages.Administracja.EditRolesModel>)PageContext?.ViewData;
        public Planeta_Kierowców.Pages.Administracja.EditRolesModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
