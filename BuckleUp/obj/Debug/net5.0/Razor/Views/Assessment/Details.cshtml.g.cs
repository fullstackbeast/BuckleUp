#pragma checksum "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41f437cb5c3a243a62919498450637c0494b393d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Assessment_Details), @"mvc.1.0.view", @"/Views/Assessment/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41f437cb5c3a243a62919498450637c0494b393d", @"/Views/Assessment/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58f8023d9cec4dd70adf0e7d6cd9b511399ef549", @"/Views/_ViewImports.cshtml")]
    public class Views_Assessment_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BuckleUp.Models.ViewModels.AssessmentDetailsVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Assessment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TakeAssessment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
  
    Layout = "_DashboardLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
Write(Model.Assessment.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
 if(User.IsInRole("Teacher")){

    ViewBag.SideBar = "_TeacherSideBar";
    
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
     if(Model.Assessment.TeacherId.Equals(Model.TeacherId)){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>Questions</h1>\r\n");
#nullable restore
#line 15 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
         foreach(var question in Model.Assessment.Questions){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h4>");
#nullable restore
#line 16 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
           Write(question.QuestionText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <div style=\"margin-left: 20px; display: none;\">\r\n                <h5>");
#nullable restore
#line 18 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
               Write(question.Option1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <h5>");
#nullable restore
#line 19 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
               Write(question.Option2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <h5>");
#nullable restore
#line 20 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
               Write(question.Option3);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                <h5>");
#nullable restore
#line 21 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
               Write(question.Option4);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                \r\n");
#nullable restore
#line 23 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                  
                    string answer = question.GetType().GetProperty(question.CorrectOption).GetValue(question, null).ToString();
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <h5>Correct Answer: ");
#nullable restore
#line 28 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                               Write(answer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            \r\n            </div>   \r\n");
#nullable restore
#line 31 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br/>\r\n        <br/>\r\n        <h1>Students That Have Taken Assessment</h1>\r\n");
#nullable restore
#line 36 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
      
        List<StudentAssessment> takenstudentAssessments = Model.Assessment.StudentAssessments.Where(stdass => stdass.HasTaken).ToList();
        List<StudentAssessment> untakenstudentAssessments = Model.Assessment.StudentAssessments.Where(stdass => stdass.HasTaken == false).ToList();


#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table\">\r\n            <tr>\r\n                <th>Student Name</th>\r\n                <th>Score</th>\r\n            </tr>\r\n");
#nullable restore
#line 45 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
             foreach(var studentAssessment in takenstudentAssessments){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 47 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                   Write(studentAssessment.Student.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 47 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                                                             Write(studentAssessment.Student.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 48 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                   Write(studentAssessment.score);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 50 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
            WriteLiteral("        <br/>\r\n        <br/>\r\n        <h1>Students That Have Not Assessment</h1>\r\n");
#nullable restore
#line 58 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
         if(untakenstudentAssessments.Count() == 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h1>All students have taken this assessment</h1>\r\n");
#nullable restore
#line 60 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
        }
        else{

#line default
#line hidden
#nullable disable
            WriteLiteral("             <table class=\"table\">\r\n            <tr>\r\n                <th>Student Name</th>\r\n            </tr>\r\n");
#nullable restore
#line 66 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
             foreach(var studentAssessment in untakenstudentAssessments){

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 68 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                   Write(studentAssessment.Student.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 68 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                                                             Write(studentAssessment.Student.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 70 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 72 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
               
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
     
}

else if(User.IsInRole("Student")){

     ViewBag.SideBar = "_StudentSideBar";

    StudentAssessment studentAssessment = Model.Assessment.StudentAssessments.FirstOrDefault(stdass => stdass.StudentId.Equals(Model.StudentId));

    bool studentIsRegisteredForAssessment = studentAssessment != null;
    
    if(studentIsRegisteredForAssessment && (!studentAssessment.HasTaken)){

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41f437cb5c3a243a62919498450637c0494b393d11947", async() => {
                WriteLiteral("\r\n            <button class=\"btn btn-primary\">Take Assessment</button>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
              WriteLiteral(Model.Assessment.Id);

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
#line 90 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"

    }
    
    else if(studentIsRegisteredForAssessment && studentAssessment.HasTaken){

#line default
#line hidden
#nullable disable
            WriteLiteral("        <button class=\"btn btn-light\" disabled>Assessment Taken</button>\r\n        <h3>You have taken this assessment. </h3>\r\n        <h4>You scored ");
#nullable restore
#line 96 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                  Write(studentAssessment.score);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 96 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
                                             Write(Model.Assessment.Questions.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 97 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Assessment\Details.cshtml"
    }
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BuckleUp.Models.ViewModels.AssessmentDetailsVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
