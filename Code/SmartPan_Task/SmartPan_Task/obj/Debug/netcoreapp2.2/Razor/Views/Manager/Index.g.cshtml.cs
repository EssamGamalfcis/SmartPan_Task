#pragma checksum "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "151a34a4a692648a037e722d25836453e7b7960b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_Index), @"mvc.1.0.view", @"/Views/Manager/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Manager/Index.cshtml", typeof(AspNetCore.Views_Manager_Index))]
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
#line 1 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\_ViewImports.cshtml"
using SmartPan_Task;

#line default
#line hidden
#line 2 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\_ViewImports.cshtml"
using SmartPan_Task.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"151a34a4a692648a037e722d25836453e7b7960b", @"/Views/Manager/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a91cdf9c97d24e3cb1316e8660be907b554540d0", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Domain.EmployeesTasks>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Manager_Layout.cshtml";

#line default
#line hidden
            BeginContext(141, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(170, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "151a34a4a692648a037e722d25836453e7b7960b4003", async() => {
                BeginContext(193, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(207, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(300, 39, false);
#line 17 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Emp));

#line default
#line hidden
            EndContext();
            BeginContext(339, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(395, 40, false);
#line 20 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Task));

#line default
#line hidden
            EndContext();
            BeginContext(435, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(491, 46, false);
#line 23 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.TaskStatus));

#line default
#line hidden
            EndContext();
            BeginContext(537, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 29 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(655, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(704, 47, false);
#line 32 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Emp.EmpFname));

#line default
#line hidden
            EndContext();
            BeginContext(751, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(807, 48, false);
#line 35 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Task.TaskName));

#line default
#line hidden
            EndContext();
            BeginContext(855, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(911, 57, false);
#line 38 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TaskStatus.TaskStatus1));

#line default
#line hidden
            EndContext();
            BeginContext(968, 49, true);
            WriteLiteral("\r\n            </td>\r\n           \r\n        </tr>\r\n");
            EndContext();
#line 42 "C:\Users\essam\OneDrive\Desktop\SmartPan_Task-master\Code\SmartPan_Task\SmartPan_Task\Views\Manager\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1020, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Domain.EmployeesTasks>> Html { get; private set; }
    }
}
#pragma warning restore 1591
