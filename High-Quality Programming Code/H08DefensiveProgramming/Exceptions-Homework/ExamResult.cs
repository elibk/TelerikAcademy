using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        //// check is needed in case that get of MinValue returns some modified value, and the check in propertie in not enough
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Can not make an object of type 'ExamResult' with value for 'minGrade' > value for 'maxGrade'.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("value of 'Grade' can not be negative number.");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("value of 'MinGrade' can not be negative number.");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        set
        {
            if (value <= this.minGrade)
            {
                throw new ArgumentException(
                    string.Format(
                    "value of 'MaxGrade' can not be less than value of 'MinGrade'. For this instance can not be less than '{0}'.", this.MinGrade));
                //// there is a risk to return misleading value in this.MinGrade if it's get makes some modification of the value
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("value of 'Comments' can not be null.");
            }

            if (value == string.Empty)
            {
                throw new ArgumentException("value of 'Comments' can not be empty string.");
            }

            this.comments = value;
        }
    }
}
