namespace PasswordCrackerApi.Dtos
{
    public class CrackRequestDto
    {
        public string HashCode { get; set; }
        public string Alphabet { get; set; }
        public int Length { get; set; }
    }
}
