using System;

public class SimpleMathExam : Exam
{
    public const int MaxValueOfProblemSolved = 10;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("value of 'ProblemsSolved' can not be grater negative number.");
            }

            if (value > MaxValueOfProblemSolved)
            {
               throw new ArgumentException(string.Format("value of 'ProblemsSolved' can not be grater than {0}", MaxValueOfProblemSolved));
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");

            case 1:
                return new ExamResult(4, 2, 6, "Average result: nothing done.");

            case 2:
                return new ExamResult(6, 2, 6, "Average result: nothing done.");

            default:
                throw new InvalidOperationException(
                    string.Format(
                    "Can not be preform Check() because there is no expexted result of this type of 'SimpleMathExam' with {0} as value of 'ProblemsSolved'.", this.ProblemsSolved));
        }
    }
}
