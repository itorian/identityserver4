#pragma checksum "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "264e13ee96e973f9621bc2b41a83221ac6ad035d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Secure), @"mvc.1.0.view", @"/Views/Home/Secure.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Secure.cshtml", typeof(AspNetCore.Views_Home_Secure))]
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
#line 1 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"264e13ee96e973f9621bc2b41a83221ac6ad035d", @"/Views/Home/Secure.cshtml")]
    public class Views_Home_Secure : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
  
    ViewData["Title"] = "Secure Page";

#line default
#line hidden
            BeginContext(91, 25, true);
            WriteLiteral("\r\n<h2>Claims</h2>\r\n<dl>\r\n");
            EndContext();
#line 8 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
            BeginContext(164, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(177, 10, false);
#line 10 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
       Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(187, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(207, 11, false);
#line 11 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
       Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(218, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 12 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
    }

#line default
#line hidden
            BeginContext(232, 36, true);
            WriteLiteral("</dl>\r\n\r\n<h2>Properties</h2>\r\n<dl>\r\n");
            EndContext();
#line 17 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
            BeginContext(356, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(369, 8, false);
#line 19 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
       Write(prop.Key);

#line default
#line hidden
            EndContext();
            BeginContext(377, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(397, 10, false);
#line 20 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
       Write(prop.Value);

#line default
#line hidden
            EndContext();
            BeginContext(407, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 21 "C:\Users\abhimanyu\source\repos\knorish-tfs\MvcClientCore\Views\Home\Secure.cshtml"
    }

#line default
#line hidden
            BeginContext(421, 5, true);
            WriteLiteral("</dl>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591