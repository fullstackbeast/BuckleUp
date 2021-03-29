#pragma checksum "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7e27a89b910a38bfbd6e323ba8d3adac2c3f2edd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Quiz_Room), @"mvc.1.0.view", @"/Views/Quiz/Room.cshtml")]
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
#nullable restore
#line 1 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\_ViewImports.cshtml"
using BuckleUp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\_ViewImports.cshtml"
using BuckleUp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7e27a89b910a38bfbd6e323ba8d3adac2c3f2edd", @"/Views/Quiz/Room.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58f8023d9cec4dd70adf0e7d6cd9b511399ef549", @"/Views/_ViewImports.cshtml")]
    public class Views_Quiz_Room : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BuckleUp.Models.ViewModels.QuizRoomVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Start", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/quizhubhandler.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
 if(Model.IsQuizCreator){

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>Welcome</h1>\r\n    <br/>\r\n    <h1>Players:</h1>\r\n    <ul class=\"quizRoomPlayerList\">\r\n");
#nullable restore
#line 10 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
         foreach (var player in Model.Players)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>");
#nullable restore
#line 12 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
           Write(player.Player.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 13 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e27a89b910a38bfbd6e323ba8d3adac2c3f2edd5077", async() => {
                WriteLiteral("\r\n        <button class=\"btn btn-primary\">Start Quiz</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                           WriteLiteral(Model.Quiz.Link);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 18 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
}
else{

    if(Model.Quiz.status.Equals("unplayed")){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>You\'re playing as - ");
#nullable restore
#line 22 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                           Write(Model.PlayerUsername);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3>\r\n        <br/>\r\n        <h1>Other Players:</h1>\r\n        <ul class=\"quizRoomPlayerList\">\r\n");
#nullable restore
#line 26 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
             foreach (var player in Model.Players)
            {
                if (!player.Player.Name.Equals(Model.PlayerUsername))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
#nullable restore
#line 30 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                   Write(player.Player.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 31 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n");
            WriteLiteral("        <br/><br/>\r\n");
            WriteLiteral("        <p><i>Waiting for Quiz Creator To start </i></p>\r\n        <p><i>Please refresh every minute if you dont observe any activity on this page .</i></p>\r\n");
#nullable restore
#line 39 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
    }
    
    else if(Model.Quiz.status.Equals("playing")){

        if(Model.PlayerHasPlayed){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>Welcome Back ");
#nullable restore
#line 44 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                        Write(Model.PlayerUsername);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            <h1>You have taken this quiz</h1>\r\n            <h1>You scored ");
#nullable restore
#line 46 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
                      Write(Model.PlayerScore);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 47 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
        }
        else{
             

#line default
#line hidden
#nullable disable
            DefineSection("scriptss", async() => {
                WriteLiteral(@"
                <script>
                    (()=> {
                        let gamelink = location.pathname.split(""/"")[3];
                        let newLocation = `${location.origin}\\quiz\\play\\${gamelink}`;
                        location.href = newLocation;
                        //console.log(newLocation);
                    })();
                </script>
            ");
            }
            );
#nullable restore
#line 58 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
             
        }  
    }
    else if(Model.Quiz.status.Equals("played")){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>They have play this one o</h1>\r\n");
#nullable restore
#line 63 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
    }
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n     ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7e27a89b910a38bfbd6e323ba8d3adac2c3f2edd11052", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 68 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Quiz\Room.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BuckleUp.Models.ViewModels.QuizRoomVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
