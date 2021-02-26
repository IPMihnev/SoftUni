namespace ValidationAttributes.Models
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool Isvalid(object obj)
        {
            return obj != null;
        }
    }
}
