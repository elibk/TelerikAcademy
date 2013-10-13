using System;

public class CSharpExam : Exam
{
    public const int MinScore = 0;
    public const int MaxScore = 100;
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < MinScore)
            {
                throw new ArgumentException(string.Format("value of 'Score' can not be less than {0}", MinScore));
            }

            if (value > MaxScore)
            {
                throw new ArgumentException(string.Format("value of 'Score' can not be grater than {0}", MaxScore));
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
    }
}
