namespace Quiz.DTO
{
    public class QuizResultDTO
    {
      
        public int SessionId { get; set; }
        public int Score { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public DateTime CompleteAt { get; set; }
    }
}
