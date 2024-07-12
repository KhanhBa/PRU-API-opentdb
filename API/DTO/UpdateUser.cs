namespace API.DTO
{
    public class UpdateUser
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool? Status { get; set; }

        public int? Score { get; set; }
    }
}
