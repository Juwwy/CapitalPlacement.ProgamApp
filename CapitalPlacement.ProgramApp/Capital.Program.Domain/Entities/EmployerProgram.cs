
namespace Capital.Program.Domain.Entities
{
    public class EmployerProgram
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        #region Personal Information Config
        public bool FirstNameRequired { get; set; } 
        public bool LastNameRequired { get; set; } 
        public bool EmailRequired { get; set; }
        public bool PhoneInternal { get; set; } 
        public bool PhoneHide { get; set; } 
        public bool NationalityInternal { get; set; } 
        public bool NationalityHide { get; set; } 
        public bool CurrentResidenceInternal { get; set; }
        public bool CurrentResidenceHide { get; set; } 
        public bool IDNumberInternal { get; set; } 
        public bool IDNUmberHide { get; set; } 
        public bool DateOfBirthInternal { get; set; } 
        public bool DateOfBirthHide { get; set; } 
        public bool GenderInternal { get; set; } 
        public bool GenderHide { get; set; } 
        #endregion

        public MultipleChoiceQuestion? MultipleChoiceQuestion { get; set; }
        public DropDownQuestion? DropDownQuestion { get; set; }
        public YesNoQuestion? YesNoQuestion { get; set; }
        public ParagraphQuestion? ParagraphQuestion { get; set; }
        public DateQuestion? DateQuestion { get; set; }
        public NumericQuestion? NumericQuestion { get; set; }
        public virtual List<UserProfile> UserProfiles { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }

       
    }
}
