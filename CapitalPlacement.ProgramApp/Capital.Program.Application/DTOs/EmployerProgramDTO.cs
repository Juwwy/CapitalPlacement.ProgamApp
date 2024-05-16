
namespace Capital.Program.Application.DTOs
{
    public class EmployerProgramDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }

        

        #region Personal Information Config
        public  bool FirstNameRequired { get; set; } = true;
        public  bool LastNameRequired { get; set; } = true;
        public  bool EmailRequired { get; set; } = true;
        public  bool PhoneInternal { get; set; } 
        public  bool PhoneHide { get; set; } 
        public  bool NationalityInternal { get; set; } 
        public  bool NationalityHide { get; set; } 
        public  bool CurrentResidenceInternal { get; set; } 
        public  bool CurrentResidenceHide { get; set; } 
        public  bool IDNumberInternal { get; set; } 
        public  bool IDNUmberHide { get; set; } 
        public  bool DateOfBirthInternal { get; set; } 
        public  bool DateOfBirthHide { get; set; } 
        public  bool GenderInternal { get; set; } 
        public  bool GenderHide { get; set; } 
        #endregion

        public MultipleChoiceDTO MultipleChoice { get; set; }
        public ParagraphDTO ParagraphQuestion { get; set; }
        public NumericDTO NumericQuestion { get; set; }
        public DropDownDTO DropDownQuestion { get; set; }
        public YesNoDTO YesNoQuestion { get; set; }
        public DateQuestionDTO DateQuestion { get; set; }
    }
}
