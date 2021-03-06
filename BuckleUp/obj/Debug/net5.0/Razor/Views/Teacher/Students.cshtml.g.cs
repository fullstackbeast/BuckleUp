#pragma checksum "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d6b9da90b7f843d7ddb2c85e05aaa94bbadfb66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_Students), @"mvc.1.0.view", @"/Views/Teacher/Students.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d6b9da90b7f843d7ddb2c85e05aaa94bbadfb66", @"/Views/Teacher/Students.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58f8023d9cec4dd70adf0e7d6cd9b511399ef549", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_Students : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BuckleUp.Models.ViewModels.StudentListVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
  
    Layout = "_DashboardLayout";
    ViewBag.SideBar = "_TeacherSideBar";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<h4>Students</h4>

<table class=""table table-hover"">
    <thead class=""thead-dark"">
        <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Name</th>
            <th scope=""col"">Number Of Course</th>
            <th scope=""col"">Status</th>
            <th scope=""col""></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 22 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
         foreach (var student in Model.Students)
        {
            TeacherStudent teacherStudent = Model.Teacher.TeacherStudents.FirstOrDefault(tchstd =>
                tchstd.StudentId.Equals(student.Id));


#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"row\">1</th>\r\n                <td> ");
#nullable restore
#line 29 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
                Write(student.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
                                   Write(student.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>3</td>\r\n                <td");
            BeginWriteAttribute("class", " class=\"", 872, "\"", 958, 2);
#nullable restore
#line 31 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
WriteAttributeValue(" ", 880, teacherStudent.Status.Equals("active") ? "table-success" : "table-danger", 881, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 957, "", 958, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 32 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
               Write(teacherStudent.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td style=\"display: flex; justify-content: space-around;\">\r\n");
#nullable restore
#line 35 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
                     if(teacherStudent.Status.Equals("active")){

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button class=\"btn btn-danger\">Deactivate</button>\r\n");
#nullable restore
#line 37 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
                    }
                    else{

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button class=\"btn btn-success\">Activate</button>\r\n");
#nullable restore
#line 40 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <button class=\"btn btn-danger\">Delete</button>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 45 "C:\Codelearnershub\BuckleUp\BuckleUp\Views\Teacher\Students.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BuckleUp.Models.ViewModels.StudentListVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
