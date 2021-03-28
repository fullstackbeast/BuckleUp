using System;
using System.Collections.Generic;
using BuckleUp.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BuckleUp.Models.ViewModels
{
    public class CreateAssessmentVM
    {
        public string Title {get; set;}
        public string Type {get; set;}
        public List<SelectListItem> CourseSelectList {get; set;}
        public Guid CourseId {get; set;}
        public int NumberOfQuestions {get; set;}
        public AssessmentQuestion [] Questions { get; set;}   
    }
}