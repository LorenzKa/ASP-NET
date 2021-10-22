namespace TournamentDb.DTO
{
    public class MatchDto
    {
        public int Id { get; set; }
        public PlayerDto Player1 { get; set; }
        public PlayerDto Player2 { get; set; }
        public int? Winner { get; set; }
    }
}
